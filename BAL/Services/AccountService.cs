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
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _categoryRepository;
        private readonly ILogger<Account> _logger;

        public AccountService(
            IAccountRepository categoryRepository, ILogger<Account> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public Task<BaseValidate> DeleteAccount(string id)
        {
            try
            {
                return this._categoryRepository.DeleteAccount(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<AccountReponse> GetAccountById(string id)
        {
            try
            {
                return this._categoryRepository.GetAccountById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<AccountReponse>> GetAccounts(FilterBase filter)
        {
            try
            {
                return this._categoryRepository.GetAccounts(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetAccount(Account account)
        {
            try
            {
                return this._categoryRepository.SetAccount(account);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
