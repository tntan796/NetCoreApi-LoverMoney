using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;
using System.Threading.Tasks;

namespace LoverMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControler : Controller
    {
        IUserService _userService;

        public UserControler(
             IUserService userService
            )
        {
            this._userService = userService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] FilterBase filterBase)
        {
            var result = _userService.GetUsers(filterBase);
            return Json(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _userService.GetUserById(id);
            return Json(result);
        }

        [HttpPost]
        public IActionResult SetUser([FromForm] User user)
        {
            var result = _userService.SetUser(user);
            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUser(id);
            return Json(result);
        }
    }
}
