namespace PMS.Server.IService
{
    public interface IUserService
    {
        public bool CheckLogin(string username, string password);
    }
}
