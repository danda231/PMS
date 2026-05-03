using PMS.Client.Entities;
using PMS.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PMS.Client.DAL
{
    public class UserAccess : WebAccess, IUserAccess
    {
        public UserAccess(GlobalValues globalValues) : base(globalValues)
        {
        }

        public string CheckUserName(string username, int id)
        {
            string uri = $"api/User/check/{username}/{id}";
            return this.Get(uri);
        }

        public string DeleteUser(int id)
        {
            string uri = $"api/User/delete/{id}";
            return this.Get(uri) ;
        }

        public string GetUsers(string key)
        {
            string url = $"api/User/list/" + (string.IsNullOrEmpty(key)?"none":key);
            return this.Get(url);
        }

        public string GetUsersByIds(string ids)
        {
            string uri = "api/User/ids";
            StringContent content = new StringContent(ids);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);

        }

        public string LockUser(int id, int status)
        {
            string url = $"api/User/lock/{id}/{status}" ;
            return this.Get(url);
        }

        public string Login(string username, string password)
        {
            Dictionary<string, HttpContent> FormData = new Dictionary<string, HttpContent>();   
            FormData.Add("un", new StringContent(username));
            FormData.Add("pw", new StringContent(password));
            string res = this.Post($"api/User/login",this.GetFormData(FormData));
            

            return res;
        }

        public string ResetPassword(int id)
        {
            string uri = $"api/User/reset_pwd/{id}";
            return this.Get(uri);
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

        public string UpdateUser(string user_json)
        {
            string uri = "api/User/update";
            StringContent content = new StringContent(user_json);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }

        public string UpdateUserRoles(string roles)
        {
            string uri = "api/User/update_roles";
            StringContent content = new StringContent(roles);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }
    }
}
