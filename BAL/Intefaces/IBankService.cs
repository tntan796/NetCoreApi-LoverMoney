using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IBankService
    {
        ResponseList<IEnumerable<Bank>> GetBanks(FilterBase filter);
        Task<Bank> GetBankById(string id);
        Task<string> SetBank(Bank bank);
        Task<BaseValidate> DeleteBank(string id);
    }
}
