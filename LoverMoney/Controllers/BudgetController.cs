using System.Threading.Tasks;
using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;

namespace LoverMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : Controller
    {
        IBudgetService _budgetService;

        public BudgetController(
             IBudgetService budgetService
            )
        {
            this._budgetService = budgetService;
        }

        [HttpGet]
        public IActionResult GetBudgets([FromQuery] FilterBase filterBase)
        {
            var result = _budgetService.GetBudgets(filterBase);
            return Json(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBudgetById(string id)
        {
            var result = await _budgetService.GetBudgetById(id);
            return Json(result);
        }

        [HttpPost]
        public IActionResult SetBudget([FromBody] Budget account)
        {
            var result = _budgetService.SetBudget(account);
            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget(string id)
        {
            var result = await _budgetService.DeleteBudget(id);
            return Json(result);
        }
    }
}