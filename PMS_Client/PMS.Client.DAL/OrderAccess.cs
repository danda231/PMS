using PMS.Client.Entities;
using PMS.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PMS.Client.DAL
{
    public class OrderAccess : WebAccess, IOrderAccess
    {
        public OrderAccess(GlobalValues globalValues) : base(globalValues)
        {
        }

        public string ChangeState(string id, int state)
        {
            string uri = $"api/Order/state/{id}/{state}";
            return this.Get(uri);
        }

        public string DeleteOrders(string id)
        {
            string uri = $"/api/Order/delete/{id}";
            return this.Get(uri);
        }

        public string GetOrders(string key, int pageIndex, int pageSize)
        {
            key = string.IsNullOrEmpty(key) ? "none" : key;
            string uri = $"api/Order/page/{key}/{pageIndex}/{pageSize}";
            return this.Get(uri);
        }

        public string UpdateOrders(string json)
        {
            string uri = "api/Order/update";
            StringContent content = new StringContent(json);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }
    }
}
