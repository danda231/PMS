using PMS.Client.Entities;
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

        private GlobalValues _globalValues;

        public WebAccess(GlobalValues globalValues)
        {
            _globalValues = globalValues;
        }
        public string Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(HostName);

                // 装上请求Token
                if (!string.IsNullOrEmpty(_globalValues.Token))
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _globalValues.Token);

                var response = client
                    .GetAsync(url)
                    .GetAwaiter().GetResult();

                string res = response.Content
                    .ReadAsStringAsync()
                    .GetAwaiter().GetResult();
                return res;
            }
            
        }
        public string Post(string url,HttpContent content)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(HostName);
                // 装上请求Token
                if (!string.IsNullOrEmpty(_globalValues.Token))
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _globalValues.Token);
                var response = client
                    .PostAsync(url, content)
                    .GetAwaiter().GetResult();

                string res = response.Content
                    .ReadAsStringAsync()
                    .GetAwaiter().GetResult();
                return res;
            }
        }

        public MultipartFormDataContent GetFormData(Dictionary<string, HttpContent> contents)
        {
            var postContent = new MultipartFormDataContent();
            string boundary = string.Format("--{0}", DateTime.Now.Ticks.ToString("x"));
            postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");
            foreach(var item in contents)
            {
                // 添加字典的键值对
                postContent.Add(item.Value, item.Key);
            }
            return postContent;
        }
    }
}
