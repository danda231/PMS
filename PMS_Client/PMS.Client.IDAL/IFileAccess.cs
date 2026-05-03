using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IDAL
{
    public interface IFileAccess
    {
        string GetUpgradeFiles(string key);

        void UploadFile(string file, string save_path, Action<int> progress, Action<AsyncCompletedEventArgs> completed);

        string DeleteFile(string file_name);
    }
}
