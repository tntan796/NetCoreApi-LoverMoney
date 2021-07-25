using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBudgetRepository
    {
        ResponseList<IEnumerable<Budget>> GetBudgets(FilterBase filter);
        Task<Budget> GetBudgetById(string id);
        string SetBudget(Budget budget);
        Task<string> DeleteBudget(string id);
    }
}
