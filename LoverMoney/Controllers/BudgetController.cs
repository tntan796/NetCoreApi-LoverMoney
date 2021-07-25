using System;
using System.Collections.Generic;
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
        public BaseResponse<ResponseList<IEnumerable<Budget>>> GetBudgets([FromQuery] FilterBase filterBase)
        {
            try
            {
                ResponseList<IEnumerable<Budget>> result = _budgetService.GetBudgets(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<Budget>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<Budget>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<Budget>> GetBudgetById(string id)
        {
            try
            {
                Budget result = await _budgetService.GetBudgetById(id);
                return new BaseResponse<Budget>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Budget>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public BaseResponse<string> SetBudget([FromBody] Budget account)
        {
            try
            {
                string result = _budgetService.SetBudget(account);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> DeleteBudget(string id)
        {
            try
            {
                string result = await _budgetService.DeleteBudget(id);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }
    }
}