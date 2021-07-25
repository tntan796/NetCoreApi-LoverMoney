using Models;
using Models.Authen;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IAccountService
    {
        ResponseList<IEnumerable<AccountReponse>> GetAccounts(FilterBase filter);
        Task<AccountReponse> GetAccountById(string id);
        Task<string> SetAccount(AccountReponse account);
        Task<string> DeleteAccount(string id);
        string GenerateJwtToken(AccountReponse account);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<string> SetAccountUser(AccountReponse account);
    }
}
