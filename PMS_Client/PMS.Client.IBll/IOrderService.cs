using PMS.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IBll
{
    public interface IOrderService
    {
        PageEntity<OrderEntity[]> GetOrders(string key, int pageIndex, int pageSize);

        int UpdateOrder(OrderEntity entity);

        int DeleteOrders(string id);

        int ChangeState(string id, int state);
    }
}
