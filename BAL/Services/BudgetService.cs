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
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly ILogger<Budget> _logger;

        public BudgetService(
            IBudgetRepository budgetRepository, ILogger<Budget> logger)
        {
            _budgetRepository = budgetRepository;
            _logger = logger;
        }

        public Task<BaseValidate> DeleteBudget(string id)
        {
            try
            {
                return this._budgetRepository.DeleteBudget(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<Budget> GetBudgetById(string id)
        {
            try
            {
                return this._budgetRepository.GetBudgetById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Budget>> GetBudgets(FilterBase filter)
        {
            try
            {
                return this._budgetRepository.GetBudgets(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetBudget(Budget budget)
        {
            try
            {
                return this._budgetRepository.SetBudget(budget);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
