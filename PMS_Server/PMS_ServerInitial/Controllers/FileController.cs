using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.Entities;
using PMS.Server.IService;
using PMS.Server.Models;
using System.Net.Http.Headers;

namespace PMS.ServerInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        [HttpGet("list/{key}")]
        public ActionResult Get([FromRoute] string key)
        {
            Result<UpgradeFileEntity[]> result = new Result<UpgradeFileEntity[]>();

            try
            {
                key = key == "none" ? "" : key;
                var ms = _fileService.GetUpgradeFiles(key);
                result.Data = ms.ToArray();
            }catch(Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }

            return Ok(result);
        }

        [HttpGet("download/{p}/{file}")]
        public ActionResult DownLoad([FromRoute(Name ="p")]string path,[FromRoute] string file)  
        {
            // 文件存放更新文件的目录
            var root = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string filePath = Path.Combine(root, @"WebFiles", "UpgradeFiles");

            // 如果有二级目录
            if (path != "none") 
                filePath = Path.Combine(filePath, path);
            filePath = Path.Combine(filePath, file);

            ResFileStream fs = new ResFileStream(filePath, FileMode.Open, FileAccess.Read);
            var type = new MediaTypeHeaderValue("application/oct-stream").MediaType;
            return File(fs, type, fileDownloadName: file);
        }

        // http://
        [HttpGet("img/{img}")]
        public IActionResult GetImage([FromRoute(Name = "img")] string imgPath)
        {
            var root = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string rootPath = Path.Combine(root, @"WebFiles\UserAvatars");
            //获取图片的返回类型
            var contentTypDict = new Dictionary<string, string> {
                {"jpg","image/jpeg"},
                {"jpeg","image/jpeg"},
                {"jpe","image/jpeg"},
                {"png","image/png"},
                {"gif","image/gif"},
                {"ico","image/x-ico"},
                {"tif","image/tiff"},
                {"tiff","image/tiff"},
                {"fax","image/fax"},
                {"wbmp","image/nd.wap.wbmp"},
                {"rp","imagend.rn-realpix"}
            };
            var contentTypeStr = "image/jpeg";

            var imgTypeSplit = imgPath.Split('.');
            var imgType = imgTypeSplit[imgTypeSplit.Length - 1].ToLower();
            //未知的图片类型
            if (contentTypDict.ContainsKey(imgType))
            {
                contentTypeStr = contentTypDict[imgType];
            }

            string filePath = Path.Combine(rootPath, imgPath);
            //图片不存在
            if (!new FileInfo(filePath).Exists)
            {
                return NotFound();
            }
            //返回原图
            using (var sw = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var bytes = new byte[sw.Length];
                sw.Read(bytes, 0, bytes.Length);
                sw.Close();
                return new FileContentResult(bytes, contentTypeStr);
            }
        }


        [HttpPost("upload")]
        public IActionResult Upload([FromForm] IFormCollection formCollection, 
            [FromHeader] string md5, [FromHeader] string file_path)
        {
            Result<long> result = new Result<long>();
            try
            {
                FormFileCollection filelist = (FormFileCollection)formCollection.Files;
                if(filelist.Count > 0)
                {
                    string filename = filelist[0].FileName;

                    var root = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                    string targetPath = Path.Combine(root, "WebFiles", "UpgradeFiles");
                    if (!string.IsNullOrEmpty(file_path) && file_path != ".\\")
                        targetPath = Path.Combine(targetPath, file_path);

                    // 没有这个目录的话建立一个
                    DirectoryInfo di = new DirectoryInfo(targetPath);
                    if(!di.Exists) di.Create();

                    using(FileStream fs = System.IO.File.Create(Path.Combine(targetPath, filename)))
                    {
                        // 复制文件
                        filelist[0].CopyToAsync(fs).GetAwaiter().GetResult();
                        // 清空缓冲区数据
                        fs.Flush();
                    }

                    // 更新或插入到数据库
                    UpgradeFileEntity upgradeFile = new UpgradeFileEntity
                    {
                        FileName = filename,
                        FileMd5 = md5,
                        FilePath = file_path,
                        UploadTime = DateTime.Now,
                        Length = filelist[0].Length
                        
                    };
                    result.Data = _fileService.AddOrUpdate(upgradeFile);

                }
            }catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        [Authorize]
        public ActionResult DeleteFile([FromForm] string filename)
        {
            Result<int> result = new Result<int>();
            try
            {
                var file = _fileService.GetFileByName(filename);
                result.Data = _fileService.Delete(filename);

                // 删除存放的文件
                var root = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                string targetPath = Path.Combine(root, "WebFiles", "UpgradeFiles");
                if (!string.IsNullOrEmpty(file.FilePath) && file.FilePath != ".\\")
                    targetPath = Path.Combine(targetPath, file.FilePath);
                string full_path = Path.Combine(targetPath,filename);
                if(System.IO.File.Exists(full_path))
                    System.IO.File.Delete(full_path);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

    }
    internal class ResFileStream : FileStream
    {
        public ResFileStream(string path, FileMode mode, FileAccess access) : base(path, mode, access) { }

        /// <param name="buffer"></param>
        /// <param name="offset">偏移量</param>
        /// <param name="count">读取的最大字节数</param>
        /// <returns></returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            // 限制count =》 限制下载速度
            return base.Read(buffer, offset, count);
        }

    }
}
