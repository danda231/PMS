using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.Entities;
using PMS.Server.IService;
using PMS.Server.Models;

namespace PMS.ServerInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        IRoleService _roleService;
        public RoleController(IRoleService roleService) { _roleService = roleService; }

        [HttpPost("list")]
        [Authorize]
        public ActionResult GetRoleByIds(int[] id)
        {
            Result<SysRole[]> res = new Result<SysRole[]>();
            try
            {
                res.Data = _roleService.GetRoleByIds(id);
            }catch (Exception ex)
            {
                res.State = 500;
                res.ExceptionMessage = ex.Message;
            }

            return Ok(res);
        }

        [HttpPost("remenus")]
        [Authorize]
        public ActionResult UpdateRoleMenus(RoleMenu[] rms)
        {
            Result<int> res = new Result<int>();
            try
            {
                res.Data = _roleService.UpdateRoleMenus(rms);
            }
            catch (Exception ex)
            {
                res.State = 500;
                res.ExceptionMessage = ex.Message;
            }
            return Ok(res);
        }

        [HttpPost("reusers")]
        [Authorize]
        public ActionResult UpdateRoleUsers(RoleUser[] rms)
        {
            Result<int> res = new Result<int>();
            try
            {
                res.Data = _roleService.UpdateRoleUsers(rms);
            }
            catch (Exception ex)
            {
                res.State = 500;
                res.ExceptionMessage = ex.Message;
            }

            return Ok(res);
        }
        [HttpGet("all/{key}")]
        [Authorize]
        public ActionResult GetAllRoles(string key)
        {
            Result<SysRole[]> res = new Result<SysRole[]>();
            try
            {
                key = key == "none" ? "" : key;
                res.Data = _roleService.GetAllRoles(key);
            }
            catch (Exception ex)
            {
                res.State = 500;
                res.ExceptionMessage = ex.Message;
            }

            return Ok(res);
        }

        [HttpGet("check/{id}/{roleName}")]
        [Authorize]
        public ActionResult CheckRoleName(string roleName, int id)
        {
            Result<bool> res = new Result<bool>();
            try
            {
                res.Data = _roleService.CheckRoleName(roleName,id);
            }
            catch (Exception ex)
            {
                res.State = 500;
                res.ExceptionMessage = ex.Message;
            }

            return Ok(res);
        }

        [HttpPost("update")]
        [Authorize]
        public ActionResult Update(SysRole sysRole)
        {
            Result<int> res = new Result<int>();
            try
            {
                res.Data = _roleService.Update(sysRole);
            }
            catch (Exception ex)
            {
                res.State = 500;
                res.ExceptionMessage = ex.Message;
            }

            return Ok(res);
        }

        [HttpGet("delete/{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            Result<int> res = new Result<int>();
            try
            {
                res.Data = _roleService.Delete(id);
            }
            catch (Exception ex)
            {
                res.State = 500;
                res.ExceptionMessage = ex.Message;
            }

            return Ok(res);
        }

        [HttpGet("del_user/{uid}/{rid}")]
        [Authorize]
        public ActionResult DeleteRoleUser(int rid, int uid)
        {
            Result<int> res = new Result<int>();
            try
            {
                res.Data = _roleService.DeleteRoleUser(rid, uid);
            }
            catch (Exception ex)
            {
                res.State = 500;
                res.ExceptionMessage = ex.Message;
            }

            return Ok(res);
        }
    }
}
