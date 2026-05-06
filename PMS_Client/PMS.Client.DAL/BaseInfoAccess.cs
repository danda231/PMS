using PMS.Client.Entities;
using PMS.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.DAL
{
    public class BaseInfoAccess : WebAccess, IBaseInfoAccess
    {
        public BaseInfoAccess(GlobalValues globalValues) : base(globalValues)
        {
        }

        public string CancelState(int id)
        {
            string uri = $"api/BI/cancel/{id}";
            return this.Get(uri);
        }

        public string DeleteInfo(int id)
        {
            string uri = $"api/BI/delete/{id}";
            return this.Get(uri);
        }

        public string GetInfoPage(string key, int index, int size)
        {
            key = string.IsNullOrEmpty(key) ? "none" : key;
            string uri = $"api/BI/page/{key}/{index}/{size}";
            return this.Get(uri);
        }

        public string PublishState(int id)
        {
            string uri = $"api/BI/publish/{id}";
            return this.Get(uri);
        }

        public string RevokeState(int id)
        {
            string uri = $"api/BI/revoke/{id}";
            return this.Get(uri);
        }

        public string UpdateInfo(string user_json)
        {
            string uri = "api/BI/update";
            StringContent content = new StringContent(user_json);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }
    }
}
