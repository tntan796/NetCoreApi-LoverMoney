using System;
using System.Collections.Generic;
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
    public class StatusController : Controller
    {
        IStatusService _statusService;

        public StatusController(
             IStatusService statusService
            )
        {
            this._statusService = statusService;
        }

        [HttpGet]
        public BaseResponse<ResponseList<IEnumerable<Status>>> GetStatus([FromQuery] FilterBase filterBase)
        {
            try
            {
                ResponseList<IEnumerable<Status>> result = _statusService.GetStatus(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<Status>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<Status>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<Status>> GetStatusById(int id)
        {
            try
            {
                Status result = await _statusService.GetStatusById(id);
                return new BaseResponse<Status>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Status>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public async Task<BaseResponse<string>> SetStatus([FromBody] Status status)
        {
            try
            {
                string result = await _statusService.SetStatus(status);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> DeleteStatus(int id)
        {
            try
            {
                int result = await _statusService.DeleteStatus(id);
                return new BaseResponse<string>(ApiResult.Success, result.ToString(), null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }
    }
}