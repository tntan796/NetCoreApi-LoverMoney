using System.Threading.Tasks;
using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;

namespace LoverMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {

        ITransactionService _transactionService;

        public TransactionController(
             ITransactionService transactionService
            )
        {
            this._transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult GetTransactions([FromQuery] FilterBase filterBase)
        {
            var result = _transactionService.GetTransactions(filterBase);
            return Json(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTransactionById(string id)
        {
            var result = await _transactionService.GetTransactionById(id);
            return Json(result);
        }

        [HttpPost]
        public IActionResult SetTransaction([FromForm] Transaction trransaction)
        {
            var result = _transactionService.SetTransaction(trransaction);
            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(string id)
        {
            var result = await _transactionService.DeleteTransaction(id);
            return Json(result);
        }
    }
}