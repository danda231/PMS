

using PMS.Client.FileModule.ViewModels.Dialogs;
using PMS.Client.FileModule.Views;
using PMS.Client.FileModule.Views.Dialogs;

namespace PMS.Client.FileModule
{
    public class ModuleFile : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ContractView>();

            containerRegistry.RegisterDialog<ModifyContractView,ModifyContractViewModel>();
            containerRegistry.RegisterDialog<ExecuteView, ExecuteViewModel>();
        }
    }

}
