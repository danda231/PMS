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

        public IEnumerable<UpgradeFileEntity> GetUpgradeFiles()
        {
            return _sqlSugarClient.Queryable<UpgradeFileEntity>().ToList();
        }
    }
}
