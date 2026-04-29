using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using PMS.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Bll
{
    public class MenuService : IMenuService
    {
        IMenuAccess _menuAccess;

        public MenuService(IMenuAccess menuAccess)
        {
            _menuAccess = menuAccess;
        }


        public IEnumerable< MenuEntity> GetAllMenus()
        {
            string json = _menuAccess.GetAllMenus();
            var res = JsonUtil.Deserializer<Result<MenuEntity[]>>(json);
            if (res == null) 
                throw new Exception("菜单获取失败");
            if(res.state != 200) 
                throw new Exception(res.exceptionMessage);

            return res.data;
        }
    }
}
