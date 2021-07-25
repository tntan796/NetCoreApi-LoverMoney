using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;

namespace LoverMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : Controller
    {
        IDeviceService _deviceService;

        public DeviceController(
             IDeviceService deviceService
            )
        {
            this._deviceService = deviceService;
        }

        [HttpGet]
        public BaseResponse<ResponseList<IEnumerable<Device>>> GetDevices([FromQuery] FilterBase filterBase)
        {
            try
            {
                ResponseList<IEnumerable<Device>> result = _deviceService.GetDevices(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<Device>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<Device>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<Device>> GetDeviceById(string id)
        {
            try
            {
                Device result = await _deviceService.GetDeviceById(id);
                return new BaseResponse<Device>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Device>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public BaseResponse<string> SetDevice([FromBody] Device device)
        {
            try
            {
                string result = _deviceService.SetDevice(device);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> DeleteDevice(string id)
        {
            try
            {
                string result = await _deviceService.DeleteDevice(id);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }
    }
}