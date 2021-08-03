using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IWalletRepository
    {
        ResponseList<IEnumerable<Wallet>> GetWallets(FilterBase filter);
        Task<Wallet> GetWalletById(string id);
        string SetWallet(Wallet wallet);
        Task<string> DeleteWallet(string id);
        Task<string> UpdateAmount(string id, decimal amount, bool? isDelete = false);
        decimal GetBalance(string id, DateTime? fromDate, DateTime? toDate, bool updateWallet);
        void SetBalance(DateTime createAt, string walletId, decimal amount);

    }
}
