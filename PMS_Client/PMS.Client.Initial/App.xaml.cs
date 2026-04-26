using PMS.Client.Bll;
using PMS.Client.DAL;
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
            // 可视化绑定
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();
            containerRegistry.RegisterDialog<PMS.Client.Initial.ViewModels.DialogWindow>();

            // Service绑定
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IFileService,FileService>();


            // Access绑定
            containerRegistry.Register<IUserAccess, UserAccess>();
            containerRegistry.Register<IFileAccess, FileAccess>();
        }
    }

}
