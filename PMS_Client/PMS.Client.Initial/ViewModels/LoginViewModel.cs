using PMS.Client.Entities;
using PMS.Client.IBll;
using System.Diagnostics;
using System.IO;

namespace PMS.Client.Initial.ViewMmodels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public string UserName { get; set; } = "admin";
        public string Password { get; set; } = "123456";

        private bool _state;
        public bool State
        {
            get { return _state; }
            set { SetProperty<bool>(ref _state, value); }
        }
        public DelegateCommand LoginCommand { get; set; }

        public DialogCloseListener RequestClose { get; set; }
        IUserService _userService;

        public LoginViewModel(IUserService userService, IFileService fileService)
        {
            _userService = userService;
            LoginCommand = new DelegateCommand(DoLogin);

            /// 检查更新
            /// 获取列表
            var files_server = fileService.GetUpgradeFiles().ToList();
            // 获取文件
            string json_str = File.ReadAllText("upgrade_temp.json");
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
                    update_file.Add(sf.fileName + "|" + sf.filePath + "|" + sf.length);
                }

            }
            // 本地无，服务有，下载服务的


            // 下载相关文件
            if (update_file.Count > 0)
            {
                // 启动更新 启动一个进行进行隔离更新
                Process.Start("PMS.Client.Upgrade.exe", update_file);

                //json_str = System.Text.Json.JsonSerializer.Serialize(update_file);
                //File.WriteAllText("upgrade_temp.json", json_str);

                //Application.Current.Shutdown();
                System.Environment.Exit(0);
            }
        }
        // 提交用户名密码 获取状态
        private void DoLogin()
        {
            State = _userService.Login(UserName, Password);
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
