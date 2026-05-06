using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.Entities;
using PMS.Server.IService;
using PMS.Server.Models;
using System.Drawing;
using System;

namespace PMS.ServerInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BIController : ControllerBase
    {
        IBaseInfoService _baseInfoService;
        public BIController(IBaseInfoService baseInfoService)
        {
            _baseInfoService = baseInfoService;
        }


        [HttpGet("page/{key}/{index}/{size}")]
        [Authorize]
        public ActionResult GetAllBaseInfo(string key, int index, int size)
        {
            Result<Page<BaseInfo[]>> result = new Result<Page<BaseInfo[]>>();
            try
            {
                key = (key == "none" ? "" : key);
                int total = 0;
                var bis = _baseInfoService.GetBaseInfos(key, index, size, ref total);

                // 添加一层分页信息
                Page<BaseInfo[]> page = new Page<BaseInfo[]>();
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
        [Authorize]
        public ActionResult UpdateInfo(BaseInfo baseInfo)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _baseInfoService.UpdateBaseInfo(baseInfo);
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
        public ActionResult DeleteInfo(int id)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _baseInfoService.DeleteBaseInfo(id);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpGet("cancel/{id}")]
        [Authorize]
        public ActionResult CancelState(int id)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _baseInfoService.CancelState(id);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }
        [HttpGet("publish/{id}")]
        [Authorize]
        public ActionResult PublishState(int id)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _baseInfoService.PublishState(id);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }
        [HttpGet("revoke/{id}")]
        [Authorize]
        public ActionResult RevokeState(int id)
        {
            Result<int> result = new Result<int>();
            try
            {
                result.Data = _baseInfoService.RevokeState(id);
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
