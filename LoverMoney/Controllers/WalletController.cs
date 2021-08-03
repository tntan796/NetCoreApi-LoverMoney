using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;

namespace LoverMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalletController : Controller
    {
        IWalletService _walletService;

        public WalletController(
             IWalletService walletService
            )
        {
            this._walletService = walletService;
        }

        [HttpGet]
        public BaseResponse<ResponseList<IEnumerable<Wallet>>> GetWallets([FromQuery] FilterBase filterBase)
        {
            try
            {
                ResponseList<IEnumerable<Wallet>> result = _walletService.GetWallets(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<Wallet>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<Wallet>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<Wallet>> GetWalletById(string id)
        {
            try
            {
                Wallet result = await _walletService.GetWalletById(id);
                return new BaseResponse<Wallet>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Wallet>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public BaseResponse<string> SetWallet([FromBody] Wallet account)
        {
            try
            {
                string result = _walletService.SetWallet(account);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> DeleteWallet(string id)
        {
            try
            {
                string result = await _walletService.DeleteWallet(id);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpGet("GetBalance")]
        public BaseResponse<decimal> GetBalance(string id, DateTime? fromDate = null, DateTime? toDate = null, bool updateWallet = false)
        {
            try
            {
                decimal result = _walletService.GetBalance(id, fromDate, toDate, updateWallet);
                return new BaseResponse<decimal>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<decimal>(ApiResult.Fail, -1, ex.Message, ex.Message);
            }
        }
        [HttpPost("SetBalance")]
        public BaseResponse<string> SetBalance(DateTime createAt, string walletId, decimal amount)
        {
            try
            {
                _walletService.SetBalance(createAt, walletId, amount);
                return new BaseResponse<string>(ApiResult.Success, "", null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }
        [HttpPut("UpdateAmount")]
        public async Task<BaseResponse<string>> UpdateAmount(string id, decimal amount, bool? isDelete = false)
        {
            try
            {
                string result = await _walletService.UpdateAmount(id, amount, isDelete);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }
    }
}