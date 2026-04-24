using PMS.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.DAL
{
    public class FileAccess : WebAccess, IFileAccess
    {
        public string GetUpgradeFiles()
        {
            
            return this.Get("api/File");
        }
    }
}
