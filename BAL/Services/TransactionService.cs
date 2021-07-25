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
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<Transaction> _logger;

        public TransactionService(
            ITransactionRepository transactionRepository, ILogger<Transaction> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public Task<string> DeleteTransaction(string id)
        {
            try
            {
                return this._transactionRepository.DeleteTransaction(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<TransactionResponse> GetTransactionById(string id)
        {
            try
            {
                return this._transactionRepository.GetTransactionById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<TransactionResponse>> GetTransactions(FilterBase filter)
        {
            try
            {
                return this._transactionRepository.GetTransactions(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetTransaction(Transaction transaction)
        {
            try
            {
                return this._transactionRepository.SetTransaction(transaction);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
