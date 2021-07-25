using BLL.Intefaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;
        private readonly ILogger<Bank> _logger;

        public BankService(
            IBankRepository bankRepository, ILogger<Bank> logger)
        {
            _bankRepository = bankRepository;
            _logger = logger;
        }

        public Task<string> DeleteBank(string id)
        {
            try
            {
                return this._bankRepository.DeleteBank(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<Bank> GetBankById(string id)
        {
            try
            {
                return this._bankRepository.GetBankById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Bank>> GetBanks(FilterBase filter)
        {
            try
            {
                return this._bankRepository.GetBanks(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<string> SetBank(Bank bank)
        {
            try
            {
                return this._bankRepository.SetBank(bank);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
