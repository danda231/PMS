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

        IEnumerable<MenuEntity> IMenuService.GetAllMenus()
        {
            var ms = _client.Queryable<MenuEntity>()
                .Where(m => m.State > 0)
                .ToList();

            return ms;
        }
    }
}
