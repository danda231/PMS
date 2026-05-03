using PMS.Client.Entities;

namespace PMS.Client.IBll
{
    public interface IUserService
    {
        EmployEntity Login(string username, string password);

        bool UpdatePassword(int id, string opd, string npd);

        EmployEntity[] GetUsers(string key);

        EmployEntity[] GetUsersByIds(int[] ids);
        int UpdateUser(EmployEntity employEntity);

        int DeleteUser(int id);

        bool LockUser(int id, int status);

        bool CheckUserName(string userName, int id);

        int SaveUserRoles(RoleUser[] roleUsers);

        int ResetPassword(int id);

    }
}
