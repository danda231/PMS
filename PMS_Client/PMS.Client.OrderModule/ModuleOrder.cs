

using PMS.Client.OrderModule.ViewModels.DialogModels;
using PMS.Client.OrderModule.Views;
using PMS.Client.OrderModule.Views.Dialogs;

namespace PMS.Client.OrderModule
{
    public class ModuleOrder : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<OrderView>();

            containerRegistry.RegisterDialog<ModifyOrderView, ModifyOrderViewModel>();
            containerRegistry.RegisterDialog<ImagePreviewView, ImagePreviewViewModel>();
        }
    }

}
