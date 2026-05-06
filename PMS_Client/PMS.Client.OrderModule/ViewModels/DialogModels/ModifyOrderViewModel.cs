using Microsoft.Win32;
using PMS.Client.Common;
using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.OrderModule.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.OrderModule.ViewModels.DialogModels
{
    public class ModifyOrderViewModel : DialogViewModelBase
    {
        
        public OrderModel OrderInfo { get; set; } = new OrderModel();
        public List<string> OrderTypeList { get; set; } = new List<string>();
        public List<string> ServiceList { get; set; } = new List<string>();

        public DelegateCommand<string> DeleteImageCommand { get; set; }
        public DelegateCommand SelectImageCommand { get; set; }

        IFileService _fileService;
        GlobalValues _globalValues;
        IOrderService _orderService;
        public ModifyOrderViewModel(IFileService fileService, 
            GlobalValues globalValues,
            IOrderService orderService)
        {
            OrderTypeList.Add("维修更换");
            OrderTypeList.Add("卫生管理");
            OrderTypeList.Add("治安维保");

            ServiceList.Add("上门服务");
            ServiceList.Add("远程指导");

            _fileService = fileService;
            _globalValues = globalValues;
            _orderService = orderService;

            DeleteImageCommand = new DelegateCommand<string>(DoDeleteImage);
            SelectImageCommand = new DelegateCommand(DoSelectImage);
        }

        bool flag = false;
        private void DoSelectImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "图片文件|*.jpg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == true)
            {
                flag = true;
                
                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    OrderInfo.ImageList.Add(new OrderImageModel
                    {
                        ImageName = openFileDialog.FileNames[i], // 文件地址
                        ImageId = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-" + OrderInfo.ImageList.Count.ToString("000"),
                        IsModified = true
                    });
                }
            }
        }

        private void DoDeleteImage(string image_id)
        {
            var img = OrderInfo.ImageList.FirstOrDefault(i => i.ImageId == image_id);
            if (img != null)
                OrderInfo.ImageList.Remove(img);
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            var model = parameters.GetValue<OrderModel>("model");
            if(model == null)
            {
                // 新增
                this.Title = "报修登记";

                OrderInfo.OrderId = "";
                OrderInfo.Description = "";
                OrderInfo.State = 0;
                OrderInfo.OrderType = "维修更换";
                OrderInfo.ServiceType = "上门服务";
                OrderInfo.FinishTime = DateTime.Now;
            }
            else
            {
                // 修改
                this.Title = "报修记录修改";

                OrderInfo.OrderId = model.OrderId;
                OrderInfo.OrderType = model.OrderType;
                OrderInfo.ServiceType = model.ServiceType;
                OrderInfo.Description = model.Description;
                OrderInfo.Address = model.Address;
                OrderInfo.Contacts = model.Contacts;
                OrderInfo.Phone = model.Phone;
                OrderInfo.FinishTime = model.FinishTime;
                OrderInfo.State = model.State;
                OrderInfo.IsUrgent = model.IsUrgent;
                OrderInfo.ModifyTime = model.ModifyTime;
                OrderInfo.UserId = model.UserId;
                OrderInfo.UserName = model.UserName;
                OrderInfo.ImageList = model.ImageList;
            }
        }

        public override void DoSave()
        {
            try
            {
                foreach (var img in OrderInfo.ImageList)
                {
                    if (!img.IsModified) continue;
                    string im = img.ImageId + Path.GetExtension(img.ImageName);
                    _fileService.UploadIssueImg(img.ImageName, im);
                    img.ImageName = "http://localhost:5115/api/File/order_img/" + im;
                }
                OrderEntity orderEntity = new OrderEntity();
                orderEntity.OrderId = OrderInfo.OrderId;
                orderEntity.OrderType = OrderInfo.OrderType;
                orderEntity.ServiceType = OrderInfo.ServiceType;
                orderEntity.Description = OrderInfo.Description;
                orderEntity.Address = OrderInfo.Address;
                orderEntity.Phone = OrderInfo.Phone;
                orderEntity.Contacts = OrderInfo.Contacts;
                orderEntity.FinishTime = OrderInfo.FinishTime;
                orderEntity.State = OrderInfo.State;
                orderEntity.IsUrgent = OrderInfo.IsUrgent;
                orderEntity.ModifyTime = DateTime.Now;
                orderEntity.UserId = _globalValues.UserId;
                orderEntity.UserName = _globalValues.UserName;
                orderEntity.Title = "需求";

                orderEntity.Images = OrderInfo.ImageList.Select(i => new OrderImageEntity
                {
                    OrderId = i.OrderId,
                    ImageId = i.ImageId,
                    ImageName = i.ImageName.Split('/').Last(),
                }).ToList();

                // 数据提交到数据库
                int count = _orderService.UpdateOrder(orderEntity);
                if (count == 0)
                    throw new Exception("信息更新失败");

                base.DoSave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
            
        }
    }
}
