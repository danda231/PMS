
using PMS.Client.MainModule.Views;
using PMS.Client.MainModule.ViewModels;
using PMS.Client.MainModule.ViewModels.Dialogs;
using PMS.Client.MainModule.Views.Dialogs;
using Prism.Ioc;
using Prism.Modularity;

namespace PMS.Client.MainModule
{
    public class ModuleMain : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.DashboardView>();
            containerRegistry.RegisterForNavigation<PageView>();

            containerRegistry.RegisterDialog<ModifyPasswordView, ModifyPasswordModel>();
            
        }
    }

}
