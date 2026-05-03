using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using PMS.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PMS.Client.Bll
{
    public class MenuService : IMenuService
    {
        IMenuAccess _menuAccess;

        public MenuService(IMenuAccess menuAccess)
        {
            _menuAccess = menuAccess;
        }

        public int DeleteMenu(string id)
        {
            string json = _menuAccess.DeleteMenu(id);
            var res = JsonUtil.Deserializer<Result<int>>(json);
            if (res == null)
                throw new Exception("删除");
            if (res.state != 200)
                throw new Exception(res.exceptionMessage);
            if (res.data == 0) throw new Exception("未删除任何数据");

            return res.data;
        }

        public IEnumerable< MenuEntity> GetAllMenus(string key)
        {
            string json = _menuAccess.GetAllMenus(key);
            var res = JsonUtil.Deserializer<Result<MenuEntity[]>>(json);
            if (res == null) 
                throw new Exception("菜单获取失败");
            if(res.state != 200) 
                throw new Exception(res.exceptionMessage);

            return res.data;
        }

        public int UpdateMenu(MenuEntity menu)
        {
            string menu_json = System.Text.Json.JsonSerializer.Serialize(menu);
            string json = _menuAccess.UpdateMenu(menu_json);
            var res = JsonUtil.Deserializer<Result<int>>(json);
            if (res == null)
                throw new Exception("更新失败");
            if (res.state != 200)
                throw new Exception(res.exceptionMessage);
            if (res.data == 0) throw new Exception("未更新任何数据");

            return res.data;
        }
    }
}
