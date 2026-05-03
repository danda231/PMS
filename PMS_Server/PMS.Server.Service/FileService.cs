using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Server.Entities;
using PMS.Server.IService;
using SqlSugar;

namespace PMS.Server.Service
{
    public class FileService : IFileService
    {
        ISqlSugarClient _sqlSugarClient;
        public FileService(ISqlSugarClient sqlSugarClient)
        {
            _sqlSugarClient = sqlSugarClient;
        }

        public int AddOrUpdate(UpgradeFileEntity entity)
        {
            int res = 0;
            // 判断新增or更新
            var file = _sqlSugarClient.Queryable<UpgradeFileEntity>()
                .First(f => f.FileName == entity.FileName);

            if(file == null)
            {
                // 插入
                res = _sqlSugarClient.Insertable(entity).ExecuteCommand();
            }
            else
            {
                // 更新
                file.FileMd5 = entity.FileMd5;
                file.FilePath = entity.FilePath;
                file.UploadTime = entity.UploadTime;
                file.Length = entity.Length;
                res = _sqlSugarClient.Updateable(file).ExecuteCommand();
            }

            return res;
        }

        public int Delete(string file_name)
        {
            return _sqlSugarClient.Deleteable<UpgradeFileEntity>()
                .Where(f => f.FileName == file_name).ExecuteCommand();
        }

        public UpgradeFileEntity GetFileByName(string fileName)
        {
            return _sqlSugarClient.Queryable<UpgradeFileEntity>()
                .First(f => f.FileName == fileName);
        }

        public IEnumerable<UpgradeFileEntity> GetUpgradeFiles(string key)
        {
            return _sqlSugarClient.Queryable<UpgradeFileEntity>()
                .Where(f => string.IsNullOrEmpty(key) || 
                f.FileName.Contains(key)).ToList();
        }
    }
}
