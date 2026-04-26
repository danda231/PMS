using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PMS.Client.Initial.ViewModels;

namespace PMS.Client.Initial.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : UserControl
    {
        private bool _loadedCommandInvoked;

        public LoginView()
        {
            InitializeComponent();
            DataContextChanged += LoginView_DataContextChanged;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TryInvokeLoadedCommand();
        }

        private void LoginView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TryInvokeLoadedCommand();
        }

        private void TryInvokeLoadedCommand()
        {
            if (_loadedCommandInvoked)
            {
                return;
            }

            if (DataContext is not LoginViewModel vm || vm.LoadedCommand == null)
            {
                return;
            }

            if (!vm.LoadedCommand.CanExecute(this))
            {
                return;
            }

            _loadedCommandInvoked = true;
            vm.LoadedCommand.Execute(this);
        }
    }
}
