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

    }
}
