using PMS.Client.Common;
using PMS.Client.IBll;
using PMS.Client.SystemModule.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.SystemModule.ViewModels
{
    public class MenuViewModel : PageViewModelBase
    {
        public ObservableCollection<MenuModel> Menus { get; set; } =
            new ObservableCollection<MenuModel>();
        List<Entities.MenuEntity> origMenus;

        IMenuService _menuService;
        IDialogService _dialogService;
        IEventAggregator _eventAggregator;

        public MenuViewModel(IRegionManager regionManager,
            IMenuService menuService,
            IDialogService dialogService,
            IEventAggregator eventAggregator) : base(regionManager, eventAggregator) 
        {
            this.PageTitle = "菜单数据维护";

            _dialogService = dialogService;
            _menuService = menuService;
            _eventAggregator = eventAggregator;

            Refresh();

        }

        public override void Refresh()
        {
            Menus.Clear();
            origMenus = _menuService.GetAllMenus(SearchKey).ToList();
            this.FillMenus(Menus, null, origMenus);
        }

        public void FillMenus(ObservableCollection<MenuModel> menus,
            MenuModel parent, List<Entities.MenuEntity> origMenus, bool expandedNode = true)
        {
            var sub = origMenus.Where(m => m.MenuId != "-1" &&
                    m.ParentId == (parent == null ? "0" : parent.MenuId)).ToList();

            if (sub.Count() > 0)
            {
                foreach (Entities.MenuEntity item in sub)
                {
                    string icon = "";
                    if (!string.IsNullOrEmpty(item.MenuIcon))
                        icon = ((char)int.Parse(item.MenuIcon, NumberStyles.HexNumber))
                                    .ToString();
                    MenuModel model = new MenuModel
                    {
                        MenuId = item.MenuId.ToString(),
                        MenuHeader = item.MenuHeader,
                        MenuIcon = icon,
                        TargetView = item.TargetView,
                        ParentId = (parent == null ? "0" : parent.MenuId),
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

        public override void DoModify(object model)
        {
            DialogParameters ps = new DialogParameters();
            ps.Add("model", model);

            // 获取所有一级菜单
            var pat = origMenus.Where(m => m.ParentId == "0" && m.MenuId != "-1").ToList();
            ps.Add("parents", pat);
            _dialogService.ShowDialog("ModifyMenuView", ps, result =>
            {
                if(result.Result == ButtonResult.OK)
                {
                    this.Refresh();
                    // 重启系统
                }
            });
        }

        public override void DoDelete(object model)
        {
            try
            {
                if(MessageBox.Show("是否删除此项？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _menuService.DeleteMenu((model as MenuModel).MenuId);
                    MessageBox.Show("删除完成", "提示");

                    this.Refresh();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            base.DoDelete(model);
        }
    }
}
