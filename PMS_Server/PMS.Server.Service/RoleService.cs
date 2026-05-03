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
    public class RoleService : IRoleService
    {
        ISqlSugarClient _client;
        public RoleService(ISqlSugarClient client) 
        {
            _client = client;
        }

        public bool CheckRoleName(string roleName, int id)
        {
            return _client.Queryable<SysRole>()
                .Any(r => r.RoleName == roleName && r.RoleId != id);
        }

        public int Delete(int id)
        {
            return _client.Deleteable<SysRole>()
                .In(id).ExecuteCommand();
        }

        public int DeleteRoleUser(int rid, int uid)
        {
            return _client.Deleteable<RoleUser>()
                .Where(ru => ru.RoleId == rid && ru.UserId == uid).ExecuteCommand();
        }

        public SysRole[] GetAllRoles(string key)
        {
            return _client.Queryable<SysRole>()
                .Includes(r => r.Menus.MappingField( m => m.RoleId, () => r.RoleId).ToList())
                .Includes(r => r.Users.MappingField(m => m.RoleId, () => r.RoleId).ToList())
                .Where(r => string.IsNullOrEmpty(key) ||
                r.RoleName.Contains(key) ||
                r.RoleDesc.Contains(key)).ToArray();
        }

        public SysRole[] GetRoleByIds(int[] roleIds)
        {
            return _client.Queryable<SysRole>().Where(r => roleIds.Contains(r.RoleId)).ToArray();
        }

        public int Update(SysRole role)
        {
            int count = 0;
            if(role.RoleId == 0)
            {
                // 新增
                count = _client.Insertable<SysRole>(role).IgnoreColumns(r => r.RoleId).ExecuteCommand();
            }
            else
            {
                // 更改
                count = _client.Updateable<SysRole>(role).ExecuteCommand();
            }
            return count;
        }

        public int UpdateRoleMenus(RoleMenu[] rms)
        {
            try
            {
                _client.Ado.BeginTran();  // 开启事务

                _client.Deleteable<RoleMenu>()
                    .Where(rm => rm.RoleId == rms[0].RoleId)
                    .ExecuteCommand();

                int result = _client.Insertable(rms).ExecuteCommand();

                _client.Ado.CommitTran();  // 提交事务
                return result;
            }
            catch (Exception)
            {
                _client.Ado.RollbackTran();  // 回滚事务
                throw;
            }
        }

        public int UpdateRoleUsers(RoleUser[] rms)
        {
            try
            {
                _client.Ado.BeginTran();  // 开启事务

                _client.Deleteable<RoleUser>()
                    .Where(rm => rm.RoleId == rms[0].RoleId)
                    .ExecuteCommand();

                int result = _client.Insertable(rms).ExecuteCommand();

                _client.Ado.CommitTran();  // 提交事务
                return result;
            }
            catch (Exception)
            {
                _client.Ado.RollbackTran();  // 回滚事务
                throw;
            }
        }
    }
}
