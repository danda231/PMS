using PMS.Client.Common;
using PMS.Client.IBll;
using PMS.Client.SystemModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.SystemModule.ViewModels.DialogModels
{
    public class ModifyMenuViewModel : DialogViewModelBase
    {
        
        public MenuModel MenuModel { get; set; } = new MenuModel();
        public List<Entities.MenuEntity> ParentNodes { get; set; } = new List<Entities.MenuEntity>();

        IMenuService _menuService;
        public ModifyMenuViewModel(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            var model = parameters.GetValue<MenuModel>("model");
            ParentNodes = parameters.GetValue<List<Entities.MenuEntity>>("parents");
            ParentNodes.Add(new Entities.MenuEntity { MenuHeader = "ROOT", MenuId = "0" });

            if (model == null)
            {
                // 新增菜单
                Title = "新增菜单项";
                MenuModel.ParentId = "0";
                MenuModel.MenuId = "";
            }
            else
            {
                // 修改菜单
                Title = "编辑菜单项";
                MenuModel.MenuId = model.MenuId;
                MenuModel.MenuHeader = model.MenuHeader;
                MenuModel.ParentId = model.ParentId;
                MenuModel.TargetView = model.TargetView;
                MenuModel.MenuIcon = model.MenuIcon;
            }
        }

        public override void DoSave()
        {
            // 新的增加 or 更改老的

            try
            {
                Entities.MenuEntity menuEntity = new Entities.MenuEntity
                {
                    MenuId = MenuModel.MenuId,
                    MenuHeader = MenuModel.MenuHeader,
                    // 把字体字符转成相关的编码  \ue618 => e618
                    MenuIcon = ((int)MenuModel.MenuIcon.ToArray()[0]).ToString("x"),
                    TargetView = MenuModel.TargetView,
                    ParentId = MenuModel.ParentId,
                    State = 1
                };

                _menuService.UpdateMenu(menuEntity);

                base.DoSave();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
