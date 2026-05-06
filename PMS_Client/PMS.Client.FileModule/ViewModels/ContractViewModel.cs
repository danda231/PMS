using PMS.Client.Common;
using PMS.Client.Controls;
using PMS.Client.Entities;
using PMS.Client.FileModule.Models;
using PMS.Client.IBll;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PMS.Client.FileModule.ViewModels
{
    public class ContractViewModel : PageViewModelBase
    {
        public PaginationModel PaginationModel  { get; set; } = new PaginationModel();
        public ObservableCollection<ContractModel> ContractList { get; set; } = new ObservableCollection<ContractModel>();
        public DelegateCommand<ContractModel> RevokeCommand { get; set; }
        public DelegateCommand<ContractModel> ApproveCommand { get; set; }
        public DelegateCommand<ContractModel> ExecuteCommand { get; set; }
        public DelegateCommand<ContractModel> ArchivedCommand { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        IContractService _contractService;
        IDialogService _dialogService;
        GlobalValues _globalValues;
        public ContractViewModel(IRegionManager regionManager, 
            IEventAggregator eventAggregator,
            IContractService contractService,
            IDialogService dialogService,
            GlobalValues globalValues) : base(regionManager, eventAggregator)
        {
            BindingOperations.EnableCollectionSynchronization(ContractList, this);
            this.PageTitle = "合同管理";
            this.StartDate = DateTime.Now.AddDays(-15);
            this.EndDate = DateTime.Now;

            _contractService = contractService;
            _dialogService = dialogService;
            _globalValues = globalValues;

            RevokeCommand = new DelegateCommand<ContractModel>(DoRevoke);
            ApproveCommand = new DelegateCommand<ContractModel>(DoApprove);
            ExecuteCommand = new DelegateCommand<ContractModel>(DoExecuteCommand);
            ArchivedCommand = new DelegateCommand<ContractModel>(DoArchived);
            this.Refresh();
        }

        private void DoArchived(ContractModel model)
        {
            try
            {
                if (MessageBox.Show("是否继续执行建档？", "提示", MessageBoxButton.YesNo) ==
                    MessageBoxResult.Yes)
                {
                    ContractEntity entity = new ContractEntity();
                    entity.ContractId = model.ContractId;
                    entity.ArchivedTime = DateTime.Now;
                    entity.ArchivedUserId = _globalValues.UserId;
                    entity.ArchivedUserName = _globalValues.UserName;

                    var count = _contractService.Archived(entity);

                    MessageBox.Show("建档完成！", "提示");

                    model.State = 3;
                    model.ArchivedTime = entity.ArchivedTime;
                    model.ArchivedUserId = entity.ArchivedUserId;
                    model.ArchivedUserName = entity.ArchivedUserName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void DoExecuteCommand(ContractModel model)
        {
            DialogParameters dps = new DialogParameters();
            dps.Add("model", model);
            _dialogService.ShowDialog("ExecuteView", dps, result =>
            {
                if (result.Result == ButtonResult.OK)
                    this.Refresh();
            });
        }

        private void DoApprove(ContractModel model)
        {
            if (ChangeState(model.ContractId, 1, "审批"))
                model.State = 1;
        }

        private void DoRevoke(ContractModel model)
        {
            if (ChangeState(model.ContractId, 0, "撤销"))
                model.State = 0;
        }
        private bool ChangeState(int id, int state, string tip)
        {
            try
            {
                if (MessageBox.Show($"是否{tip}当前信息？", "提示", MessageBoxButton.YesNo) ==
                    MessageBoxResult.Yes)
                {
                    var count = _contractService.ChangeState(id, state);
                    if (count == 0)
                        throw new Exception($"未{tip}任何数据");

                    MessageBox.Show($"{tip}完成！", "提示");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                return false;
            }
        }
        public override void Refresh()
        {
            ContractList.Clear();
            this.BeginLoading();
            Task.Run(() =>
            {
                try
                {
                    // 条件集合
                    var page = _contractService.GetDatas(SearchKey,
                        StartDate, EndDate,
                        PaginationModel.PageIndex, PaginationModel.PageSize);
                    int index = 0;
                    foreach (var item in page.Data)
                    {
                        index++;
                        ContractModel model = new ContractModel()
                        {
                            Index = index + (PaginationModel.PageIndex - 1) * PaginationModel.PageSize,
                            ContractId = item.ContractId,
                            ContractName = item.ContractName,
                            ContractNumber = item.ContractNumber,
                            ContractAmount = item.ContractAmount,
                            ExcuteAmount = item.ExcuteAmount,
                            SignTime = item.SignTime,
                            Operator = item.Operator,
                            Opposite = item.Opposite,
                            State = item.State,
                            ArchivedTime = item.ArchivedTime,
                            ArchivedUserId = item.ArchivedUserId,
                            ArchivedUserName = item.ArchivedUserName,
                            ModifyTime = item.ModifyTime,
                            Userid = item.Userid,
                            UserName = item.UserName,
                        };
                        model.Prograss = model.ContractAmount == 0 ? 0 : model.ExcuteAmount / model.ContractAmount;
                        Application.Current.Dispatcher?.Invoke(() =>
                        {
                            ContractList.Add(model);
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

        public override void DoDelete(object model)
        {
            try
            {
                if (MessageBox.Show("是否确定删除此项？", "提示", MessageBoxButton.YesNo) ==
                    MessageBoxResult.Yes)
                {
                    _contractService.DeleteInfo((model as ContractModel).ContractId);

                    MessageBox.Show("删除完成！", "提示");

                    ContractList.Remove(model as ContractModel);
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
            _dialogService.ShowDialog("ModifyContractView", dps, result =>
            {
                if (result.Result == ButtonResult.OK)
                    this.Refresh();
            });
        }
    }
}
