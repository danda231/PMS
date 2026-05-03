using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IDAL
{
    public interface IMenuAccess
    {

        public string GetAllMenus(string key);

        public string UpdateMenu(string menuJson);

        public string DeleteMenu(string id);
    }
}
