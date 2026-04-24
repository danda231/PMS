using PMS.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IBll
{
    public interface IFileService
    {
        IEnumerable<FileEntities> GetUpgradeFiles();
    }
}
