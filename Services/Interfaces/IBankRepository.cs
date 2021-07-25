using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBankRepository
    {
        ResponseList<IEnumerable<Bank>> GetBanks(FilterBase filter);
        Task<Bank> GetBankById(string id);
        Task<string> SetBank(Bank bank);
        Task<string> DeleteBank(string id);
    }
}
