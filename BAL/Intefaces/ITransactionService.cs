using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface ITransactionService
    {
        ResponseList<IEnumerable<TransactionResponse>> GetTransactions(FilterBase filter);
        Task<TransactionResponse> GetTransactionById(string id);
        string SetTransaction(Transaction transaction);
        Task<string> DeleteTransaction(string id);
        Task<IEnumerable<TransactionRangeDate>> GetTransactionRangeDate(DateTime? startDate, DateTime? endDate);
    }
}
