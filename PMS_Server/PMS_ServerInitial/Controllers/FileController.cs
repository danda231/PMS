using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.IService;
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
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_fileService.GetUpgradeFiles());
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
