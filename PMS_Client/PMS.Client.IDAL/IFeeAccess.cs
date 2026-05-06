using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IDAL
{
    public interface IFeeAccess
    {
        string GetFees(string key, int pageIndex, int pageSize);

        string GetFeeModes();

        string UpdateFee(string fee_Json);

        string DeleteFee(int id);
        string ChangeState(int id, int state);
    }
}
