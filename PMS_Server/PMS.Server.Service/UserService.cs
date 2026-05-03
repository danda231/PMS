using Microsoft.IdentityModel.Tokens;
using PMS.Server.Entities;
using PMS.Server.IService;
using SqlSugar;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            var employee = es.FirstOrDefault();
            if (employee != null && this.AuthentationToken(username + password, out string token))
            {
                employee.Token = token;
            }
            return employee;
        }

        public bool CheckUserName(string username, int id)
        {
            return _client.Queryable<SysEmployee>()
                .Any(e => e.UserName == username && e.EId != id);
        }

        public int Delete(int id)
        {
            return _client.Deleteable<SysEmployee>().In(id).ExecuteCommand();
        }

        public SysEmployee[] GetUsers(string key)
        {
            return _client.Queryable<SysEmployee>()
                //.Mapper(role  => role.Roles, role => role.EId)
                .Where(e =>
                string.IsNullOrEmpty(key) ||
                e.UserName.Contains(key) || e.RealName.Contains(key) || e.Address.Contains(key))
                .Select(e => new SysEmployee()
                {
                    Roles = SqlFunc.Subqueryable<RoleUser>()
                    .Where(ru => ru.UserId == e.EId).ToList()
                })
                .ToArray();
        }

        public SysEmployee[] GetUsersByIds(int[] ids)
        {
            return _client.Queryable<SysEmployee>()
                //.Mapper(role  => role.Roles, role => role.EId)
                .Where(e => ids.Contains(e.EId))
                .ToArray();
        }

        public bool LockUser(int id, int status)
        {
            return _client.Updateable<SysEmployee>()
                .SetColumns(e => new SysEmployee { Status = status })
                .Where(e => e.EId == id)
                .ExecuteCommand() > 0;
        }

        public int ResetPassword(int id)
        {
            return _client.Updateable<SysEmployee>()
                .SetColumns(e => new SysEmployee { Password = "123456" })
                .Where(e => e.EId == id).ExecuteCommand();
        }

        public bool UpdatePassword(int id, string old_password, string new_password)
        {
            var employee = _client.Queryable<SysEmployee>()
                .Where(e => e.EId == id && e.Password == old_password).First();
            if(employee == null) return false;
            employee.Password = new_password;
            _client.Updateable(employee).ExecuteCommand();

            return true;
        }

        public int UpdateUser(SysEmployee employee)
        {
            int res = 0;
            if(employee.EId == 0)
            {
                // 插入
                // 生成id (当前年份 + 当前年份最大id)
                int? max = _client.Queryable<SysEmployee>()
                    .Where(e => e.EId.ToString().StartsWith(DateTime.Now.Year.ToString()))
                    .Max(e => (int?)e.EId);
                int seq = 0;
                if (max != null) seq = max.Value % 1000;
                int new_id = DateTime.Now.Year * 1000 + seq + 1;                
                employee.EId = new_id;
                // 插入
                res = _client.Insertable(employee).ExecuteCommand(); 
            }else
            {
                // 更新
                res = _client.Updateable<SysEmployee>(employee).ExecuteCommand();
            }

            return res;
        }

        public int UpdateUserRoles(RoleUser[] roles)
        {
            // 先删除所有的
            _client.Deleteable<RoleUser>().Where(ru => ru.UserId == roles[0].UserId).ExecuteCommand();

            return _client.Insertable(roles).ExecuteCommand();
        }

        private bool AuthentationToken(string username,out string token)
        {
            token = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(username)) return false;
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, username),
                };

                // 密码
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456123456123456luckyeggluckyegg"));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var jwtToken = new JwtSecurityToken(
                    "webapi.cn",
                    "WebApi",
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: credentials
                    );
                token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                return true;
            }
            catch
            {
                token = "";
                return false;
            }

        }
    }
}
