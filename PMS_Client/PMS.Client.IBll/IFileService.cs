using PMS.Client.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IBll
{
    public interface IFileService
    {
        IEnumerable<FileEntities> GetUpgradeFiles(string key = "");

        void UploadFile(string file, string save_path, Action<int> progress, Action<AsyncCompletedEventArgs> completed);

        int DeleteFile(string fileName);
    }
}
