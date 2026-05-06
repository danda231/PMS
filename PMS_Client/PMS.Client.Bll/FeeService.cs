using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using PMS.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Bll
{
    public class FeeService : ServiceBase, IFeeService
    {
        IFeeAccess _feeAccess;

        public FeeService(IFeeAccess feeAccess)
        {
            _feeAccess = feeAccess;
        }

        public int ChangeState(int id, int state)
        {
            string json = _feeAccess.ChangeState(id, state);
            return this.GetResult<int>(json);
        }

        public int DeleteFee(int id)
        {
            string json = _feeAccess.DeleteFee(id);
            return this.GetResult<int>(json);
        }

        public FeeModeEntity[] GetFeeModes()
        {
            string json = _feeAccess.GetFeeModes();
            return this.GetResult<FeeModeEntity[]>(json);
        }

        public PageEntity<FeeEntity[]> GetFees(string key, int pageIndex, int pageSize)
        {
            string json = _feeAccess.GetFees(key, pageIndex, pageSize);
            return this.GetResult<PageEntity<FeeEntity[]>>(json);
        }

        public int UpdateFee(FeeEntity fee)
        {
            string json = JsonUtil.Serializer(fee);
            json = _feeAccess.UpdateFee(json);
            return this.GetResult<int>(json);
        }
    }
}
