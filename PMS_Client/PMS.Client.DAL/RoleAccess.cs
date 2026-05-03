using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.DAL
{
    public class RoleAccess : WebAccess, IRoleAccess
    {

        public RoleAccess(GlobalValues globalValues) : base(globalValues)
        {
        }

        public string CheckRoleName(string roleName, int id)
        {
            string uri = $"api/Role/check/{id}/{roleName}";
            return this.Get(uri);
        }

        public string Delete(int id)
        {
            string uri = $"api/Role/delete/{id}";
            return this.Get(uri);
        }

        

        public string DeleteRoleUsers(int rid, int uid)
        {
            string uri = $"api/Role/del_user/{uid}/{rid}";
            return this.Get(uri);
        }

        public string GetAllRoles(string key)
        {
            string uri = $"api/Role/all/{key}";
            return this.Get(uri) ;
        }

        public string GetRoleByIds(string ids)
        {
            string uri = "api/Role/list";

            StringContent content = new StringContent(ids);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }

        public string Update(string role)
        {
            string uri = "api/Role/update";

            StringContent content = new StringContent(role);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }

        public string UpdateRoleMenus(string rms)
        {
            string uri = "api/Role/remenus";

            StringContent content = new StringContent(rms);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }

        public string UpdateRoleUsers(string rms)
        {
            string uri = "api/Role/reusers";

            StringContent content = new StringContent(rms);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }
    }
}
