using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IAccountService
    {
        ResponseList<IEnumerable<Account>> GetAccounts(FilterBase filter);
        Task<Account> GetAccountById(string id);
        string SetAccount(Account account);
        Task<BaseValidate> DeleteAccount(string id);
    }
}
