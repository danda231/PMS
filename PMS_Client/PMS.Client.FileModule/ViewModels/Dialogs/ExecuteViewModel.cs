using PMS.Client.Common;
using PMS.Client.Entities;
using PMS.Client.FileModule.Models;
using PMS.Client.IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.FileModule.ViewModels.Dialogs
{
    public class ExecuteViewModel : DialogViewModelBase
    {
        public ContractModel ContractInfo { get; set; } = new ContractModel();
        // 待执行金额
        public decimal PendingAmount { get; set; }

        private decimal _executeAmount;
        // 输入的执行金额
        public decimal ExecuteAmount
        {
            get { return _executeAmount; }
            set
            {
                _executeAmount = value;
                ErrorList.Clear();
                if (value == 0)
                    ErrorList.Add("ExecuteAmount", new List<string> { "请输入有效执行金额" });
                else if (value > PendingAmount)
                    ErrorList.Add("ExecuteAmount", new List<string> { "输入的执行金额超出待执行金额" });

                RaiseErrorsChanged();
            }
        }


        IContractService _contractService;

        public ExecuteViewModel(IContractService contractService)
        {
            Title = "合同金额执行";
            _contractService = contractService;
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            var model = parameters.GetValue<ContractModel>("model");
            if (model != null)
            {
                ContractInfo.ContractId = model.ContractId;
                ContractInfo.ContractNumber = model.ContractNumber;
                ContractInfo.ContractName = model.ContractName;

                ContractInfo.Opposite = model.Opposite;
                ContractInfo.Operator = model.Operator;
                ContractInfo.ContractAmount = model.ContractAmount;
                ContractInfo.ExcuteAmount = model.ExcuteAmount;

                ContractInfo.State = model.State;

                // 待执行金额
                PendingAmount = model.ContractAmount - model.ExcuteAmount;
            }
        }

        public override void DoSave()
        {
            if (this.HasErrors) return;
            try
            {
                ContractEntity entity = new ContractEntity();
                entity.ContractId = ContractInfo.ContractId;
                entity.State = ContractInfo.State;
                entity.ExcuteAmount = ExecuteAmount + ContractInfo.ExcuteAmount;

                if (entity.ExcuteAmount >= ContractInfo.ContractAmount) entity.State = 2; // 任务完成
                var count = _contractService.Execute(entity);
                if (count == 0)
                {
                    throw new Exception("执行失败");
                }
                base.DoSave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
