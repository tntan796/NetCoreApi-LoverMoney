using BLL.Intefaces;
using Microsoft.Extensions.Logging;
using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletService _walletService;
        private readonly ILogger<Wallet> _logger;

        public WalletService(
            IWalletService walletService, ILogger<Wallet> logger)
        {
            _walletService = walletService;
            _logger = logger;
        }
        public Task<BaseValidate> DeleteWallet(string id)
        {
            try
            {
                return this._walletService.DeleteWallet(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<Wallet> GetWalletById(string id)
        {
            try
            {
                return this._walletService.GetWalletById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Wallet>> GetWallets(FilterBase filter)
        {
            try
            {
                return this._walletService.GetWallets(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetWallet(Wallet wallet)
        {
            try
            {
                return this._walletService.SetWallet(wallet);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
