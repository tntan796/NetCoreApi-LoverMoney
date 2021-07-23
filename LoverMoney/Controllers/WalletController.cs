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
        public IActionResult GetWallets([FromQuery] FilterBase filterBase)
        {
            var result = _walletService.GetWallets(filterBase);
            return Json(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetWalletById(string id)
        {
            var result = await _walletService.GetWalletById(id);
            return Json(result);
        }

        [HttpPost]
        public IActionResult SetWallet([FromForm] Wallet account)
        {
            var result = _walletService.SetWallet(account);
            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWallet(string id)
        {
            var result = await _walletService.DeleteWallet(id);
            return Json(result);
        }
    }
}