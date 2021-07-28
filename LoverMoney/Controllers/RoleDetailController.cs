using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoverMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleDetailController : Controller
    {
        IRoleDetailService _roleDetailService;

        public RoleDetailController(
             IRoleDetailService roleDetailService
            )
        {
            this._roleDetailService = roleDetailService;

        }

        [HttpGet]
        public BaseResponse<ResponseList<IEnumerable<RoleDetail>>> Get([FromQuery] FilterBase filterBase)
        {
            try
            {
                ResponseList<IEnumerable<RoleDetail>> result = _roleDetailService.GetRoleDetails(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<RoleDetail>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<RoleDetail>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<RoleDetail>> GetRoleDetailById(string id)
        {
            try
            {
                RoleDetail result = await _roleDetailService.GetRoleDetailById(id);
                return new BaseResponse<RoleDetail>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<RoleDetail>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public BaseResponse<string> SetCategory([FromBody] RoleDetail roleDetail)
        {
            try
            {
                string result = _roleDetailService.SetRoleDetail(roleDetail);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> DeleteRoleDetail(string id)
        {
            try
            {
                string result = await _roleDetailService.DeleteRoleDetail(id);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }
    }
}
