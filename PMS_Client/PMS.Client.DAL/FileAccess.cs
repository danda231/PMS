using PMS.Client.Entities;
using PMS.Client.IDAL;
using PMS.Client.Utils;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace PMS.Client.DAL
{
    public class FileAccess : WebAccess, IFileAccess
    {
        public FileAccess(GlobalValues globalValues) : base(globalValues)
        {
        }

        public string DeleteFile(string file_name)
        {
            string uri = "api/File/delete";
            Dictionary<string, HttpContent> datas = new Dictionary<string, HttpContent>();
            datas.Add("filename", new StringContent(file_name));


            var mp = this.GetFormData(datas);

            return this.Post(uri, mp);
        }

        public string GetUpgradeFiles(string key)
        {
            key = string.IsNullOrEmpty(key) ? "none" : key;
            string uri = $"api/File/list/{key}";


            return this.Get(uri);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file">将要上传文件的完整路径</param>
        /// <param name="save_path">文件存放的相对路径</param>
        /// <param name="progress">上传的进度变化</param>
        /// <param name="completed">是否成功上传</param>
        /// <exception cref="NotImplementedException"></exception>
        public void UploadFile(string file, string save_path, 
            Action<int> progress, Action<AsyncCompletedEventArgs> completed)
        {
            string uri = "api/File/upload";

            // 地址参数
            Dictionary<string, object> datas = new Dictionary<string, object>();
            datas.Add("Md5", GetFileMd5(file));
            datas.Add("file_path", save_path);

            this.UploadAsync(uri, file,progress,completed, datas);
        }

        private string GetFileMd5(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                    throw new Exception("文件不存在");

                FileStream file = new FileStream(fileName, System.IO.FileMode.Open);
                var md5 = MD5.Create();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetFileMd5() fail,error:" + ex.Message);
            }
        }
    }

}
