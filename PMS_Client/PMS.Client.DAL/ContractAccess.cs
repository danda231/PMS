using PMS.Client.Entities;
using PMS.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.DAL
{
    public class ContractAccess : WebAccess, IContractAccess
    {
        public ContractAccess(GlobalValues globalValues) : base(globalValues)
        {
        }

        public string GetDatas(string key, string start, string end, int index, int size)
        {
            string uri = $"api/Contract/page/{key}/{start}/{end}/{index}/{size}";
            return this.Get(uri);
        }

        public string DeleteInfo(int id)
        {
            string uri = $"api/Contract/delete/{id}";
            return this.Get(uri);
        }

        public string UpdateInfo(string json)
        {
            string uri = $"api/Contract/update";
            StringContent content = new StringContent(json);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }
        public string ChangeState(int id, int state)
        {
            string uri = $"api/Contract/state/{id}/{state}";
            return this.Get(uri);
        }

        public string Execute(string json)
        {
            string uri = $"api/Contract/execute";
            StringContent content = new StringContent(json);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }

        public string Archived(string json)
        {
            string uri = $"api/Contract/archived";
            StringContent content = new StringContent(json);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }
    }
}
