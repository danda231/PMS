using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Client.Entities;

namespace PMS.Client.IBll
{
    public interface IMenuService
    {

        public IEnumerable<MenuEntity> GetAllMenus();
        
    }
}
