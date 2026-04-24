using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Bll
{
    public class FileService : IFileService
    {
        IFileAccess _fileAccess;
        public FileService(IFileAccess fileAccess) 
        { 
            _fileAccess = fileAccess; 
        }
        public IEnumerable<FileEntities> GetUpgradeFiles()
        {
            string json = _fileAccess.GetUpgradeFiles();
            return System.Text.Json.JsonSerializer.Deserialize<List<FileEntities>>(json);
        }
    }
}
