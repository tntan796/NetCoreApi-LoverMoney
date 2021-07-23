using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAccountRepository
    {
        ResponseList<IEnumerable<AccountReponse>> GetAccounts(FilterBase filter);
        Task<AccountReponse> GetAccountById(string id);
        string SetAccount(Account account);
        Task<BaseValidate> DeleteAccount(string id);
    }
}
