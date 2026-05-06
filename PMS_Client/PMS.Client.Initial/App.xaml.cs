using PMS.Client.Bll;
using PMS.Client.DAL;
using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using PMS.Client.Initial.ViewModels;
using PMS.Client.Initial.Views;
using System.Configuration;
using System.Data;
using System.Windows;


namespace PMS.Client.Initial
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        GlobalValues globalValues = new GlobalValues();
        public App()
        {
            globalValues.ServerHost = ConfigurationManager.AppSettings.GetValues("server_domain")[0];
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            // 注册全局属性
            containerRegistry.RegisterSingleton<GlobalValues>(() => globalValues);

            // 可视化绑定
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();
            containerRegistry.RegisterDialogWindow<PMS.Client.Initial.ViewModels.DialogWindow>();

            // Service绑定
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IFileService,FileService>();
            containerRegistry.Register<IMenuService, MenuService>();
            containerRegistry.Register<IRoleService, RoleService>();
            containerRegistry.Register<IBaseInfoService, BaseInfoService>();
            containerRegistry.Register<IOwnerService, OwnerService>();
            containerRegistry.Register<IFeeService, FeeService>();
            containerRegistry.Register<IOrderService, OrderService>();
            containerRegistry.Register<IFinanceService, FinanceService>();
            containerRegistry.Register<IContractService, ContractService>();

            // Access绑定
            containerRegistry.Register<IUserAccess, UserAccess>();
            containerRegistry.Register<IFileAccess, FileAccess>();
            containerRegistry.Register<IMenuAccess, MenuAccess>();
            containerRegistry.Register<IRoleAccess, RoleAccess>();
            containerRegistry.Register<IBaseInfoAccess, BaseInfoAccess>();
            containerRegistry.Register<IOwnerAccess, OwnerAccess>();
            containerRegistry.Register<IFeeAccess, FeeAccess>();
            containerRegistry.Register<IOrderAccess, OrderAccess>();
            containerRegistry.Register<IFinanceAccess, FinanceAccess>();
            containerRegistry.Register<IContractAccess, ContractAccess>();
        }

        // 扫描目录配置
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog
            {
                ModulePath = Environment.CurrentDirectory + "\\Modules"
            };
        }
    }

}
