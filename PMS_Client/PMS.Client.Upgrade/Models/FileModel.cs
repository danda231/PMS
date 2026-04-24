using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Upgrade.Models
{
    public class FileModel : INotifyPropertyChanged
    {
        // 界面中有些列表需要有序号
        public int Index { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileMd5 { get; set; }// 更新完成后是不是需要做本地缓存的更新
        public int FileLenght { get; set; }

        private int _completedLen;

        public int CompletedLen
        {
            get { return _completedLen; }
            set { SetProperty<int>(ref _completedLen, value); }
        }


        private string _state;

        public string State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        private double _progress;

        public double Progress
        {
            get { return _progress; }
            set { SetProperty(ref _progress, value); }
        }

        private string _errorMsg;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void SetProperty<T>(ref T field, T value, [CallerMemberName] string propName = "")
        {
            if(field == null || !field.Equals(value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            } 
        }

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { SetProperty(ref _errorMsg, value); }
        }
    }
}
