using BLL.Intefaces;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
        public BaseResponse<ResponseList<IEnumerable<User>>> GetAccounts([FromQuery] FilterBase filterBase)
        {
            try
            {
                ResponseList<IEnumerable<User>> result = _userService.GetUsers(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<User>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<User>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<User>> GetUserById(string id)
        {
            try
            {
                User result = await _userService.GetUserById(id);
                return new BaseResponse<User>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public async Task<BaseResponse<string>> SetUser([FromBody] User user)
        {
            try
            {
                string result = await _userService.SetUser(user);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> DeleteUser(string id)
        {
            try
            {
                string result = await _userService.DeleteUser(id);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }
    }
}
