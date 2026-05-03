using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IDAL
{
    public interface IUserAccess
    {
        string Login(string username, string password);

        string UpdatePassword(int id, string old_password, string new_password);

        string GetUsers(string key);

        string UpdateUser(string user_json);

        string DeleteUser(int id);

        string LockUser(int id, int status);

        string CheckUserName(string username, int id);

        string UpdateUserRoles(string roles);
        string ResetPassword(int id);

        string GetUsersByIds(string ids);
    }
}
