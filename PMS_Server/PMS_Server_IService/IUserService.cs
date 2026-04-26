using PMS.Server.Entities;

namespace PMS.Server.IService
{
    public interface IUserService
    {
        public SysEmployee? CheckLogin(string username, string password);
    }
}
