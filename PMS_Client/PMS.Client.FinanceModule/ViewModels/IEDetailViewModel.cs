using PMS.Client.Common;
using PMS.Client.Controls;
using PMS.Client.FinanceModule.Models;
using PMS.Client.IBll;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.FinanceModule.ViewModels
{
    public class IEDetailViewModel : PageViewModelBase
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PaginationModel PaginationModel { get; set; } = new PaginationModel();
        public ObservableCollection<IEModel> IEList { get; set; } = new ObservableCollection<IEModel>();
        public DelegateCommand<IEModel> ConfirmCommand { get; set; }
        public DelegateCommand<IEModel> RevokeCommand { get; set; }

        IFinanceService _financeService;
        IDialogService _dialogService;
        public IEDetailViewModel(IRegionManager regionManager, 
            IEventAggregator eventAggregator,
            IFinanceService financeService,
            IDialogService dialogService) : base(regionManager, eventAggregator)
        {
            _financeService = financeService;
            _dialogService = dialogService;
            StartDate = DateTime.Now.AddDays(-15);
            EndDate = DateTime.Now;

            PaginationModel.NavCommand = new DelegateCommand<object>(index =>
            {
                PaginationModel.PageIndex = int.Parse(index.ToString());
                this.Refresh();
            });
            ConfirmCommand = new DelegateCommand<IEModel>(DoConfirm);
            RevokeCommand = new DelegateCommand<IEModel>(DoRevoke);

            this.Refresh();
        }

        private void DoRevoke(IEModel model)
        {
            ChangeState(model.IEID, 0, "撤销");
            model.State = 1;
        }

        private void DoConfirm(IEModel model)
        {
            ChangeState(model.IEID, 1, "建档");
            model.State = 0;
        }

        private void ChangeState(int iEID, int v1, string tip)
        {
            try
            {
                if (MessageBox.Show($"是否{tip}当前信息？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _financeService.ChangeState(iEID, v1);
                    MessageBox.Show($"{tip}完成！");
                    this.Refresh();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }           
        }

        public override void DoDelete(object model)
        {
            try
            {
                if (MessageBox.Show("是否删除此项？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _financeService.DeleteInfo((model as IEModel).IEID);
                    IEList.Remove((model as IEModel));
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
            dps.Add("model",model);
            _dialogService.ShowDialog("ModifyIEDetailView", dps, res =>
            {
                if(res.Result == ButtonResult.OK)
                {
                    this.Refresh();
                }
            });
        }
        public override void Refresh()
        {
            IEList.Clear();
            this.BeginLoading();
            Task.Run(() =>
            {
                try
                {
                    // 条件集合
                    var page = _financeService.GetDatas(SearchKey, 
                        StartDate, EndDate, 
                        PaginationModel.PageIndex, PaginationModel.PageSize);
                    int index = 0;
                    foreach (var item in page.Data)
                    {
                        index++;
                        IEModel model = new IEModel()
                        {
                            Index = index + (PaginationModel.PageIndex - 1) * PaginationModel.PageSize,
                            IEID = item.IEID,
                            HappendTime = item.HappendTime,
                            RecordType = item.RecordType,
                            IncomeAmount = item.RecordType == 1 ? item.Amount : 0,
                            IncomeType = item.RecordType == 1 ? item.AmountType : "",
                            IncomeDesc = item.RecordType == 1 ? item.AmountDesc : "",
                            ExpensesAmount = item.RecordType == 2 ? item.Amount : 0,
                            ExpensesType = item.RecordType == 2 ? item.AmountType : "",
                            ExpensesDesc = item.RecordType == 2 ? item.AmountDesc : "",
                            ProjectName = item.ProjectName,
                            Account = item.Account,
                            Department = item.Department,
                            Operator = item.Operator,
                            Description = item.Description,
                            RecordId = item.RecordId,
                            RecordName = item.RecordName,
                            RecordTime = item.RecordTime,
                            State = item.State,
                        };
                        Application.Current.Dispatcher?.Invoke(() =>
                        {
                            IEList.Add(model);
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
