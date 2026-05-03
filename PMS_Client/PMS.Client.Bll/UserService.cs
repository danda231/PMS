using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using PMS.Client.Utils;

namespace PMS.Client.Bll
{
    public class UserService : ServiceBase, IUserService
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
            //Result<bool> result = JsonUtil.Deserializer<Result<bool>>(json);
            //if (result.state != 200)
            //    throw new Exception(result.exceptionMessage);

            return this.GetResult<bool>(json);
        }

        EmployEntity IUserService.Login(string username, string password)
        {
            string json = _userAccess.Login(username, password);
            //Result<EmployEntity> result = JsonUtil.Deserializer<Result<EmployEntity>>(json);
            //if(result.state != 200)
            //    throw new Exception(result.exceptionMessage);

            return this.GetResult<EmployEntity>(json);
        }

        public EmployEntity[] GetUsers(string key)
        {
            string json = _userAccess.GetUsers(key);
            //Result<EmployEntity[]> result = JsonUtil.Deserializer<Result<EmployEntity[]>>(json);
            //if (result.state != 200)
            //    throw new Exception(result.exceptionMessage);

            return this.GetResult<EmployEntity[]>(json);
        }

        public int UpdateUser(EmployEntity employEntity)
        {
            string json = JsonUtil.Serializer(employEntity);
            json = _userAccess.UpdateUser(json);
            return this.GetResult<int>(json);
        }

        public int DeleteUser(int id)
        {
            string res = _userAccess.DeleteUser(id);
            return this.GetResult<int>(res);
        }

        public bool LockUser(int id, int status)
        {
            string res = _userAccess.LockUser(id, status);
            return this.GetResult<bool>(res);
        }

        public bool CheckUserName(string userName, int id)
        {
            string res = _userAccess.CheckUserName(userName, id);
            return this.GetResult<bool>(res);
        }

        public int SaveUserRoles(RoleUser[] roleUsers)
        {
            string json = JsonUtil.Serializer(roleUsers);
            json = _userAccess.UpdateUserRoles(json);
            return this.GetResult<int>(json);
        }

        public int ResetPassword(int id)
        {
            string json = _userAccess.ResetPassword(id);
            return this.GetResult<int>(json);
        }

        public EmployEntity[] GetUsersByIds(int[] ids)
        {
            string json = JsonUtil.Serializer(ids);
            json = _userAccess.GetUsersByIds(json);
            return this.GetResult<EmployEntity[]>(json);
        }
    }
}
