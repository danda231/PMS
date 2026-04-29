
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

        }
    }
}
