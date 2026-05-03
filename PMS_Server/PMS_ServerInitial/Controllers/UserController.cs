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
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService) { 
            _userService = userService;
        }
        [HttpPost("login")]
        public ActionResult Get([FromForm]string un, [FromForm] string pw)
        {
            ///结果做好封装
            ///{
            ///   "xxx": xxx,
            ///}
            Result<SysEmployee> result = new Result<SysEmployee>();
            try
            {
                var data = _userService.CheckLogin(un, pw);
                if (data == null) 
                { 
                    result.State = 404;
                    result.ExceptionMessage = "用户名或密码错误";
                }else result.Data = data;
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }
        [HttpGet("test")]
        [Authorize]
        public ActionResult Test()
        {
            var authHeader = Request.Headers["Authorization"];
            Console.WriteLine("Header原始值: " + authHeader);
            return Ok();
        }

        [HttpPost("update_pwd")]
        [Authorize]
        public ActionResult UpdatePassword([FromForm] int id, [FromForm] string old_password, [FromForm] string new_password)
        {
            Result<bool> result = new Result<bool>();
            try
            {
                _userService.UpdatePassword(id, old_password, new_password);
                result.Data = true;
            }catch(Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }

            return Ok(result);
        }

        [HttpGet("list/{key}")]
        [Authorize]
        public ActionResult GetUsers([FromRoute] string key)
        {
            Result<SysEmployee[]> result = new Result<SysEmployee[]>();
            try
            {
                key = key == "none" ? "" : key;
                result.Data = _userService.GetUsers(key);
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }

            return Ok(result);
        } // GetUsersByIds

        [HttpPost("ids")]
        [Authorize]
        public ActionResult GetUsersByIds(int[] ids)
        {
            Result<SysEmployee[]> result = new Result<SysEmployee[]>();
            try
            {
                
                result.Data = _userService.GetUsersByIds(ids);
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
        public ActionResult Update(SysEmployee employee)
        {
            Result<int> result = new Result<int>();
            try
            {
                var data = _userService.UpdateUser(employee);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpPost("update_roles")]
        [Authorize]
        public ActionResult UpdateUserRoles(RoleUser[] roles)
        {
            Result<int> result = new Result<int>();
            try
            {
                var data = _userService.UpdateUserRoles(roles);
                result.Data = data;
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
        public ActionResult Delete([FromRoute] int id)
        {
            Result<int> result = new Result<int>();
            try
            {
                var data = _userService.Delete(id);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpGet("lock/{id}/{status}")]
        [Authorize]
        public ActionResult LockUser(int id, int status)
        {
            Result<bool> result = new Result<bool>();
            try
            {
                var data = _userService.LockUser(id, status);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpGet("reset_pwd/{id}")]
        [Authorize]
        public ActionResult ResetPassword(int id)
        {
            Result<int> result = new Result<int>();
            try
            {
                var data = _userService.ResetPassword(id);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpGet("check/{username}/{id}")]
        [Authorize]
        public ActionResult CheckUserName(string username, int id)
        {
            Result<bool> result = new Result<bool>();
            try
            {
                var data = _userService.CheckUserName(username, id);
                result.Data = data;
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
