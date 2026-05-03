using PMS.Server.Entities;

namespace PMS.Server.IService
{
    public interface IUserService
    {
        public SysEmployee? CheckLogin(string username, string password);

        bool UpdatePassword(int id, string old_password, string new_password);

        SysEmployee[] GetUsers(string key);

        SysEmployee[] GetUsersByIds(int[] ids);

        int UpdateUser(SysEmployee employee);

        int Delete(int id);

        bool LockUser(int id, int status);

        bool CheckUserName(string username, int id);

        int UpdateUserRoles(RoleUser[] roles);

        int ResetPassword(int id);
    }
}
