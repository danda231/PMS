using PMS.Server.Entities;

namespace PMS.Server.IService
{
    public interface IUserService
    {
        public SysEmployee? CheckLogin(string username, string password);

        bool UpdatePassword(int id, string old_password, string new_password);
    }
}
