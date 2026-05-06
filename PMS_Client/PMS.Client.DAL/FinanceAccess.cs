using PMS.Client.Entities;
using PMS.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.DAL
{
    public class FinanceAccess : WebAccess, IFinanceAccess
    {
        public FinanceAccess(GlobalValues globalValues) : base(globalValues)
        {
        }

        public string ChangeState(int id, int state)
        {
            string uri = $"api/Finance/state/{id}/{state}";
            return this.Get(uri);
        }

        public string DeleteInfo(int id)
        {
            string uri = $"api/Finance/delete/{id}";
            return this.Get(uri);
        }

        public string GetDatas(string key, string start, string end, int index, int size)
        {
            string uri = $"api/Finance/page/{key}/{start}/{end}/{index}/{size}";
            return this.Get(uri);
        }

        public string UpdateInfo(string json)
        {
            string uri = $"api/Finance/update";
            StringContent content = new StringContent(json);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }
    }
}
