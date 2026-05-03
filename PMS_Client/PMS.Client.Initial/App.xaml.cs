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
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            // 注册全局属性
            containerRegistry.RegisterSingleton<GlobalValues>();

            // 可视化绑定
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();
            containerRegistry.RegisterDialogWindow<PMS.Client.Initial.ViewModels.DialogWindow>();

            // Service绑定
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IFileService,FileService>();
            containerRegistry.Register<IMenuService, MenuService>();
            containerRegistry.Register<IRoleService, RoleService>();


            // Access绑定
            containerRegistry.Register<IUserAccess, UserAccess>();
            containerRegistry.Register<IFileAccess, FileAccess>();
            containerRegistry.Register<IMenuAccess, MenuAccess>();
            containerRegistry.Register<IRoleAccess, RoleAccess>();
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
