using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IDAL
{
    public interface IUserAccess
    {
        string Login(string username, string password);

        string UpdatePassword(int id, string old_password, string new_password);
    }
}
