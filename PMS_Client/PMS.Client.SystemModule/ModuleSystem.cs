
using PMS.Client.SystemModule.ViewModels.DialogModels;
using PMS.Client.SystemModule.Views;
using PMS.Client.SystemModule.Views.Dialog;

namespace PMS.Client.SystemModule
{
    public class ModuleSystem : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.MenuView> ();
            containerRegistry.RegisterForNavigation<UploadView>();
            containerRegistry.RegisterForNavigation<UserView>();
            containerRegistry.RegisterForNavigation<RoleView>();
            containerRegistry.RegisterForNavigation<BaseInfoView>();

            // Dialog
            containerRegistry.RegisterDialog<ModifyMenuView, ModifyMenuViewModel>();
            containerRegistry.RegisterDialog<ModifyUserView, ModifyUserViewModel>();
            containerRegistry.RegisterDialog<SelectRoleView, SelectRoleViewModel>();
            containerRegistry.RegisterDialog<ModifyRoleView, ModifyRoleViewModel>();
            containerRegistry.RegisterDialog<SelectUserView, SelectUserViewModel>();
            containerRegistry.RegisterDialog<ModifyInfoView, ModifyInfoViewModel>();

        }
    }
}
