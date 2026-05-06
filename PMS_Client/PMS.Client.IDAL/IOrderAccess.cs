using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IDAL
{
    public interface IOrderAccess
    {

        string GetOrders(string key, int pageIndex, int pageSize);

        string UpdateOrders(string json);

        string DeleteOrders(string id);

        string ChangeState(string id, int state);
    }
}
