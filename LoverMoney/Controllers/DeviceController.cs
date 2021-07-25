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
        public IActionResult GetDevices([FromQuery] FilterBase filterBase)
        {
            var result = _deviceService.GetDevices(filterBase);
            return Json(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDeviceById(string id)
        {
            var result = await _deviceService.GetDeviceById(id);
            return Json(result);
        }

        [HttpPost]
        public IActionResult SetDevice([FromBody] Device device)
        {
            var result = _deviceService.SetDevice(device);
            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(string id)
        {
            var result = await _deviceService.DeleteDevice(id);
            return Json(result);
        }
    }
}