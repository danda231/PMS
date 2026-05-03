using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using PMS.Client.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Bll
{
    public class RoleService : ServiceBase, IRoleService
    {
        IRoleAccess _roleAccess;
        public RoleService(IRoleAccess roleAccess) 
        { 
            _roleAccess = roleAccess;
        }

        public bool CheckRoleName(string roleName, int id)
        {
            string json = _roleAccess.CheckRoleName(roleName, id);
            return this.GetResult<bool>(json);
        }

        public int DeleteRole(int id)
        {
            string json = _roleAccess.Delete(id);
            return this.GetResult<int>(json);
        }

        public int DeleteRoleUsers(int uid, int rid)
        {
            string json = _roleAccess.DeleteRoleUsers(rid, uid);
            return this.GetResult<int>(json);
        }

        public SysRole[] GetAllRoles(string key)
        {
            key = string.IsNullOrEmpty(key) ? "none" : key;
            string json = _roleAccess.GetAllRoles(key);
            return this.GetResult<SysRole[]>(json);
        }

        public SysRole[] GetRoleByIds(int[] ids)
        {
            string json = JsonUtil.Serializer(ids);
            json = _roleAccess.GetRoleByIds(json);
            //var res = JsonUtil.Deserializer<Result<SysRole[]>>(json);

            //if (res == null)
            //    throw new Exception("获取角色数据失败！");
            //if (res.state != 200)
            //    throw new Exception(res.exceptionMessage);

            //return res.data;
            return this.GetResult<SysRole[]>(json);
        }

        public int UpdateRole(SysRole role)
        {
            string json = JsonUtil.Serializer(role);
            json = _roleAccess.Update(json);
            return this.GetResult<int>(json);
        }

        public int UpdateRoleMenus(RoleMenu[] rms)
        {
            string json = JsonUtil.Serializer(rms);
            json = _roleAccess.UpdateRoleMenus(json);
            return this.GetResult<int>(json);
        }

        public int UpdateRoleUsers(RoleUser[] rms)
        {
            string json = JsonUtil.Serializer(rms);
            json = _roleAccess.UpdateRoleUsers(json);
            return this.GetResult<int>(json);
        }
    }
}
