using PMS.Client.IBll;
using PMS.Client.IDAL;

namespace PMS.Client.Bll
{
    public class UserService : IUserService
    {
        IUserAccess _userAccess;
        public UserService(IUserAccess userAccess) {
            _userAccess = userAccess;
        }
        public bool Login(string username, string password)
        {
            return _userAccess.Login(username,password);
        }
    }
}
