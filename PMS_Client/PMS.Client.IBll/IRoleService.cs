using PMS.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IBll
{
    public interface IRoleService
    {
        SysRole[] GetRoleByIds(int[] id);
        SysRole[] GetAllRoles(string key = "none");

        bool CheckRoleName(string roleName, int id);

        int UpdateRole(SysRole role);

        int DeleteRole(int id);
        int UpdateRoleMenus(RoleMenu[] rms);

        int UpdateRoleUsers(RoleUser[] rms);

        int DeleteRoleUsers(int uid, int rid);
    }
}
