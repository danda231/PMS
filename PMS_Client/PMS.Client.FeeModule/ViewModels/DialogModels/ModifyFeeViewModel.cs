using PMS.Client.Common;
using PMS.Client.Entities;
using PMS.Client.FeeModule.Models;
using PMS.Client.IBll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.FeeModule.ViewModels.DialogModels
{
    public class ModifyFeeViewModel : DialogViewModelBase
    {

        public FeeModel FeeInfo { get; set; } = new FeeModel();

        private QuarterModel _currentquarter;

        public QuarterModel CurrentQuarter
        {
            get { return _currentquarter; }
            set
            {
                _currentquarter = value;

                // 进行楼栋的过滤
                BuildingList = _buildingList.Where(b => b.Qid == value.Id)
                    .Select(b => new BuildingModel
                    {
                        Id = b.Id,
                        Qid = b.Qid,
                        Name = b.Name,
                    }).ToList();
                CurrentBuilding = BuildingList?[0];

                this.RaisePropertyChanged(nameof(CurrentBuilding));
                this.RaisePropertyChanged(nameof(BuildingList));
            }
        }

        public List<QuarterModel> QuarterList { get; set; }

        public BuildingModel CurrentBuilding { get; set; }
        private List<BuildingEntity> _buildingList;
        public List<BuildingModel> BuildingList { get; set; }

        public FeeModeModel CurrentFeeMode { get; set; }
        public List<FeeModeModel> FeeModeList { get; set; }


        IFeeService _feeService;
        GlobalValues _globalValues;

        public ModifyFeeViewModel(IFeeService feeService,
        GlobalValues globalValues,
        IOwnerService ownerService)
        {
            _feeService = feeService;
            _globalValues = globalValues;

            QuarterList = ownerService.GetQuareters().Select(e => new QuarterModel { Id = e.Id, Name = e.Name }).ToList(); 
            FeeModeList = _feeService.GetFeeModes().Select(fm => new FeeModeModel
            {
                FeeId = fm.FeeModeId,
                FeeName = fm.FeeModeName,
            }).ToList();
            _buildingList = ownerService.GetBuildings().ToList();

        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            var model = parameters.GetValue<FeeModel>("model");

            if (model == null)
            {
                // 新增
                Title = "新增信息";

                FeeInfo.State = 0;
                FeeInfo.UserId = _globalValues.UserId;
                FeeInfo.UserName = _globalValues.UserName;
                FeeInfo.ValidTime = DateTime.Now;

                FeeInfo.RoomNumber = "";
                FeeInfo.Amount = 0;

                CurrentFeeMode = FeeModeList?[0];
                CurrentQuarter = QuarterList?[0];
            }
            else
            {
                // 修改
                Title = "编辑信息";

                FeeInfo.RoomNumber = model.RoomNumber;
                FeeInfo.FeeId = model.FeeId;
                FeeInfo.FeeMode = model.FeeMode;
                FeeInfo.FeeModeId = model.FeeModeId;
                FeeInfo.Amount = model.Amount;
                FeeInfo.Description = model.Description;
                FeeInfo.ValidTime = model.ValidTime;

                CurrentFeeMode = FeeModeList?.FirstOrDefault(fm => fm.FeeId == model.FeeModeId);
                CurrentQuarter = QuarterList?.FirstOrDefault(q => q.Id == model.QId);
                CurrentBuilding = BuildingList?.FirstOrDefault(b => b.Id == model.BId);
            }
        }
        public override void DoSave()
        {
            if (FeeInfo.HasErrors) return;

            try
            {
                FeeEntity feeInfo = new FeeEntity();
                feeInfo.FeeId = FeeInfo.FeeId;// 0    
                feeInfo.FeeModeId = CurrentFeeMode.FeeId;
                feeInfo.FeeMode = CurrentFeeMode.FeeName;
                feeInfo.Amount = FeeInfo.Amount;
                feeInfo.BId = CurrentBuilding.Id;
                feeInfo.BName = CurrentBuilding.Name;
                feeInfo.QId = CurrentQuarter.Id;
                feeInfo.QName = CurrentQuarter.Name;
                feeInfo.RoomNumber = FeeInfo.RoomNumber;
                feeInfo.ValidTime = FeeInfo.ValidTime;
                feeInfo.Description = FeeInfo.Description;
                feeInfo.State = 0;
                feeInfo.ModifyTime = DateTime.Now;
                feeInfo.UserId = _globalValues.UserId;
                feeInfo.UserName = _globalValues.UserName;

                var count = _feeService.UpdateFee(feeInfo);
                if (count == 0)
                    throw new Exception("信息更新失败");

                base.DoSave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
