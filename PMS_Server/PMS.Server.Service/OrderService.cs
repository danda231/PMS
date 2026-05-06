using PMS.Server.Entities;
using PMS.Server.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Server.Service
{
    public class OrderService : IOrderService
    {

        ISqlSugarClient _client;

        public OrderService(ISqlSugarClient client)
        {
            _client = client;
        }

        public int ChangeState(string id, int state)
        {
            return _client.Updateable<OrderEntity>()
                .SetColumns(fe => new OrderEntity() { State = state })
                .Where(oi => oi.OrderId == id).ExecuteCommand();
        }

        public int DeleteOrder(string id)
        {
            int count = 0;
            _client.Ado.BeginTran();
            try
            {
                count = _client.Deleteable<OrderEntity>().In(id).ExecuteCommand();

                _client.Deleteable<OrderImageEntity>()
                    .Where(oi => oi.OrderId == id).ExecuteCommand();
                _client.Ado.CommitTran();
            }catch (Exception ex)
            {
                _client.Ado.RollbackTran();
                throw ex;
            }
            return count;
        }

        public OrderEntity[] GetOrders(string key, int index, int size, ref int totalCount)
        {
            totalCount = 0;
            return _client.Queryable<OrderEntity>()
                .Where(e => string.IsNullOrEmpty(key) ||
                e.OrderId.Contains(key) || e.Description.Contains(key) || e.Address.Contains(key) ||
                e.Contacts.Contains(key) || e.Phone.Contains(key))
                .Select(e => new OrderEntity()
                {
                    Images = SqlFunc.Subqueryable<OrderImageEntity>().Where(ru => ru.OrderId == e.OrderId).ToList()
                }).ToPageList(index, size, ref totalCount).ToArray();
        }

        public int UpdateOrder(OrderEntity order)
        {
            try
            {
                _client.Ado.BeginTran();
                if (string.IsNullOrEmpty(order.OrderId))
                {
                    order.Title = "需求标题";
                    order.OrderId = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    foreach (var item in order.Images) item.OrderId = order.OrderId;
                    _client.Insertable(order.Images).ExecuteCommand();
                    _client.Insertable<OrderEntity>(order).ExecuteCommand();
                }
                else
                {
                    _client.Updateable<OrderEntity>(order).ExecuteCommand();
                    _client.Deleteable<OrderImageEntity>().Where(oi => oi.OrderId == order.OrderId).ExecuteCommand();
                    foreach (var item in order.Images) item.OrderId = order.OrderId;
                    _client.Insertable<OrderImageEntity>(order.Images).ExecuteCommand();
                }
                _client.Ado.CommitTran();
                return 1;
            }
            catch (Exception ex)
            {
                _client.Ado.RollbackTran();
                throw ex;
            }
            
        }
    }
}
