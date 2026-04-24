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
        IEnumerable<UpgradeFileEntity> GetUpgradeFiles();
    }
}
