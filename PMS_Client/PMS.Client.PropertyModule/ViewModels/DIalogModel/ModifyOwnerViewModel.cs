using Microsoft.Win32;
using PMS.Client.Common;
using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.PropertyModule.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.PropertyModule.ViewModels.DIalogModel
{
    public class ModifyOwnerViewModel : DialogViewModelBase
    {

        public OwnerModel OwnerInfo { get; set; } =
            new OwnerModel();

        private QuarterModel _currentQuarter;
        public QuarterModel CurrentQuarter 
        { 
            get {  return _currentQuarter; }
            set
            {
                _currentQuarter = value;

                // 楼栋的过滤
                BuildingList = _buildingList.Where(b => b.Qid == value.Id).Select(b => new BuildingModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Qid = b.Qid,
                }).ToList();
                CurrentBuilding = BuildingList?[0];
                this.RaisePropertyChanged(nameof(BuildingList));
                this.RaisePropertyChanged(nameof(CurrentBuilding));
            }
        }
        public List<QuarterModel> QuarterList { get; set; }

        public BuildingModel CurrentBuilding { get; set; }

        private List<BuildingEntity> _buildingList;
        public List<BuildingModel> BuildingList { get; set; }

        public DelegateCommand<string> SelectCommand { get; set; }

        IOwnerService _ownerService;
        GlobalValues _globalValues;
        IFileService _fileService;

        public ModifyOwnerViewModel(IOwnerService ownerService, 
            GlobalValues globalValues,
            IFileService fileService)
        {
            _ownerService = ownerService;
            _globalValues = globalValues;
            _fileService = fileService;

            // 初始化 
            // 对应的集合    当前选中项
            QuarterList = ownerService.GetQuareters()
                .Select(q => new QuarterModel { Id = q.Id, Name = q.Name })
                .ToList();
             
            //BuildingList = ownerService.GetBuildings()
            //    .Select(q => new BuildingModel { Id = q.Id, Name = q.Name, Qid = q.Qid })
            //    .ToList();
            _buildingList = ownerService.GetBuildings().ToList();

            SelectCommand = new DelegateCommand<string>(DoSelect);

        }

        private void DoSelect(string flag)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片文件|*.jpg;*.png;*.bmp";
            if(openFileDialog.ShowDialog() == true)
            {
                if(flag == "1") { OwnerInfo.CredentialImg1 = openFileDialog.FileName; imageChange1 = true; }
                else if(flag == "2") { OwnerInfo.CredentialImg2 = openFileDialog.FileName; imageChange2 = true; }
            }
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            var model = parameters.GetValue<OwnerModel>("model");
            if(model == null)
            {
                // 新建
                Title = "新增业主信息";
                OwnerInfo.State = 0;
                OwnerInfo.Gender = 0;
                OwnerInfo.UserId = _globalValues.UserId;
                OwnerInfo.UserName = _globalValues.UserName;
            }
            else
            {
                // 更新
                Title = "编辑业主信息";

                OwnerInfo.OwnerId = model.OwnerId;
                OwnerInfo.HouseHolder = model.HouseHolder;
                OwnerInfo.IdNumber = model.IdNumber;
                OwnerInfo.Phone = model.Phone;
                OwnerInfo.Bid = model.Bid;
                OwnerInfo.Bname = model.Bname;
                OwnerInfo.Qid = model.Qid;
                OwnerInfo.Qname = model.Qname;
                OwnerInfo.RoomNum = model.RoomNum;
                OwnerInfo.Gender = model.Gender;
                OwnerInfo.CredentialImg1 = "http://localhost:5115/api/File/idcard/" + model.CredentialImg1;
                OwnerInfo.CredentialImg2 = "http://localhost:5115/api/File/idcard/" + model.CredentialImg2;
                OwnerInfo.Description = model.Description;
                OwnerInfo.State = model.State;
                OwnerInfo.ModifyTime = model.ModifyTime;
                OwnerInfo.UserId = model.UserId;
                OwnerInfo.UserName = model.UserName;

                imgName1 = model.CredentialImg1;
                imgName2 = model.CredentialImg2;

                CurrentQuarter = QuarterList?.FirstOrDefault(q => q.Id == model.Qid);
                CurrentBuilding = BuildingList?.FirstOrDefault(q => q.Id == model.Bid);
            }
        }

        string imgName1;
        string imgName2;

        bool imageChange1 = false, imageChange2 = false;
        public override void DoSave()
        {
            if (this.HasErrors) return;
            try
            {
                if (imageChange1) 
                { 
                    imgName1 = OwnerInfo.IdNumber + "_A" + Path.GetExtension(OwnerInfo.CredentialImg1);
                    _fileService.UploadIdCard(OwnerInfo.CredentialImg1, imgName1);
                    imageChange1 = false;
                }
                if (imageChange2)
                { 
                    imgName2 = OwnerInfo.IdNumber + "_B" + Path.GetExtension(OwnerInfo.CredentialImg2);                
                    _fileService.UploadIdCard(OwnerInfo.CredentialImg2, imgName2);
                    imageChange2 = false;
                }
                OwnerEntity ownerInfo = new OwnerEntity()
                {
                    OwnerId = OwnerInfo.OwnerId,
                    HouseHolder = OwnerInfo.HouseHolder,
                    IdNumber = OwnerInfo.IdNumber,
                    Phone = OwnerInfo.Phone,
                    Bid = CurrentBuilding.Id,
                    Bname = CurrentBuilding.Name,
                    Qid = CurrentQuarter.Id,
                    Qname = CurrentQuarter.Name,
                    RoomNum = OwnerInfo.RoomNum,
                    Gender = OwnerInfo.Gender,
                    CredentialImg1 = imgName1,
                    CredentialImg2 = imgName2,
                    Description = OwnerInfo.Description,
                    State = OwnerInfo.State,
                    ModifyTime = DateTime.Now,
                    UserId = OwnerInfo.UserId,
                    UserName = OwnerInfo.UserName,
                };
                var count = _ownerService.UpdateOwners(ownerInfo);

                if (count == 0) throw new Exception("操作失败");
                base.DoSave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
    }
}
