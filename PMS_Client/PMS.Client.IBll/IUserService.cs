using PMS.Client.Entities;

namespace PMS.Client.IBll
{
    public interface IUserService
    {
        EmployEntity Login(string username, string password);

    }
}
