using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Server.Entities;

namespace PMS.Server.IService
{
    public interface IFileService
    {
        IEnumerable<UpgradeFileEntity> GetUpgradeFiles(string key);

        int AddOrUpdate(UpgradeFileEntity entity);

        int Delete(string file_name);

        UpgradeFileEntity GetFileByName(string fileName);
    }
}
