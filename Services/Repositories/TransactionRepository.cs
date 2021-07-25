using DAL.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<TransactionRepository> _logger;

        public TransactionRepository(
             IConfiguration configuration,
             ILogger<TransactionRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("LoverMoneyConnection");
            _logger = logger;
        }

        public async Task<string> DeleteTransaction(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Transaction_Delete";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    await connection.QueryAsync<Category>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return id;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<TransactionResponse> GetTransactionById(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Transaction_Get_By_Id";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    var transaction = await connection.QuerySingleAsync<TransactionResponse>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return transaction;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<TransactionResponse>> GetTransactions(FilterBase filter)
        {
            try
            {
                const string storeProcedureName = "lm_Transaction_Get_List";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@filter", filter.filter);
                    param.Add("@offset", filter.offSet);
                    param.Add("@pageSize", filter.pageSize);
                    param.Add("@total", 0, DbType.Int32, ParameterDirection.InputOutput);
                    param.Add("@totalFiltered", 0, DbType.Int32, ParameterDirection.InputOutput);
                    var account = connection.Query<TransactionResponse>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    var result = new ResponseList<IEnumerable<TransactionResponse>>(account, param.Get<int>("@total"), param.Get<int>("@totalFiltered"));
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetTransaction(Transaction transaction)
        {
            try
            {
                const string storeProcedureName = "lm_Transaction_Set";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", transaction.Id);
                    param.Add("@Name", transaction.Name);
                    param.Add("@Amount", transaction.Amount);
                    param.Add("@CreateAt", transaction.CreateAt);
                    param.Add("@ExportReport", transaction.ExportReport);
                    param.Add("@Note", transaction.Note);
                    param.Add("@Remind", transaction.Remind);
                    param.Add("@Image", transaction.Image);
                    param.Add("@Campaign", transaction.Campaign);
                    param.Add("@Latitude", transaction.Latitude);
                    param.Add("@Longtitude", transaction.Longtitude);
                    param.Add("@AccountId", transaction.AccountId);
                    param.Add("@CategoryId", transaction.CategoryId);
                    param.Add("@EditByUserId", transaction.EditByUserId);
                    param.Add("@With", transaction.With);
                    param.Add("@Metadata", transaction.Metadata);
                    param.Add("@WalletId", transaction.WalletId);

                    param.Add("@OutputRequestId", "", DbType.String, ParameterDirection.InputOutput);
                    var result = connection.Execute(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return param.Get<string>("@OutputRequestId");

                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
