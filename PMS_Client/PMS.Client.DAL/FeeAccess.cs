using PMS.Client.Entities;
using PMS.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.DAL
{
    public class FeeAccess : WebAccess, IFeeAccess
    {
        public FeeAccess(GlobalValues globalValues) : base(globalValues)
        {
        }

        public string ChangeState(int id, int state)
        {
            string uri = $"api/Fee/state/{id}/{state}";
            return this.Get(uri);
        }

        public string DeleteFee(int id)
        {
            string uri = $"api/Fee/delete/{id}";
            return this.Get(uri);
        }

        public string GetFeeModes()
        {
            string uri = "api/Fee/feemodel";
            return this.Get(uri);
        }

        public string GetFees(string key, int pageIndex, int pageSize)
        {
            key = string.IsNullOrEmpty(key) ? "none" : key;
            string uri = $"api/Fee/page/{key}/{pageIndex}/{pageSize}";
            return this.Get(uri);
        }

        public string UpdateFee(string fee_Json)
        {
            string uri = "api/Fee/update";
            StringContent content = new StringContent(fee_Json);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }
    }
}
