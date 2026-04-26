using PMS.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.DAL
{
    public class UserAccess : WebAccess, IUserAccess
    {
        public string Login(string username, string password)
        {
            string res = this.Get($"api/User?un={username}&pw={password}");
            

            return res;
        }
    }
}
