using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;
using System.Threading.Tasks;

namespace LoverMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : Controller
    {
        IBankService _bankService;

        public BankController(
             IBankService bankService
            )
        {
            this._bankService = bankService;
        }

        [HttpGet]
        public IActionResult GetBanks([FromQuery] FilterBase filterBase)
        {
            var result = _bankService.GetBanks(filterBase);
            return Json(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBankById(string id)
        {
            var result = await _bankService.GetBankById(id);
            return Json(result);
        }

        [HttpPost]
        public IActionResult SetBank([FromBody] Bank bank)
        {
            var result = _bankService.SetBank(bank);
            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank(string id)
        {
            var result = await _bankService.DeleteBank(id);
            return Json(result);
        }
    }
}
