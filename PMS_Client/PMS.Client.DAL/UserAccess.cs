using PMS.Client.Entities;
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
        public UserAccess(GlobalValues globalValues) : base(globalValues)
        {
        }

        public string Login(string username, string password)
        {
            Dictionary<string, HttpContent> FormData = new Dictionary<string, HttpContent>();   
            FormData.Add("un", new StringContent(username));
            FormData.Add("pw", new StringContent(password));
            string res = this.Post($"api/User/login",this.GetFormData(FormData));
            

            return res;
        }

        public string UpdatePassword(int id, string old_password, string new_password)
        {
            Dictionary<string, HttpContent> FormData = new Dictionary<string, HttpContent>();
            FormData.Add("id", new StringContent(id.ToString()));
            FormData.Add("old_password", new StringContent(old_password));
            FormData.Add("new_password", new StringContent(new_password));
            string res = this.Post($"api/User/update_pwd", this.GetFormData(FormData));


            return res;
        }
    }
}
