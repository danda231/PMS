using PMS.Client.Common;
using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.SystemModule.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.SystemModule.ViewModels
{
    public class UserViewModel : PageViewModelBase
    {
        public ObservableCollection<UserModel> Users { get; set; } = new ObservableCollection<UserModel>();
        IUserService _userService;
        IRoleService _roleService;
        IDialogService _dialogService;
        IEventAggregator _eventAggregator;

        public DelegateCommand<object> LockUserCommand { get; set; }
        public DelegateCommand<object> SelectRoleCommand { get; set; }
        public DelegateCommand<object> ResetPasswordCommand { get; set; }

        public UserViewModel(IRegionManager regionManager,
            IUserService userService,
            IRoleService roleService,
            IDialogService dialogService,
            IEventAggregator eventAggregator) : base(regionManager)
        {
            PageTitle = "系统用户管理";
            _userService = userService;
            _roleService = roleService;
            _dialogService = dialogService;
            _eventAggregator = eventAggregator;

            LockUserCommand = new DelegateCommand<object>(DoLockUser);
            SelectRoleCommand = new DelegateCommand<object>(DoSelectRole);
            ResetPasswordCommand = new DelegateCommand<object>(DoResetPassword);

            this.Refresh();
        }

        private void DoResetPassword(object obj)
        {
            try
            {
                if (MessageBox.Show("是否重置当前用户密码？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var m = obj as UserModel;
                    _userService.ResetPassword(m.UserId);
                    MessageBox.Show("重置完成！");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DoSelectRole(object obj)
        {
            DialogParameters ps = new DialogParameters();
            ps.Add("model", obj);
            _dialogService.ShowDialog("SelectRoleView", ps, result =>
            {
                if(result.Result == ButtonResult.OK)
                {
                    this.Refresh();
                }
            });
        }

        private void DoLockUser(object obj)
        {
            try
            {
                var ui = obj as UserModel;
                int status = 0;
                if(ui.Status == 1)
                {
                    if (MessageBox.Show("确定锁定此此项？", "提示", MessageBoxButton.YesNo) ==
                    MessageBoxResult.Yes)
                    {
                        _userService.LockUser(ui.UserId, 0);
                    }
                }
                else
                {
                    status = 1;
                    _userService.LockUser(ui.UserId, 1);
                }
                MessageBox.Show("操作完成", "提示");
                ui.Status = status;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        public override void DoDelete(object model)
        {
            try
            {
                if (MessageBox.Show("确定删除此项？", "提示", MessageBoxButton.YesNo) ==
                    MessageBoxResult.Yes)
                {
                    _userService.DeleteUser((model as UserModel).UserId);

                    MessageBox.Show("删除成功", "提示");
                    Users.Remove(model as UserModel);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        public override void DoModify(object model)
        {
            DialogParameters ps = new DialogParameters();
            ps.Add("model", model);
            _dialogService.ShowDialog("ModifyUserView", ps, result =>
            {
                // 如果返回的OK，那么刷新页面
                if(result.Result == ButtonResult.OK)
                {
                    this.Refresh();
                }
            });
        }
        public override void Refresh()
        {
            Users.Clear();
            _eventAggregator.GetEvent<LoadingEvent>()
                .Publish("正在加载用户....");
            Task.Run(async() =>
            {
                try
                {
                    var users = _userService.GetUsers(SearchKey).ToList();
                    int index = 1;
                    foreach (var user in users)
                    {
                        UserModel model = new UserModel
                        {
                            Index = index++,
                            UserId = user.EId,
                            UserName = user.UserName,
                            RealName = user.RealName,
                            UserIcon = "http://localhost:5115/api/File/img/" + user.EIcon,
                            Address = user.Address,
                            Age = user.Age,
                            Password = user.Password,
                            Gender = user.Gender,
                            Email = user.Email,
                            Status = user.Status,
                            Phone = user.Phone,

                            LockButtonText = user.Status == 1 ? "锁定" : "启用"
                        };

                        // 根据用户的角色ID进行信息获取
                        int[] roles_ids = user.Roles.Select(r => r.RoleId).ToArray();
                        var roles = _roleService.GetRoleByIds(roles_ids);
                        model.Roles = roles.Select(r => new RoleModel
                        {
                            RoleId = r.RoleId,
                            RoleName = r.RoleName,
                        }).ToList();
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Users.Add(model);
                        });
                    }
                }catch (Exception ex)
                {

                }
                finally
                {
                    _eventAggregator.GetEvent<LoadingEvent>().Publish("");
                }
            });
            
        }
    }
}
