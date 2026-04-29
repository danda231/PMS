using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.Initial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace PMS.Client.Initial.ViewModels
{
    internal class MainViewModel
    {
        private readonly IDialogService _dialogService;

        public List<MenuModel> Menus { get; set; } = new List<MenuModel>();
        private Entities.MenuEntity[] menus;
        IRegionManager _regionManager;
        Entities.EmployEntity _currentUser;

        public DelegateCommand WorkbenchCommand { get; set; }
        public DelegateCommand<string> PageSwitchCommand { get; set; }

        // 打开登录界面
        public MainViewModel(
            IDialogService dialogService, 
            IMenuService menuService,
            IRegionManager regionManager)
        {
            _dialogService = dialogService;
            _regionManager = regionManager;

            _dialogService.ShowDialog("LoginView", result =>
            {
                if (result.Result != ButtonResult.OK)
                {
                    Application.Current.Shutdown();
                }
                _currentUser = result.Parameters.GetValue<Entities.EmployEntity>("user");



                //// 延迟到 UI 渲染后执行
                //Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                //{
                //    ShowWorkbench();
                //}), DispatcherPriority.Loaded);
            });


            PageSwitchCommand = new DelegateCommand<string>(DoPageSwitch);
            WorkbenchCommand = new DelegateCommand(ShowWorkbench);
            // 获取菜单栏信息
            menus = menuService.GetAllMenus().ToArray();

            foreach(var me in menus.Where(m => m.ParentId == "0"))
            {
                Menus.Add(new MenuModel
                {
                    MenuId = me.MenuId,
                    MenuHeader = me.MenuHeader,
                });
            }
            
            if(menus.Length > 0)
                Menus[0].IsSelected = true;
            


        }

        private void ShowWorkbench()
        {
            NavigationParameters nps = new NavigationParameters();
            nps.Add("user", _currentUser);
            // Loaded时触发
            _regionManager.RequestNavigate("MainRegion", "DashboardView", nps);
        }

        private void DoPageSwitch(string id)
        {
            if(string.Equals(id, "-1"))
                ShowWorkbench();
            else
            {
                var ms = menus.Where(m => m.ParentId == id).ToList();
                NavigationParameters nps = new NavigationParameters();
                nps.Add("menu", ms);
                _regionManager.RequestNavigate("MainRegion", "PageView", nps);
            }
        }

        
    }
}
