using Microsoft.IdentityModel.Tokens;
using PMS.Server.Entities;
using PMS.Server.IService;
using SqlSugar;
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

        public bool UpdatePassword(int id, string old_password, string new_password)
        {
            var employee = _client.Queryable<SysEmployee>()
                .Where(e => e.EId == id && e.Password == old_password).First();
            if(employee == null) return false;
            employee.Password = new_password;
            _client.Updateable(employee).ExecuteCommand();

            return true;
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
