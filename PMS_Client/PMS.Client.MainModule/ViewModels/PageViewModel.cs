using PMS.Client.MainModule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PMS.Client.MainModule.ViewModels
{
    public class PageViewModel : INavigationAware
    {
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 传递菜单数据
            var menus = navigationContext.Parameters.GetValue<List<Entities.MenuEntity>>("menu");

            Menus.Clear();
            foreach (var menu in menus)
            {
                // 转义字符串 防止\u 形式
                string icon = ((char)int.Parse(menu.MenuIcon, NumberStyles.HexNumber)).ToString();
                Menus.Add(new MenuModel
                {
                    MenuHeader = menu.MenuHeader,
                    MenuIcon = icon,
                    TargetView = menu.TargetView,
                });
            }

        }

        public ObservableCollection<MenuModel> Menus { get; set; } =
            new ObservableCollection<MenuModel>();

        public DelegateCommand<string> MenuCommand { get; set; }

        IRegionManager _regionManager;
        public PageViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            MenuCommand = new DelegateCommand<string>(DoMenu);
        }
        private void DoMenu(string page)
        {
            _regionManager.RequestNavigate("PageRegion", page);
        }
    }
}
