using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.Entities;
using PMS.Server.IService;
using PMS.Server.Models;

namespace PMS.ServerInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }



        [HttpGet("all")]
        [Authorize]
        public ActionResult GetAllMenus()
        {
            Result<MenuEntity[]> res = new Result<MenuEntity[]>();
            try
            {
                res.Data = _menuService.GetAllMenus().ToArray();
                
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
