using PMS.Client.Common;
using PMS.Client.Controls;
using PMS.Client.Entities;
using PMS.Client.FeeModule.Models;
using PMS.Client.IBll;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.FeeModule.ViewModels
{
    public class FeeViewModel : PageViewModelBase
    {
        public PaginationModel PaginationModel { get; set; } = new PaginationModel();
        public ObservableCollection<FeeModel> FeeList { get; set; }= new ObservableCollection<FeeModel>();

        public DelegateCommand<FeeModel> ConfirmCommand { get; set; }

        IFeeService _feeService;
        IDialogService _dialogService;
        public FeeViewModel(IRegionManager regionManager, 
            IEventAggregator eventAggregator,
            IFeeService feeService,
            IDialogService dialogService) : base(regionManager, eventAggregator)
        {
            this.PageTitle = "费用代收贷记";

            _feeService = feeService;
            _dialogService = dialogService;

            PaginationModel.NavCommand = new DelegateCommand<object>( index =>
            {
                PaginationModel.PageIndex = int.Parse(index.ToString());
                this.Refresh();
            });
            ConfirmCommand = new DelegateCommand<FeeModel>(DoConfirm);


            this.Refresh();
        }

        private void DoConfirm(FeeModel fee)
        {
            try
            {
                string tip = fee.State == 0 ? "确认" : "作废";
                if (MessageBox.Show($"是否{tip}当前信息？", "提示", MessageBoxButton.YesNo) ==
                    MessageBoxResult.Yes)
                {
                    int state = fee.State == 0 ? 1 : -1;

                    var count = _feeService.ChangeState(fee.FeeId, state);
                    if (count == 0)
                        throw new Exception($"未{tip}任何数据");

                    MessageBox.Show($"{tip}完成！", "提示");

                    fee.State = state;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        public override void DoDelete(object model)
        {
            try
            {
                if (MessageBox.Show("是否删除此用户？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _feeService.DeleteFee((model as FeeModel).FeeId);
                    FeeList.Remove((model as FeeModel));
                    MessageBox.Show("删除完成", "提示");                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        public override void DoModify(object model)
        {
            DialogParameters dps = new DialogParameters();
            dps.Add("model", model);
            _dialogService.ShowDialog("ModifyFeeView", dps, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    this.Refresh();
                }
            });
        }
        public override void Refresh()
        {
            FeeList.Clear();
            this.BeginLoading();
            Task.Run(() =>
            {
                try
                {
                    // 条件集合
                    var page = _feeService.GetFees(this.SearchKey, PaginationModel.PreviousIndex, PaginationModel.PageSize);

                    int index = 0;
                    foreach (var fe in page.Data)
                    {
                        index++;
                        var feeModel = new FeeModel
                        {
                            Index = index + (PaginationModel.PageIndex - 1) * PaginationModel.PageSize,
                            FeeId = fe.FeeId,
                            FeeMode = fe.FeeMode,
                            FeeModeId = fe.FeeModeId,
                            Amount = fe.Amount,
                            BId = fe.BId,
                            BName = fe.BName,
                            QId = fe.QId,
                            QName = fe.QName,
                            RoomNumber = fe.RoomNumber,
                            Description = fe.Description,
                            State = fe.State,
                            UserId = fe.UserId,
                            UserName = fe.UserName,
                            ModifyTime = fe.ModifyTime,
                            ValidTime = fe.ValidTime,
                        };
                        Application.Current.Dispatcher?.Invoke(() =>
                        {
                            FeeList.Add(feeModel);
                        });
                        
                    }
                    Application.Current.Dispatcher?.Invoke(() =>
                    {
                        // 刷新页码
                        PaginationModel.FillPageNumbers(page.TotalCount);
                    });
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    this.EndLoading();
                }

            });
            
        }
    }
}
