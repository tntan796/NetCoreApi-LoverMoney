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
        public BaseResponse<ResponseList<IEnumerable<TransactionResponse>>> GetTransactions([FromQuery] FilterBase filterBase)
        {
            try
            {
                ResponseList<IEnumerable<TransactionResponse>> result = _transactionService.GetTransactions(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<TransactionResponse>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<TransactionResponse>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<TransactionResponse>> GetTransactionById(string id)
        {
            try
            {
                TransactionResponse result = await _transactionService.GetTransactionById(id);
                return new BaseResponse<TransactionResponse>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TransactionResponse>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public BaseResponse<string> SetTransaction([FromBody] Transaction transaction)
        {
            try
            {
                string result = _transactionService.SetTransaction(transaction);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> DeleteTransaction(string id)
        {
            try
            {
                string result = await _transactionService.DeleteTransaction(id);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }
    }
}