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
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<WalletRepository> _logger;

        public WalletRepository(
             IConfiguration configuration,
             ILogger<WalletRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("LoverMoneyConnection");
            _logger = logger;
        }
        public async Task<string> DeleteWallet(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Wallet_Delete";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    await connection.QueryAsync<Wallet>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return id;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }


        public async Task<Wallet> GetWalletById(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Wallet_Get_By_Id";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    var wallet = await connection.QuerySingleAsync<Wallet>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return wallet;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Wallet>> GetWallets(FilterBase filter)
        {
            try
            {
                const string storeProcedureName = "lm_Wallet_Get_List";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@filter", filter.filter);
                    param.Add("@offset", filter.offSet);
                    param.Add("@pageSize", filter.pageSize);
                    param.Add("@total", 0, DbType.Int32, ParameterDirection.InputOutput);
                    param.Add("@totalFiltered", 0, DbType.Int32, ParameterDirection.InputOutput);
                    var wallet = connection.Query<Wallet>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    var result = new ResponseList<IEnumerable<Wallet>>(wallet, param.Get<int>("@total"), param.Get<int>("@totalFiltered"));
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetWallet(Wallet wallet)
        {
            try
            {
                const string storeProcedureName = "lm_Wallet_Set";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", wallet.Id);
                    param.Add("@Name", wallet.Name);
                    param.Add("@UserId", wallet.UserId);
                    param.Add("@Amount", wallet.Amount);
                    param.Add("@Icon", wallet.Icon);
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

        public async Task<string> UpdateAmount(string id, decimal amount, bool? isDelete = false)
        {
            try
            {
                const string storeProcedureName = "lm_Wallet_Set";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    param.Add("@Amount", amount);
                    param.Add("@IsDelete", isDelete);
                    param.Add("@OutputRequestId", "", DbType.String, ParameterDirection.InputOutput);
                    var result = await connection.ExecuteAsync(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return param.Get<string>("@OutputRequestId");
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }


        public void SetBalance(DateTime createAt, string walletId, decimal amount)
        {
            try
            {
                const string storeProcedureName = "lm_Wallet_Balance_Set";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@CreateAt", createAt);
                    param.Add("@WalletId", walletId);
                    param.Add("@Amount", amount);
                    connection.Execute(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public decimal GetBalance(string id, DateTime fromDate, DateTime toDate, bool updateWallet)
        {
            try
            {
                const string storeProcedureName = "lm_Wallet_Get_Balance";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    param.Add("@FromDate", fromDate);
                    param.Add("@ToDate", toDate);
                    param.Add("@UpdateWallet", updateWallet);
                    decimal result = connection.QueryFirstOrDefault(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return result;
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
