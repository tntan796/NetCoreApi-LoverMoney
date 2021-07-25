using BLL.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
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
        public BaseResponse<ResponseList<IEnumerable<AccountReponse>>> Get([FromQuery] FilterBase filterBase)
        {
           
            try
            {
                var result = _accountService.GetAccounts(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<AccountReponse>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<AccountReponse>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<AccountReponse>> GetAccountById(string id)
        {
            try
            {
                AccountReponse result = await _accountService.GetAccountById(id);
                return new BaseResponse<AccountReponse>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<AccountReponse>(ApiResult.Fail, null, ex.Message, ex.Message);
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<BaseResponse<string>> SetAccount([FromBody] AccountReponse account)
        {
            try
            {
                var result = await _accountService.SetAccount(account);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
           
        }

        [HttpPost("SetAccountUser")]
        [AllowAnonymous]
        public async Task<BaseResponse<string>> SetAccountUser([FromBody] AccountReponse account)
        {
            try
            {
                var result = await _accountService.SetAccountUser(account);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            var result = await _accountService.DeleteAccount(id);
            return Json(result);
        }
    }
}
