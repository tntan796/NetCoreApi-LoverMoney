using BLL.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Authen;
using Models.Common;
using System;
using System.Threading.Tasks;

namespace LoverMoney.Controllers
{
    public class AuthenticationController : Controller
    {
        private IAccountService _accountService;

        public AuthenticationController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<BaseResponse<AuthenticateResponse>> Authenticate([FromBody] AuthenticateRequest model)
        {
            try
            {
                var response = await _accountService.Authenticate(model);
                return new BaseResponse<AuthenticateResponse>(ApiResult.Success, response, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<AuthenticateResponse>(ApiResult.Fail, null, ex.Message, ex.Message);
            }

        }
    }
}