

using PMS.Client.PropertyModule.ViewModels.DIalogModel;
using PMS.Client.PropertyModule.Views;
using PMS.Client.PropertyModule.Views.Dialog;

namespace PMS.Client.PropertyModule
{
    public class ModuleProperty : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<OwnerView>();

            containerRegistry.RegisterDialog<ModifyOwnerView, ModifyOwnerViewModel>();
            
        }
    }

}
