using BLL.Intefaces;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class RoleController : Controller
    {
        IRoleService _roleService;
        public RoleController(
             IRoleService roleService
            )
        {
            this._roleService = roleService;

        }

        [HttpGet]
        public BaseResponse<ResponseList<IEnumerable<Role>>> GetRoles([FromQuery] FilterBase filterBase)
        {
            try
            {
                ResponseList<IEnumerable<Role>> result = _roleService.GetRoles(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<Role>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<Role>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<Role>> GetRoleById(string id)
        {
            try
            {
                Role result = await _roleService.GetRoleById(id);
                return new BaseResponse<Role>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Role>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public BaseResponse<string> SetRole([FromBody] Role role)
        {
            try
            {
                string result = _roleService.SetRole(role);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> DeleteRole(string id)
        {
            try
            {
                string result = await _roleService.DeleteRole(id);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }
    }
}
