using System.Threading.Tasks;
using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;

namespace LoverMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult GetStatus([FromQuery] FilterBase filterBase)
        {
            var result = _statusService.GetStatus(filterBase);
            return Json(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStatusById(int id)
        {
            var result = await _statusService.GetStatusById(id);
            return Json(result);
        }

        [HttpPost]
        public IActionResult SetStatus([FromForm] Status status)
        {
            var result = _statusService.SetStatus(status);
            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var result = await _statusService.DeleteStatus(id);
            return Json(result);
        }
    }
}