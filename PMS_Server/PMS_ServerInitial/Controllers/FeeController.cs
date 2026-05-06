using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.Entities;
using PMS.Server.IService;
using PMS.Server.Models;

namespace PMS.ServerInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeController : ControllerBase
    {
        IFeeService _feeService;

        public FeeController(IFeeService feeService)
        {
            _feeService = feeService;
        }

        [HttpGet("page/{key}/{index}/{size}")]
        public IActionResult GetFees(string key, int index, int size)
        {
            Result<Page<FeeEntity[]>> result = new Result<Page<FeeEntity[]>>();
            try
            {
                key = (key == "none" ? "" : key);
                int total = 0;
                var bis = _feeService.GetFees(key, index, size, ref total);
                Page<FeeEntity[]> page = new Page<FeeEntity[]>();
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

        [HttpGet("feemodel")]
        public IActionResult GetFeeModes()
        {
            Result<FeeModeEntity[]> result = new Result<FeeModeEntity[]>();
            try
            {
                result.Data = _feeService.GetFeeModes();
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpGet("delete/{id}")]
        public IActionResult DeleteFee(int id)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _feeService.DeleteFee(id);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }
        [HttpGet("state/{id}/{state}")]
        public IActionResult ChangeState(int id, int state)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _feeService.ChangeState(id, state);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateFee(FeeEntity feeEntity)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _feeService.UpdateFee(feeEntity);
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
