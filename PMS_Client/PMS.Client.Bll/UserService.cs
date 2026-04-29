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

        public bool UpdatePassword(int id, string opd, string npd)
        {
            string json = _userAccess.UpdatePassword(id, opd, npd);
            Result<bool> result = JsonUtil.Deserializer<Result<bool>>(json);
            if (result.state != 200)
                throw new Exception(result.exceptionMessage);

            return result.data;
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
