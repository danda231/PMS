using PMS.Client.Upgrade.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.Upgrade.Models
{
    public class FileModel : NotifyPropertyBase
    {
        // 界面中有些列表需要有序号
        [JsonIgnore]
        public int Index { get; set; }
        [JsonPropertyName("fileName")]
        public string FileName { get; set; }
        [JsonPropertyName("filePath")]
        public string FilePath { get; set; }
        [JsonPropertyName("fileMd5")]
        public string FileMd5 { get; set; }// 更新完成后是不是需要做本地缓存的更新
        [JsonPropertyName("length")]
        public int FileLenght { get; set; }

       


        private string _state;
        [JsonIgnore]
        public string State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        private double _progress;
        [JsonIgnore]
        public double Progress
        {
            get { return _progress; }
            set { SetProperty(ref _progress, value); }
        }

        private string _errorMsg;
        private long _completedLen;
        /// <summary>
        /// 已下载完成的文件数
        /// </summary>
        [JsonIgnore]
        public long CompletedLen
        {
            get { return _completedLen; }
            set { SetProperty<long>(ref _completedLen, value); }
        }

        [JsonIgnore]
        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { SetProperty(ref _errorMsg, value); }
        }

        private bool _hasError;
        [JsonIgnore]
        public bool HasError
        {
            get { return _hasError; }
            set { SetProperty<bool>(ref _hasError, value); }
        }

        private bool _hasCompeleted;
        [JsonIgnore]
        public bool HasCompeleted
        {
            get { return _hasCompeleted; }
            set { SetProperty<bool>(ref _hasCompeleted, value); }
        }
        
        private string _stateColor;
        [JsonIgnore]
        public string StateColor
        {
            get { return _stateColor; }
            set { SetProperty<string>(ref _stateColor, value); }
        }
    }
}
