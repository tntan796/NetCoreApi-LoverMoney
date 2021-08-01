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
    public class FaqController : Controller
    {
        IFaqService _faqService;

        public FaqController(
             IFaqService faqService
            )
        {
            this._faqService = faqService;
        }

        [HttpGet]
        public BaseResponse<ResponseList<IEnumerable<Faq>>> GetFaqs([FromQuery] FilterBase filterBase)
        {
            try
            {
                ResponseList<IEnumerable<Faq>> result = _faqService.GetFaqs(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<Faq>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<Faq>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<Faq>> GetFaqById(int id)
        {
            try
            {
                Faq result = await _faqService.GetFaqById(id);
                return new BaseResponse<Faq>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Faq>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public async Task<BaseResponse<int>> SetFaq([FromBody] Faq faq)
        {
            try
            {
                int result = await _faqService.SetFaq(faq);
                return new BaseResponse<int>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(ApiResult.Fail, -1, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<int>> DeleteFaq(int id)
        {
            try
            {
                int result = await _faqService.DeleteFaq(id);
                return new BaseResponse<int>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(ApiResult.Fail, -1, ex.Message, ex.Message);
            }
        }
    }
}