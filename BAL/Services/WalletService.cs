using BLL.Intefaces;
using DAL.Interfaces;
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
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<Wallet> _logger;

        public WalletService(
            IWalletRepository walletRepository, ILogger<Wallet> logger)
        {
            _walletRepository = walletRepository;
            _logger = logger;
        }
        public Task<string> DeleteWallet(string id)
        {
            try
            {
                return this._walletRepository.DeleteWallet(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public decimal GetBalance(string id, DateTime fromDate, DateTime toDate, bool updateWallet)
        {
            try
            {
                return this._walletRepository.GetBalance(id, fromDate, toDate, updateWallet);
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
                return this._walletRepository.GetWalletById(id);
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
                return this._walletRepository.GetWallets(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public void SetBalance(DateTime createAt, string walletId, decimal amount)
        {
            try
            {
                this._walletRepository.SetBalance(createAt, walletId, amount);
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
                return this._walletRepository.SetWallet(wallet);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<string> UpdateAmount(string id, decimal amount, bool? isDelete = false)
        {
            try
            {
                return this._walletRepository.UpdateAmount(id, amount, isDelete);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
