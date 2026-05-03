using PMS.Server.Entities;
using PMS.Server.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Server.Service
{
    public class MenuService : IMenuService
    {
        ISqlSugarClient _client;
        public MenuService(ISqlSugarClient client)
        {
            _client = client;
        }

        public int Delete(string id)
        {
            return _client.Deleteable<MenuEntity>().In(id).ExecuteCommand();
        }

        public int Update(MenuEntity menu)
        {
            int res = 0;
            // 
            if (string.IsNullOrEmpty(menu.MenuId))
            {
                // 新增一个menu
                var max = _client.Queryable<MenuEntity>()
                    .Where(m => m.ParentId == menu.ParentId)
                    .Max(m => m.MenuId);

                menu.MenuId = (int.Parse(max)+1).ToString();
                res = _client.Insertable(menu).ExecuteCommand();
            }
            else
            {
                var menuEntity = _client.Queryable<MenuEntity>()
                    .Where(m => m.MenuId == menu.MenuId).ToList().FirstOrDefault();
                if (menuEntity == null) throw new Exception("无匹配的菜单信息");

                menuEntity.MenuHeader = menu.MenuHeader;
                menuEntity.ParentId = menu.ParentId;
                menuEntity.MenuIcon = menu.MenuIcon;
                menuEntity.TargetView = menu.TargetView;
                res = _client.Updateable(menuEntity).ExecuteCommand();
            }
            return res;
            
        }

        IEnumerable<MenuEntity> IMenuService.GetAllMenus(string key)
        {
            /// 数据库中 state >= 0 且 
            /// key为空 => 返回所有记录
            /// MenuHeader 匹配关键词 或者 TargetView匹配关键词 或 当前菜单子菜单相关字段也能匹配上
            var ms = _client.Queryable<MenuEntity>()
                .Where(m => m.State > 0 &&
                (string.IsNullOrEmpty(key) || 
                (m.MenuHeader.Contains(key) || m.TargetView.Contains(key) ||
                SqlFunc.Subqueryable<MenuEntity>().Where(sm => sm.ParentId == m.MenuId &&
                (sm.MenuHeader.Contains(key) || sm.TargetView.Contains(key))).Count() > 0
                )))
                .ToList();

            return ms;
        }
    }
}
