using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using PMS.Client.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PMS.Client.Bll
{
    public class FileService : ServiceBase,IFileService
    {
        IFileAccess _fileAccess;
        public FileService(IFileAccess fileAccess) 
        { 
            _fileAccess = fileAccess; 
        }

        public int DeleteFile(string fileName)
        {
            string json = _fileAccess.DeleteFile(fileName);
            //var res = JsonUtil.Deserializer<Result<int>>(json);

            //if (res == null)
            //    throw new Exception("删除文件失败");
            //if (res.state != 200)
            //    throw new Exception(res.exceptionMessage);

            //return res.data;
            return this.GetResult<int>(json);
        }

        public IEnumerable<FileEntities> GetUpgradeFiles(string key = "")
        {
            string json = _fileAccess.GetUpgradeFiles(key);
            //var res = JsonUtil.Deserializer<Result<FileEntities[]>>(json);

            //if (res == null)
            //    throw new Exception("查询失败");
            //if (res.state != 200)
            //    throw new Exception(res.exceptionMessage);

            //return res.data;
            return this.GetResult<FileEntities[]>(json);
        }

        public void UploadFile(string file, string save_path, Action<int> progress, Action<AsyncCompletedEventArgs> completed)
        {
            _fileAccess.UploadFile(file, save_path, progress, completed);
        }
    }
}
