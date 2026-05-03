using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IDAL
{
    public interface IRoleAccess
    {
        string GetRoleByIds(string ids);

        string GetAllRoles(string key);
        string CheckRoleName(string roleName, int id);

        string Update(string role);

        string Delete(int id);
        string UpdateRoleMenus(string rms);

        string UpdateRoleUsers(string rms);

        string DeleteRoleUsers(int rid, int uid);
    }
}
