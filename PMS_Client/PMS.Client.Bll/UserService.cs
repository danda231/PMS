using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using PMS.Client.Utils;

namespace PMS.Client.Bll
{
    public class UserService : IUserService
    {
        IUserAccess _userAccess;
        public UserService(IUserAccess userAccess) {
            _userAccess = userAccess;
        }
        public string Login(string username, string password)
        {
            return _userAccess.Login(username,password);
        }

        EmployEntity IUserService.Login(string username, string password)
        {
            string json = _userAccess.Login(username, password);
            Result<EmployEntity> result = JsonUtil.Deserializer<Result<EmployEntity>>(json);
            if(result.state != 200)
                throw new Exception(result.exceptionMessage);

            return result.data;
        }
    }
}
