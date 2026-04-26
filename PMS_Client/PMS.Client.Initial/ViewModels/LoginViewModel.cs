using PMS.Client.Entities;
using PMS.Client.IBll;
using System.Diagnostics;
using System.IO;
using System.Printing.IndexedProperties;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace PMS.Client.Initial.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {

        public string Title => "登录";
        public string UserName { get; set; } = "admin";
        public string Password { get; set; } = "12345";
        private string _errorInfo;

        public string ErrorInfo
        {
            get { return _errorInfo; }
            set { SetProperty<string>(ref _errorInfo, value); }
        }

        private bool _state;
        public bool State
        {
            get { return _state; }
            set { SetProperty<bool>(ref _state, value); }
        }
        public DelegateCommand LoginCommand { get; set; }

        public DelegateCommand<object> LoadedCommand { get; set; }
        public DialogCloseListener RequestClose { get; set; }
        IUserService _userService;
        IFileService _fileService;

        public LoginViewModel(IUserService userService, IFileService fileService)
        {
            _userService = userService;
            _fileService = fileService;
            // 事件初始化
            LoginCommand = new DelegateCommand(DoLogin);
            
            LoadedCommand = new DelegateCommand<object>(obj =>
            {
                Task.Run(async() =>
                {
                    FrameworkElement element = obj as FrameworkElement;
                    if (element == null) return;
                    /// 检查更新
                    /// 获取列表
                    var files_server = _fileService.GetUpgradeFiles().ToList();

                    // 获取文件
                    string path_temp = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
                    path_temp = System.IO.Path.Combine(path_temp, "PMS", "upgrade_temp.json");
                    string json_str = "";
                    if (File.Exists(path_temp))
                        json_str = File.ReadAllText(path_temp);
                    if (string.IsNullOrEmpty(json_str)) json_str = "[]";
                    List<FileEntities> files_local = System.Text.Json
                        .JsonSerializer.Deserialize<List<FileEntities>>(json_str);
                    // 本地有，服务表有，比对md5，不一致要更新

                    // 本地有，服务无，删除
                    foreach (var sf in files_local)
                    {
                        if (!files_server.Exists(f => f.fileName == sf.fileName))
                        {
                            //File.Delete(sf.filePath + "/" +  sf.fileName);
                        }
                    }

                    List<string> update_file = new List<string>();
                    foreach (var sf in files_server)
                    {
                        if (files_local.Exists(f => f.fileName == sf.fileName && f.fileMd5 != sf.fileMd5) ||
                            !files_local.Exists(f => f.fileName == sf.fileName))
                        {
                            // 需要下载
                            update_file.Add(sf.fileName + "|" + sf.filePath + "|" + sf.length + "|" + sf.fileMd5);
                        }

                    }
                    // 本地无，服务有，下载服务的

                    // 执行更新逻辑
                    if (update_file.Count > 0)
                    {
                        // 启动更新 启动一个进行进行隔离更新
                        Process.Start("PMS.Client.Upgrade.exe", update_file);

                        //json_str = System.Text.Json.JsonSerializer.Serialize(update_file);
                        //File.WriteAllText("upgrade_temp.json", json_str);

                        Application.Current.Dispatcher.Invoke(new Action(() => {
                            System.Environment.Exit(0);
                        }));
                        
                    }
                    await Task.Delay(2000);
                    /// 显示login界面
                    Application.Current.Dispatcher.Invoke(() => {
                        
                        VisualStateManager.GoToElementState(element, "ShowLoginState", true);
                    });
                });
            });

        }
        // 提交用户名密码 获取状态
        private void DoLogin()
        {
            try
            {
                // 将Entity => model
                var user = _userService.Login(UserName, Password);

                RequestClose.Invoke(new DialogResult(ButtonResult.OK));
                // 成功登录
            }
            catch (Exception ex) { 
                this.ErrorInfo = ex.Message;
            }
            
        }



        bool IDialogAware.CanCloseDialog()
        {
            return true;
        }

        void IDialogAware.OnDialogClosed()
        {

        }

        void IDialogAware.OnDialogOpened(IDialogParameters parameters)
        {

        }
        


    }
}
