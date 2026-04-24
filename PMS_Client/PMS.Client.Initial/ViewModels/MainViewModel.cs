using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Initial.ViewMmodels
{
    internal class MainViewModel
    {
        public MainViewModel(IDialogService dialogService) {
            dialogService.ShowDialog("LoginView");
        }
    }
}
