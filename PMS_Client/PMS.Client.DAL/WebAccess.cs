using PMS.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.DAL
{
    public class WebAccess : IWebAccess
    {
        public string HostName { get; set; } = "http://localhost:5115/";

        public string Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client
                    .GetAsync(HostName + url)
                    .GetAwaiter().GetResult();

                string res = response.Content
                    .ReadAsStringAsync()
                    .GetAwaiter().GetResult();
                return res;
            }
            
        }
    }
}
