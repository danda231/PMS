using PMS.Client.Common;
using PMS.Client.Controls;
using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.PropertyModule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PMS.Client.PropertyModule.ViewModels
{
    public class OwnerViewModel : PageViewModelBase
    {
        IOwnerService _ownerService;
        IEventAggregator _eventAggregator;
        IDialogService _dialogService;
        public PaginationModel PaginationModel { get; set; } = new PaginationModel();
        public ObservableCollection<OwnerModel> Owners { get; set; } = new ObservableCollection<OwnerModel>();
        public List<ConditionModel> Conditions { get; set; } = new List<ConditionModel>();
        public OwnerViewModel(IRegionManager regionManager,
            IOwnerService ownerService,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(regionManager, eventAggregator)
        {
            BindingOperations.EnableCollectionSynchronization(Owners, this);

            this.PageTitle = "业主信息登记";

            _ownerService = ownerService;
            _eventAggregator = eventAggregator;

            PaginationModel.NavCommand = new DelegateCommand<object>(index =>
            {
                PaginationModel.PageIndex = int.Parse(index.ToString());
                this.Refresh();
            });

            // 初始化检索条件
            Conditions.Add(new ConditionModel { Name = "HouseHolder", Header = "业主姓名" });
            Conditions.Add(new ConditionModel { Name = "RoomNum", Header = "房间信息" });
            Conditions.Add(new ConditionModel { Name = "IdNumber", Header = "身份证号" });
            Conditions.Add(new ConditionModel { Name = "Phone", Header = "手机号" });

            this.Refresh();
            _dialogService = dialogService;
        }

        public override void DoDelete(object model)
        {
            try
            {
                if (MessageBox.Show("是否删除此用户？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var role = _ownerService.DeleteOwners((model as OwnerModel).OwnerId);

                    MessageBox.Show("删除完成", "提示");
                    Owners.Remove((model as OwnerModel));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        public override void DoModify(object model)
        {
            DialogParameters ps = new DialogParameters();
            ps.Add("model", model);
            _dialogService.ShowDialog("ModifyOwnerView", ps, re =>
            {
                if(re.Result == ButtonResult.OK)
                {
                    this.Refresh();
                }
            });
        }
        public override void Refresh()
        {
            Owners.Clear();
            this.BeginLoading();
            Task.Run(() =>
            {
                try
                {
                    // 条件集合
                    List<ConditionEntity> conditions = new List<ConditionEntity>();
                    foreach (var condition in Conditions)
                    {
                        if (condition.Value != null && !string.IsNullOrEmpty(condition.Value.ToString()))
                            conditions.Add(new ConditionEntity { Name = condition.Name, Value = condition.Value });
                    }
                    var os = _ownerService.GetOwners(conditions.ToArray(), PaginationModel.PageIndex, PaginationModel.PageSize);

                    int index = 0;
                    foreach (var o in os.Data)
                    {
                        index++;
                        Owners.Add(new OwnerModel
                        {
                            Index = index + (PaginationModel.PageIndex - 1) * PaginationModel.PageSize,
                            OwnerId = o.OwnerId,
                            HouseHolder = o.HouseHolder,
                            IdNumber = o.IdNumber,
                            Phone = o.Phone,
                            Bid = o.Bid,
                            Bname = o.Bname,
                            Qid = o.Qid,
                            Qname = o.Qname,
                            RoomNum = o.RoomNum,
                            Gender = o.Gender,
                            CredentialImg1 = o.CredentialImg1,
                            CredentialImg2 = o.CredentialImg2,
                            Description = o.Description,
                            State = o.State,
                            ModifyTime = o.ModifyTime,
                            UserId = o.OwnerId,
                            UserName = o.UserName,
                        });
                    }
                    Application.Current.Dispatcher?.Invoke(() =>
                    {
                        // 刷新页码
                        PaginationModel.FillPageNumbers(os.TotalCount);
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
