using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.IService;

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
            return Ok(_userService.CheckLogin(un, pw));
        }
    }
}
