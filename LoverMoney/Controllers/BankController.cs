using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;
using System;
using System.Collections.Generic;
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
        public BaseResponse<ResponseList<IEnumerable<Bank>>> GetBanks([FromQuery] FilterBase filterBase)
        {
            try
            {
                ResponseList<IEnumerable<Bank>> result = _bankService.GetBanks(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<Bank>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<Bank>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<Bank>> GetBankById(string id)
        {
            try
            {
                Bank result = await _bankService.GetBankById(id);
                return new BaseResponse<Bank>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Bank>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public async Task<BaseResponse<string>> SetBank([FromBody] Bank bank)
        {
            try
            {
                string result = await _bankService.SetBank(bank);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> DeleteBank(string id)
        {
            try
            {
                string result = await _bankService.DeleteBank(id);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }
    }
}
