using PMS.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Server.IService
{
    public interface IOrderService
    {
        OrderEntity[] GetOrders(string key, int index, int size, ref int totalCount);

        int UpdateOrder(OrderEntity order);

        int ChangeState(string id, int state);

        int DeleteOrder(string id);
    }
}
