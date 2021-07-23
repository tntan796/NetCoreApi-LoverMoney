using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IWalletRepository
    {
        ResponseList<IEnumerable<Wallet>> GetWallets(FilterBase filter);
        Task<Wallet> GetWalletById(string id);
        string SetWallet(Wallet wallet);
        Task<BaseValidate> DeleteWallet(string id);
    }
}
