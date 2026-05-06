using PMS.Client.Common;
using PMS.Client.Controls;
using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.SystemModule.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.SystemModule.ViewModels
{
    public class BaseInfoViewModel : PageViewModelBase
    {
        public ObservableCollection<BaseInfoModel> BaseInfoList { get; set; } =
            new ObservableCollection<BaseInfoModel>();

        public PaginationModel PaginationModel { get; set; } = new PaginationModel();

        IEventAggregator _eventAggregator;
        IBaseInfoService _baseInfoService;
        IDialogService _dialogService;

        public DelegateCommand<BaseInfoModel> CancelCommand { get; set; }
        public DelegateCommand<BaseInfoModel> PublishCommand { get; set; }
        public BaseInfoViewModel(IRegionManager regionManager,
            IEventAggregator eventAggregator,
            IBaseInfoService baseInfoService,
            IDialogService dialogService) : base(regionManager, eventAggregator)
        {
            this.PageTitle = "公告与通知";

            _eventAggregator = eventAggregator;
            _baseInfoService = baseInfoService;
            _dialogService = dialogService;

            PaginationModel.NavCommand = new DelegateCommand<object>(index =>
            {
                PaginationModel.PageIndex = int.Parse(index.ToString());
                this.Refresh();
            });
            CancelCommand = new DelegateCommand<BaseInfoModel>(DoCancelState);
            PublishCommand = new DelegateCommand<BaseInfoModel>(DoPublishState);

            this.Refresh();
        }

        private void DoPublishState(BaseInfoModel model)
        {
            string tip = model.State == 0 ? "发布" : "撤销";
            try
            {
                if (MessageBox.Show($"是否{tip}当前信息？", "提示", MessageBoxButton.YesNo) ==
                    MessageBoxResult.Yes)
                {
                    int count = 0;
                    if(model.State == 0)
                    {
                        count = _baseInfoService.PublishState(model.InfoId);
                        model.State = 1;
                        model.PublishTime = DateTime.Now;
                    }
                    else
                    {
                        count = _baseInfoService.RevokeState(model.InfoId);
                        model.State = 0;
                        model.PublishTime = null;
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void DoCancelState(BaseInfoModel model)
        {
            try
            {
                if (MessageBox.Show($"是否作废当前信息？", "提示", MessageBoxButton.YesNo) ==
                    MessageBoxResult.Yes)
                {
                    int count = _baseInfoService.CancelState((model as BaseInfoModel).InfoId);
                    if (count == 0) throw new Exception("未作废任何信息");
                    MessageBox.Show("信息已作废！", "提示");
                    model.State = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        public override void Refresh()
        {
            BaseInfoList.Clear();
            this.BeginLoading();
            try
            {
                var page = _baseInfoService.GetInfoPage(this.SearchKey,
                    PaginationModel.PageIndex, PaginationModel.PageSize);

                int index = 0;
                foreach (var item in page.Data)
                {
                    index++;
                    // 数据
                    BaseInfoModel model = new BaseInfoModel();

                    model.Index = index + (PaginationModel.PageIndex - 1) * PaginationModel.PageSize;
                    model.InfoId = item.InfoId;
                    model.InfoHeader = item.InfoHeader;
                    model.InfoContent = item.InfoContent;
                    model.InfoKey = item.InfoKey;
                    model.ModifyTime = item.ModifyTime;
                    model.PublishTime = item.PublishTime;
                    model.InfoType = item.InfoType;
                    model.State = item.state;
                    model.UserName = item.UserName;

                    // 有前面的BindingOperations.EnableCollectionSynchronization方法调用
                    // 这里不需要Dispatcher
                    //Application.Current.Dispatcher.Invoke(() =>
                    //{
                    BaseInfoList.Add(model);
                    //});
                }
                Application.Current.Dispatcher?.Invoke(() =>
                {
                    // 刷新分页组件的页码
                    PaginationModel.FillPageNumbers(page.TotalCount);
                });
            }
            catch { }
            finally
            {
                this.EndLoading();
            }
        }
        public override void DoModify(object model)
        {
            DialogParameters ps = new DialogParameters();
            ps.Add("model", model);

            _dialogService.ShowDialog("ModifyInfoView", ps, result =>
            {
                if(result.Result == ButtonResult.OK)
                {
                    this.Refresh();
                }
            });
            
        }

        public override void DoDelete(object model)
        {
            try
            {
                if (MessageBox.Show("确定删除此项？", "提示", MessageBoxButton.YesNo) ==
                    MessageBoxResult.Yes)
                {
                    _baseInfoService.DeleteInfo((model as BaseInfoModel).InfoId);

                    MessageBox.Show("删除完成！", "提示");
                    BaseInfoList.Remove(model as BaseInfoModel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

    }
}
