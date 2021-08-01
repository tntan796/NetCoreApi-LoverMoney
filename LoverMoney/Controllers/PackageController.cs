using BLL.Intefaces;
using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace LoverMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PackageController : Controller
    {
        IPackageService _packageService;
        public PackageController(
             IPackageService packageService
            )
        {
            this._packageService = packageService;
        }

        [HttpGet]
        public BaseResponse<ResponseList<IEnumerable<Package>>> GetPackages([FromQuery] FilterBasePackage filterBase)
        {
            try
            {
                ResponseList<IEnumerable<Package>> result = _packageService.GetPackages(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<Package>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<Package>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<Package>> GetPackageById(string id)
        {
            try
            {
                Package result = await _packageService.GetPackageById(id);
                return new BaseResponse<Package>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Package>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public async Task<BaseResponse<string>> SetPackage([FromBody] Package package)
        {
            try
            {
                string result = await _packageService.SetPackage(package);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, "", ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> DeletePackage(string id)
        {
            try
            {
                string result = await _packageService.DeletePackage(id);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, "", ex.Message, ex.Message);
            }
        }
    }
}
