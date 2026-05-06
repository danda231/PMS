using PMS.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IBll
{
    public interface IFeeService
    {
        PageEntity<FeeEntity[]> GetFees(string key, int pageIndex, int pageSize);

        FeeModeEntity[] GetFeeModes();

        int UpdateFee(FeeEntity fee);

        int DeleteFee(int id);

        int ChangeState(int id, int state);
    }
}
