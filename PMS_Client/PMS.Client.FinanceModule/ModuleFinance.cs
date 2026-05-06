

using PMS.Client.FinanceModule.ViewModels.Dialogs;
using PMS.Client.FinanceModule.Views;
using PMS.Client.FinanceModule.Views.Dialogs;

namespace PMS.Client.FinanceModule
{
    public class ModuleFinance : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterForNavigation<IEDetailView>();

            containerRegistry.RegisterDialog<ModifyIEDetailView, ModifyIEDetailViewModel>();
        }
    }

}
