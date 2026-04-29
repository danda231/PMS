using PMS.Client.Entities;

namespace PMS.Client.IBll
{
    public interface IUserService
    {
        EmployEntity Login(string username, string password);

        bool UpdatePassword(int id, string opd, string npd);

    }
}
