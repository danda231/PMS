using PMS.Client.Common;
using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.SystemModule.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.SystemModule.ViewModels.DialogModels
{
    public class SelectUserViewModel : DialogViewModelBase
    {
        private List<UserModel> _users;
        public ObservableCollection<UserModel> Users { get; set; } =
            new ObservableCollection<UserModel>();
        private string _fileText;
        public string FileText
        {
            get { return _fileText; }
            set
            {
                _fileText = value;
                Users.Clear();
                var us = _users.Where(u => 
                    string.IsNullOrWhiteSpace(value) ||
                    u.RealName.Contains(value) ||
                    u.UserName.Contains(value)).ToList();
                us.ForEach(u => Users.Add(u));
            }
        }
        private int _rid = 0;
        IUserService _userService;
        IRoleService _roleService;

        public SelectUserViewModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            this.Title = "选择用户";

            _rid = parameters.GetValue<int>("rid");
            var uids = parameters.GetValue<List<int>>("uids");

            // 获取所有用户
            var us = _userService.GetUsers("").ToList();
            _users = us.Select(u => new UserModel
            {
                IsSelected = uids.Contains(u.EId),
                UserId = u.EId,
                UserName = u.UserName,
                RealName = u.RealName,
                UserIcon = "http://localhost:5115/api/File/img/" + u.EIcon,
            }).ToList();
            _users.ForEach(u => Users.Add(u));
        }

        public override void DoSave()
        {
            try
            {
                List<RoleUser> rusers = new List<RoleUser>();
                foreach (var user in _users)
                {
                    if (!user.IsSelected) continue;
                    rusers.Add(new RoleUser
                    {
                        RoleId = _rid,
                        UserId = user.UserId
                    });
                }
                _roleService.UpdateRoleUsers(rusers.ToArray());

                base.DoSave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
            
        }
    }
}
