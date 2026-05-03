using PMS.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Server.IService
{
    public interface IRoleService
    {
        SysRole[] GetRoleByIds(int[] roleIds);

        SysRole[] GetAllRoles(string key);

        bool CheckRoleName(string roleName, int id);

        int Update(SysRole role);

        int Delete(int id);

        int UpdateRoleMenus(RoleMenu[] rms);

        int UpdateRoleUsers(RoleUser[] rms);
        int DeleteRoleUser(int rid, int uid);

    }
}
