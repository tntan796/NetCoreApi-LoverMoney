using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITransactionRepository
    {
        ResponseList<IEnumerable<TransactionResponse>> GetTransactions(FilterBase filter);
        Task<TransactionResponse> GetTransactionById(string id);
        string SetTransaction(Transaction transaction);
        Task<string> DeleteTransaction(string id);
    }
}
