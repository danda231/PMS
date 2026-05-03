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



        [HttpGet("all/{key}")]
        [Authorize]
        public ActionResult GetAllMenus([FromRoute] string key)
        {
            Result<MenuEntity[]> res = new Result<MenuEntity[]>();
            try
            {
                key = key == "none" ? "" : key;
                res.Data = _menuService.GetAllMenus(key).ToArray();
                
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
        public ActionResult Update(MenuEntity menu)
        {
            Result<int> result = new Result<int>();
            try
            {
                var ms = _menuService.Update(menu);
                result.Data = ms;

            }catch (Exception ex)
            {
                result.State = 500;
                result.ExceptionMessage = ex.Message;
            }

            return Ok(result);
        }

        [HttpGet("delete/{id}")]
        [Authorize]
        public ActionResult Delete([FromRoute]string id)
        {
            Result<int> result = new Result<int>();
            try
            {
                var ms = _menuService.Delete(id);
                result.Data = ms;

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
