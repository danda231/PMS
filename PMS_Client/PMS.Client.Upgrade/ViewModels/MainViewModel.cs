using PMS.Client.Upgrade.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Upgrade.ViewModels
{
    public class MainViewModel
    {

        public ObservableCollection<FileModel> FileList { get; set; } = 
            new ObservableCollection<FileModel>();

        public MainViewModel(string[] files)
        {
            foreach (var file in files)
            {
                string[] info = file.Split("|");
                int.TryParse(info[2], out int len);
                FileList.Add(new FileModel
                {
                    FileName = info[0],
                    FilePath = info[1],
                    FileLenght = len,
                    FileMd5 = ""
                });
            }
        }

    }
}
