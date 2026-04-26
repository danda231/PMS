using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Upgrade.DataAccess
{
    public class WebAccess
    {
        // 下载进度
        WebClient webClient = new WebClient();
        public void DownLoadFile(string web_file, string local_file, 
            Action<AsyncCompletedEventArgs> completed,
            Action<int, long> progress)
        {
            // 下载完成信息
            webClient.DownloadFileCompleted += (se, ev) =>
            {
                completed?.Invoke(ev); // 通过ev知道异常信息
            };
            // 下载进度信息
            webClient.DownloadProgressChanged += (se, ev) =>
            {
                progress?.Invoke(ev.ProgressPercentage, ev.BytesReceived);
            };
            webClient.DownloadFileAsync(new Uri($"http://localhost:5115/api/File/download/{web_file}"), local_file);
        }
    }
}
