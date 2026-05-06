using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using PMS.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PMS.Client.Bll
{
    public class OrderService : ServiceBase, IOrderService
    {
        IOrderAccess _orderAccess;

        public OrderService(IOrderAccess orderAccess)
        {
            _orderAccess = orderAccess;
        }

        public int ChangeState(string id, int state)
        {
            string json = _orderAccess.ChangeState(id, state);
            return this.GetResult<int>(json);
        }

        public int DeleteOrders(string id)
        {
            string json = _orderAccess.DeleteOrders(id);
            return this.GetResult<int>(json);
        }

        public PageEntity<OrderEntity[]> GetOrders(string key, int pageIndex, int pageSize)
        {
            string json = _orderAccess.GetOrders(key, pageIndex, pageSize);
            return this.GetResult<PageEntity<OrderEntity[]>> (json);
        }

        public int UpdateOrder(OrderEntity entity)
        {
            string json = JsonUtil.Serializer(entity);
            json = _orderAccess.UpdateOrders(json);
            return this.GetResult<int>(json);
        }
    }
}
