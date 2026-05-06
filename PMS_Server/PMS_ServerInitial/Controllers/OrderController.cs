using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.Entities;
using PMS.Server.IService;
using PMS.Server.Models;
using PMS.Server.Service;

namespace PMS.ServerInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("page/{key}/{index}/{size}")]
        public IActionResult GetOrders(string key, int index, int size)
        {
            Result<Page<OrderEntity[]>> result = new Result<Page<OrderEntity[]>>();
            try
            {
                key = (key == "none" ? "" : key);
                int total = 0;
                var bis = _orderService.GetOrders(key, index, size, ref total);
                Page<OrderEntity[]> page = new Page<OrderEntity[]>();
                page.PageIndex = index;
                page.PageSize = size;
                page.TotalCount = total;
                page.Data = bis;
                result.Data = page;
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult UpdateOrder(OrderEntity order)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _orderService.UpdateOrder(order);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpGet("delete/{id}")]
        public IActionResult DeleteOrder(string id)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _orderService.DeleteOrder(id);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }
        [HttpGet("state/{id}/{state}")]
        public IActionResult ChangeState(string id, int state)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _orderService.ChangeState(id, state);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }
    }
}
