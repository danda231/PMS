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
    public class OwnerAccess : WebAccess, IOwnerAccess
    {
        public OwnerAccess(GlobalValues globalValues) : base(globalValues)
        {
        }

        public string DeleteOwners(int id)
        {
            string uri = $"api/Owner/delete/{id}";
            return this.Get(uri);
        }

        public string GetBuildings()
        {
            string uri = "api/Owner/buildings";
            return this.Get(uri);
        }

        public string GetOwners(string paramsJson, int index, int size)
        {
            string uri = $"api/Owner/page/{index}/{size}";
            StringContent content = new StringContent(paramsJson);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }

        public string GetQuareters()
        {
            string uri = "api/Owner/quarters";
            return this.Get(uri);
        }

        public string UpdateOwners(string owner_Json)
        {
            string uri = $"api/Owner/update";
            StringContent content = new StringContent(owner_Json);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.Post(uri, content);
        }
    }
}
