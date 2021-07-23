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
        string SetAccount(Account account);
        Task<BaseValidate> DeleteAccount(string id);
        string GenerateJwtToken(Account account);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }
}
