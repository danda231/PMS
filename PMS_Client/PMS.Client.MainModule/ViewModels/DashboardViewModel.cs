using PMS.Client.MainModule.Models;
using Prism.Commands;
using Prism.Dialogs;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.MainModule.ViewModels
{
    public class DashboardViewModel : INavigationAware
    {
        public List<DataModel> MainData { get; set; } = new List<DataModel>();
        public List<AmountModel> AmountList { get; set; } =
                new List<AmountModel>();
        public DelegateCommand ModifyPasswordCommand { get; set; }
        public UserModel CurrentUser { get; set; } = new UserModel();

        IDialogService _dialogService;
        public DashboardViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            DataInit();

            
        }

        private void DataInit()
        {
            MainData.Add(new DataModel()
            {
                Header = "业主数量",
                Value = 6178,
                Icon = "\ue606",
                Color = "#3F4BFE"
            });
            MainData.Add(new DataModel()
            {
                Header = "房屋数量",
                Value = 5124,
                Icon = "\ue602",
                Color = "#FE3D3D"
            });
            MainData.Add(new DataModel()
            {
                Header = "设备数量",
                Value = 412,
                Icon = "\ue604",
                Color = "#953DFF"
            });
            MainData.Add(new DataModel()
            {
                Header = "车辆数量",
                Value = 2165,
                Icon = "\ue604",
                Color = "#3EB2FE"
            });
            MainData.Add(new DataModel()
            {
                Header = "车辆数量",
                Value = 2165,
                Icon = "\ue604",
                Color = "#3E4BFF"
            });

            AmountList.Add(new AmountModel
            {
                Rate = 93,
                Color = "#9A3DFE",
                Header = "广告费",
                Amount = 304.12
            }); AmountList.Add(new AmountModel
            {
                Rate = 68,
                Color = "#3F5AFF",
                Header = "物业管理费",
                Amount = 416.37
            }); AmountList.Add(new AmountModel
            {
                Rate = 62,
                Color = "#FD3BB4",
                Header = "车位管理费",
                Amount = 164.56
            }); AmountList.Add(new AmountModel
            {
                Rate = 76,
                Color = "#FE923C",
                Header = "垃圾处理费",
                Amount = 147.18
            });

            ModifyPasswordCommand = new DelegateCommand(DoModifyPassword);
        }

        private void DoModifyPassword()
        {
            DialogParameters dps = new DialogParameters();
            dps.Add("id", CurrentUser.UserId);
            dps.Add("pwd", CurrentUser.Password);
            _dialogService.ShowDialog("ModifyPasswordView", dps,result =>
            {
                
            });
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

            
            Entities.EmployEntity user = navigationContext.Parameters
                .GetValue<Entities.EmployEntity>("user");

            Console.WriteLine(user.ToString());
            CurrentUser.UserId = user.EId;
            CurrentUser.RealName = user.RealName;
            CurrentUser.Avatar = "http://localhost:5115/api/File/img/"+user.EIcon;
            CurrentUser.Password = user.Password;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
