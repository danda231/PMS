
using PMS.Client.FeeModule.ViewModels.DialogModels;
using PMS.Client.FeeModule.Views;
using PMS.Client.FeeModule.Views.Dialogs;
using System.Reflection;

namespace PMS.Client.FeeModule
{
    public class ModuleFee : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<FeeView>();

            containerRegistry.RegisterDialog<ModifyFeeView, ModifyFeeViewModel>();
        }
    }

}
