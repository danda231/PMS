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
    public class OwnerController : ControllerBase
    {
        IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost("page/{index}/{size}")]
        [Authorize]
        public ActionResult GetOwners([FromBody]ConditionEntity[] conditions,[FromRoute] int index, [FromRoute] int size)
        {
            Result<Page<OwnerEntity[]>> result = new Result<Page<OwnerEntity[]>>();
            try
            {
                int total = 0;
                var os = _ownerService.GetOwners(conditions, index, size, ref total);

                // 添加一层分页信息
                Page<OwnerEntity[]> page = new Page<OwnerEntity[]>();
                page.PageIndex = index;
                page.PageSize = size;
                page.TotalCount = total;
                page.Data = os;

                result.Data = page;
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpGet("quarters")]
        [Authorize]
        public ActionResult GetQuarters()
        {
            Result<QuarterEntity[]> result = new Result<QuarterEntity[]>();
            try
            {
                result.Data = _ownerService.GetQuarters();
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpGet("buildings")]
        [Authorize]
        public ActionResult GetBuildingEntities()
        {
            Result<BuildingEntity[]> result = new Result<BuildingEntity[]>();
            try
            {
                result.Data = _ownerService.GetBuildingEntities();
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }
        [HttpGet("delete/{id}")]
        [Authorize]
        public ActionResult DeleteOwner(int id)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _ownerService.DeleteOwner(id);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpPost("update")]
        [Authorize]
        public ActionResult UpdateOwner(OwnerEntity owner)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _ownerService.UpdateOwner(owner);
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
