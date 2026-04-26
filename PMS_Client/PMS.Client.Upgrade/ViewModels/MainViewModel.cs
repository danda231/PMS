using PMS.Client.Upgrade.Base;
using PMS.Client.Upgrade.DataAccess;
using PMS.Client.Upgrade.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace PMS.Client.Upgrade.ViewModels
{
    public class MainViewModel : NotifyPropertyBase
    {
        public int TotalCount { get; set; }
        private int _completed;

        public int Completed
        {
            get { return _completed; }
            set { SetProperty(ref _completed, value); }
        }

        public ICommand StartCommand {  get; set; }
        
        public ObservableCollection<FileModel> FileList { get; set; } = 
            new ObservableCollection<FileModel>();

        public MainViewModel(string[] files)
        {
            TotalCount = files.Length;
            Completed = 0;
            StartCommand = new Command(DoStart);
            for (int i = 1; i <= files.Length; i++)
            {
                var file = files[i - 1];
                string[] info = file.Split("|");
                int.TryParse(info[2], out int len);
                FileList.Add(new FileModel
                {
                    Index = i,
                    FileName = info[0],
                    FilePath = info[1],
                    FileLenght = len,
                    FileMd5 = info[3]
                });
            }
            
        }
        
        private void DoStart(object? obj)
        {
            // 开始下载文件
            var file = FileList[Completed];
            this.DoDownLoadFile(file);
        }
        private void DoDownLoadFile(FileModel file)
        {
            string local_file = System.IO.Path.Combine(file.FilePath, file.FileName);
            if (!Directory.Exists(file.FilePath) && !string.IsNullOrEmpty(file.FilePath))
            {
                Directory.CreateDirectory(file.FilePath);
            }

            string path = string.IsNullOrEmpty(file.FilePath) ? "none" : file.FilePath;
            string web_file = path + "/" + file.FileName;
            WebAccess webAccess = new WebAccess();
            webAccess.DownLoadFile(web_file, local_file, completed_ev =>
            {
                if (completed_ev != null && completed_ev.Error != null)
                {
                    // 提示异常
                    file.ErrorMsg = completed_ev.Error.Message;
                    file.State = "异常";
                    file.StateColor = "Red";
                }
                else
                {
                    file.State = "完成";
                    file.StateColor = "Green";
                }
                /// 下载完成回调
                file.HasCompeleted = true;
                file.Progress = 0;
                Completed++;
                if (Completed >= FileList.Count)
                {
                    SaveJson();
                    return;
                }
                this.DoDownLoadFile(FileList[Completed]);
            },
            // 下载进度变化时回调
            (progress, byte_len) =>
            {
                // 更改进度变量
                file.Progress = progress / 100;
                file.CompletedLen = byte_len;
            });
            
            
        }

        private void SaveJson()
        {
            if (FileList.ToList().Exists(f => !f.HasCompeleted)) return;
            // 将文件写入对应json
            string _path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            _path = System.IO.Path.Combine(_path, "PMS");
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            string path_temp = System.IO.Path.Combine(_path, "upgrade_temp.json");
            string json_str = System.Text.Json.JsonSerializer.Serialize(FileList);
            File.WriteAllText(path_temp, json_str);


            string exePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PMS.Client.Initial.exe");
            Process.Start(exePath);
            Application.Current.Shutdown();
        }
    }
}
