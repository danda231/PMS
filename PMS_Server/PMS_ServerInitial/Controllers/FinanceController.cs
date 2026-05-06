using Microsoft.AspNetCore.Authorization;
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
    public class FinanceController : ControllerBase
    {
        IFinanceService _financeService;

        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpGet("page/{key}/{start}/{end}/{index}/{size}")]
        [Authorize]
        public IActionResult GetDatas(string key, string start, string end, int index, int size)
        {
            
            Result<Page<IEEntity[]>> res = new Result<Page<IEEntity[]>>();

            try
            {
                key = key == "none" ? "" : key;
                int totalCount = 0;
                var data = _financeService.GetDatas(key, DateTime.Parse(start), DateTime.Parse(end), index,size,ref totalCount);
                Page<IEEntity[]> page = new Page<IEEntity[]>();
                page.PageIndex = index;
                page.PageSize = size;
                page.TotalCount = totalCount;
                page.Data = data;
                res.Data = page;
            }catch (Exception ex)
            {
                res.State = 500;
                res.ExceptionMessage = ex.Message;
            }

            return Ok(res);
        }

        [HttpGet("delete/{id}")]
        public IActionResult DeleteInfo(int id)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _financeService.DeleteInfo(id);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }
        [HttpGet("state/{id}/{state}")]
        public IActionResult ChangeInfo(int id, int state)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _financeService.ChangeState(id, state);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateInfo(IEEntity entity)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _financeService.UpdateInfo(entity);
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
