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
        Task<string> SetAccount(Account account);
        Task<string> DeleteAccount(string id);
        Task<AccountReponse> GetAccountByUserNamePassword(string userName, string password);
        Task<AccountReponse> GetAccountByUserName(string userName);
        Task<string> SetAccountUser(AccountReponse account);
    }
}
