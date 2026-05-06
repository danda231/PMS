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
using System.Windows.Controls;

namespace PMS.Client.SystemModule.ViewModels
{
    public class RoleViewModel : PageViewModelBase
    {

        public ObservableCollection<RoleModel> RoleList { get; set; } = 
            new ObservableCollection<RoleModel>();

        public ObservableCollection<UserModel> Users { get; set; } =
            new ObservableCollection<UserModel>();

        public DelegateCommand<MenuModel> SelectMenuCommand { get; set; }
        public DelegateCommand<UserModel> DeleteUserCommand { get; set; }
        public DelegateCommand SelectUserCommand { get; set; }

        private RoleModel _currentRole;
        public RoleModel CurrentRole {
            get {  return _currentRole; }
            set 
            {
                SetProperty<RoleModel>(ref _currentRole, value, () =>
                {
                    if (value == null) return;
                    _rid = value.RoleId;
                    // 选择当前权限组
                    SetMenuStatus(Menus, value.MenuIds);

                    LoadUsers(value.UserIds);
                });  
            }    
        }
        public ObservableCollection<MenuModel> Menus { get; set; } = new ObservableCollection<MenuModel>();

        IEventAggregator _eventAggregator;
        IRoleService _roleService;
        IDialogService _dialogService;
        IMenuService _menuService;
        IUserService _userService;
        // 刷新定位
        int _rid = 0;

        public RoleViewModel(IRegionManager regionManager,
            IEventAggregator eventAggregator,
            IRoleService roleService,
            IDialogService dialogService,
            IMenuService menuService,
            IUserService userService) : base(regionManager, eventAggregator)
        {
            this.PageTitle = "角色权限组";
            _eventAggregator = eventAggregator;
            _roleService = roleService;
            _dialogService = dialogService;
            _menuService = menuService;
            _userService = userService;

            SelectMenuCommand = new DelegateCommand<MenuModel>(DoSelectMenu);
            SelectUserCommand = new DelegateCommand(DoSelectUser);
            DeleteUserCommand = new DelegateCommand<UserModel>(DoDeleteUser);


            this.Refresh();
        }

        private void DoDeleteUser(UserModel model)
        {
            try
            {
                if(MessageBox.Show("是否确定从当前角色权限组删除此用户？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var role = _roleService.DeleteRoleUsers(model.UserId, CurrentRole.RoleId);

                    MessageBox.Show("删除完成", "提示");
                    Users.Remove(model);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void DoSelectUser()
        {
            
            DialogParameters dps = new DialogParameters();
            dps.Add("uids", CurrentRole.UserIds);
            dps.Add("rid", CurrentRole.RoleId);
            _rid = CurrentRole.RoleId;
            _dialogService.ShowDialog("SelectUserView", dps, result =>
            {
                if(result.Result == ButtonResult.OK)
                {
                    this.Refresh();
                    //_rid = 0;
                }
            });
        }

        private void DoSelectMenu(MenuModel model)
        {
            try
            {
                if (model.IsSelected)
                {
                    CurrentRole.MenuIds.Add(model.MenuId);
                    // 只有两层 暂时这么玩
                    if(model.Children != null && model.Children.Count > 0)
                    {
                        foreach (var child in model.Children)
                        {
                            child.IsSelected = true;
                            CurrentRole.MenuIds.Add(child.MenuId);
                        }
                    }
                    if(model.Parent != null && !model.Parent.IsSelected)
                    {
                        model.Parent.IsSelected = true;
                        CurrentRole.MenuIds.Add(model.Parent.MenuId);
                    }
                }
                else
                {
                    CurrentRole.MenuIds.RemoveAll(mid => mid == model.MenuId);
                    if(model.Children != null && model.Children.Count > 0)
                    {
                        foreach(var child in model.Children)
                        {
                            var mids = model.Children.Select(m =>
                            {
                                m.IsSelected = false;
                                return m.MenuId;
                            }).ToList();
                            CurrentRole.MenuIds.RemoveAll(m => mids.Contains(m));
                        }
                    }
                    if (model.Parent != null && !model.Parent.Children.ToList().Exists(m => m.IsSelected))
                    {
                        model.Parent.IsSelected = false;
                        CurrentRole.MenuIds.RemoveAll(m => m == model.Parent.MenuId);
                    }
                }

                // 根据CurrentRole 进行更新
                var rms = CurrentRole.MenuIds.Select(m => new RoleMenu
                {
                    RoleId = CurrentRole.RoleId,
                    MenuId = int.Parse(m)
                }).ToArray();
                _roleService.UpdateRoleMenus(rms);

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void LoadUsers(List<int> userIds)
        {
            Users.Clear();
            var us = _userService.GetUsersByIds(userIds.ToArray());
            foreach (var user in us)
            {
                Users.Add(new UserModel
                {
                    UserId = user.EId,
                    UserName = user.UserName,
                    RealName = user.RealName,
                    UserIcon = "http://localhost:5115/api/File/img/" + user.EIcon
                });
            }
        }

        public override void DoModify(object model)
        {
            DialogParameters ps = new DialogParameters();
            ps.Add("model", model);
            _dialogService.ShowDialog("ModifyRoleView", ps, result =>
            {
                if(result.Result == ButtonResult.OK)
                {
                    this.Refresh();
                }
            });

        }

        public override void DoDelete(object model)
        {
            try
            {
                if (MessageBox.Show("确定删除此项？", "提示", MessageBoxButton.YesNo) ==
                    MessageBoxResult.Yes)
                {
                    _roleService.DeleteRole((model as RoleModel).RoleId);

                    MessageBox.Show("删除成功", "提示");
                    RoleList.Remove(model as RoleModel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        public override void Refresh()
        {
            RoleList.Clear();
            Menus.Clear();
            _eventAggregator.GetEvent<LoadingEvent>()
                .Publish("正在加载....");
            Task.Run(async () =>
            {
                try
                {
                    var roles = _roleService.GetAllRoles(this.SearchKey);

                    foreach (var role in roles)
                    {
                        var model = new RoleModel
                        {
                            RoleId = role.RoleId,
                            RoleDesc = role.RoleDesc,
                            RoleName = role.RoleName,
                            MenuIds = role.Menus.Select(m => m.MenuId.ToString()).ToList(),
                            UserIds = role.Users.Select(m => m.UserId).ToList(),
                        };
                        
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            RoleList.Add(model);
                            
                        });
                    }
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        var menus = _menuService.GetAllMenus("");
                        // 加载所有菜单
                        FillMenus(Menus, null, menus.ToList());
                        // 定位当前选择的菜单
                        CurrentRole = RoleList.Count > 0 ? (_rid == 0 ? RoleList[0] : RoleList.FirstOrDefault(r => r.RoleId == _rid)) : null;
                    });
                    
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _eventAggregator.GetEvent<LoadingEvent>().Publish("");
                }
            });
        }

        private void FillMenus(ObservableCollection<MenuModel> menus,
            MenuModel parent, List<Entities.MenuEntity> origMenus, bool expandedNode = true)
        {
            var sub = origMenus.Where(m => m.ParentId == (parent == null ? "0" : parent.MenuId))
                .OrderBy(o => o.MenuId).ToList();
            if (sub.Count() > 0)
            {
                foreach (Entities.MenuEntity item in sub)
                {
                    MenuModel model = new MenuModel
                    {
                        MenuId = item.MenuId,
                        MenuHeader = item.MenuHeader,
                        MenuIcon = item.MenuIcon,
                        TargetView = item.TargetView,
                        ParentId = (parent == null ? "-1" : parent.MenuId),
                        IsExpanded = expandedNode,
                        Parent = parent
                    };
                    menus.Add(model);

                    FillMenus(model.Children, model, origMenus);
                }

                if (menus.Count > 0)
                {
                    menus[menus.Count - 1].IsLastChild = true;
                }
            }
        }
        private void SetMenuStatus(ObservableCollection<MenuModel> menus, List<string> mids)
        {
            foreach(var item in menus)
            {
                item.IsSelected = mids.Contains(item.MenuId);

                if(item.Children != null && item.Children.Count > 0)
                {
                    SetMenuStatus(item.Children, mids);
                }

            }
        }
    }
}
