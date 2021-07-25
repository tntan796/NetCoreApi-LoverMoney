using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IWalletService
    {
        ResponseList<IEnumerable<Wallet>> GetWallets(FilterBase filter);
        Task<Wallet> GetWalletById(string id);
        string SetWallet(Wallet wallet);
        Task<string> DeleteWallet(string id);
    }
}
