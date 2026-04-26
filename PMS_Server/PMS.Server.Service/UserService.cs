using PMS.Server.Entities;
using PMS.Server.IService;
using SqlSugar;

namespace PMS.Server.Service
{
    public class UserService : IUserService
    {
        ISqlSugarClient _client;
        public UserService(ISqlSugarClient client) {
            _client = client;
        }

        public SysEmployee? CheckLogin(string username, string password)
        {
            var es = _client.Queryable<SysEmployee>()
                .Where(e=>e.UserName == username && e.Password == password)
                .ToList();
            return es.FirstOrDefault();
        }
    }
}
