using PMS.Client.Common;
using PMS.Client.IBll;
using PMS.Client.SystemModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.SystemModule.ViewModels.DialogModels
{
    public class ModifyUserViewModel : DialogViewModelBase
    {
        public UserModel UserInfo { get; set; } = new UserModel();
        public IUserService _userService;

        public ModifyUserViewModel(IUserService userService)
        {
            _userService = userService;
        }

        public bool IsReadOnlyUserName { get; set; }
        public override void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
            var model = parameters.GetValue<UserModel>("model");
            if (model == null)
            {
                Title = "新增用户信息";
                UserInfo = new UserModel(_userService);
                UserInfo.UserName = "";
                UserInfo.Gender = 1;
                UserInfo.Password = "123456";
                UserInfo.UserIcon = "a01.jpg";

            }
            else
            {
                Title = "编辑用户信息";
                IsReadOnlyUserName = true;

                UserInfo.UserId = model.UserId;
                UserInfo.UserName = model.UserName;
                UserInfo.Gender = model.Gender;
                UserInfo.RealName = model.RealName;
                UserInfo.Password = model.Password;
                UserInfo.Address = model.Address;
                UserInfo.Email = model.Email;
                UserInfo.Age = model.Age;
                UserInfo.Phone = model.Phone;

                string[] temp = model.UserIcon.Split("/");
                UserInfo.UserIcon = temp[temp.Length - 1];

            }
        }

        public override void DoSave()
        {
            if (UserInfo.HasErrors) return;
            try
            {
                var res = _userService.UpdateUser(new Entities.EmployEntity
                {
                    EId = UserInfo.UserId,
                    UserName = UserInfo.UserName,
                    RealName = UserInfo.RealName,
                    Password = UserInfo.Password,
                    EIcon = UserInfo.UserIcon,
                    Address = UserInfo.Address,
                    Age = (int)UserInfo.Age,
                    Status = 1,
                    Phone = UserInfo.Phone,
                    Gender = (int)UserInfo.Gender,
                });
                if (res == 0) throw new Exception("操作失败");

                // 完成后关闭窗口
                base.DoSave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        
    }
}
