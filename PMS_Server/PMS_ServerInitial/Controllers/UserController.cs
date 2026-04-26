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
        [HttpGet]
        public ActionResult Get(string un, string pw)
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
    }
}
