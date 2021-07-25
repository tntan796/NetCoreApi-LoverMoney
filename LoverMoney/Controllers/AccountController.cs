using BLL.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;
using System.Threading.Tasks;

namespace LoverMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : Controller
    {
        IAccountService _accountService;

        public AccountController(
             IAccountService accountService
            )
        {
            this._accountService = accountService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] FilterBase filterBase)
        {
            var result = _accountService.GetAccounts(filterBase);
            return Json(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAccountById(string id)
        {
            var result = await _accountService.GetAccountById(id);
            return Json(result);
        }

        [HttpPost]
        public IActionResult SetAccount([FromForm] Account account)
        {
            var result = _accountService.SetAccount(account);
            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            var result = await _accountService.DeleteAccount(id);
            return Json(result);
        }
    }
}
