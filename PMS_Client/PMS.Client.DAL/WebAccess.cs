using PMS.Client.Entities;
using PMS.Client.IDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Policy;
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

        public async Task UploadAsync(string uri, string file,
            Action<int> progress, Action<AsyncCompletedEventArgs> completed,
            Dictionary<string, object> headers = null)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Authorization", "Bearer " + _globalValues.Token);

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        // 
                        client.Headers.Add(item.Key, item.Value.ToString());
                    }
                }
                client.UploadProgressChanged += (se, ev) => progress?.Invoke(ev.ProgressPercentage);
                client.UploadFileCompleted += (se, ev) => completed?.Invoke(ev);

                client.UploadFileAsync(new Uri(HostName + uri), file);
            }
        }

        public void Upload(string uri, string file, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Authorization", "Bearer " + _globalValues.Token);

                client.Headers.Add("file_name", fileName);


                client.UploadFile(new Uri(HostName + uri), file);
            }
        }

        public class ProgressableStreamContent : HttpContent
        {
            private const int defaultBufferSize = 4096;

            private Stream content;
            private int bufferSize;
            private Action<int> progress;

            public ProgressableStreamContent(Stream content, int bufferSize, Action<int> progress)
            {
                this.content = content;
                this.bufferSize = bufferSize;
                this.progress = progress;
            }

            protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
            {
                var buffer = new byte[bufferSize];
                long size = content.Length;
                long uploaded = 0;

                int read;
                while ((read = await content.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    uploaded += read;
                    await stream.WriteAsync(buffer, 0, read);

                    int percent = (int)((uploaded * 100L) / size);
                    progress?.Invoke(percent);
                }
            }

            protected override bool TryComputeLength(out long length)
            {
                length = content.Length;
                return true;
            }
        }
    }
}
