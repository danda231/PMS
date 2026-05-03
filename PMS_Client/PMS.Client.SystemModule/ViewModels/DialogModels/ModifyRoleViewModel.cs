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
    public class ModifyRoleViewModel:DialogViewModelBase
    {
        public int RoleId { get; set; }
        public string _rolename;
        
        public string RoleName 
        { 
            get {  return _rolename; }
            set 
            { 
                _rolename = value; 
                this.ErrorList.Clear();
                // 不能为空
                if(string.IsNullOrEmpty(value)) ErrorList.Add("RoleName",new List<string> { "角色名不能为空！" });
                // 不能重复
                if (!string.IsNullOrEmpty(value) && _roleService.CheckRoleName(value, RoleId))
                    this.ErrorList.Add("RoleName", new List<string> { "角色名不能重复！" });

                this.RaiseErrorsChanged();
            }
        }
        public string RoleDesc { get; set; }

        IRoleService _roleService;
        public ModifyRoleViewModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            var role = parameters.GetValue<RoleModel>("model");
            if (role == null)
            {
                this.Title = "新增角色权限组";
                RoleName = "";
            }
            else
            {
                this.Title = "编辑角色权限组";
                RoleId = role.RoleId;
                RoleName = role.RoleName;
                RoleDesc = role.RoleDesc;
            }
        }
        public override void DoSave()
        {
            if (this.HasErrors) return;
            try
            {
                var count = _roleService.UpdateRole(new Entities.SysRole
                {
                    RoleId = this.RoleId,
                    RoleName = this.RoleName,
                    RoleDesc = this.RoleDesc,
                    State = 1
                });
                if (count == 0) throw new Exception("操作失败");
                base.DoSave();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        
    }
}
