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
        public async Task<BaseValidate> DeleteWallet(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Wallet_Delete";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    param.Add("@StatusCode", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                    param.Add("@Message", "", DbType.String, direction: ParameterDirection.InputOutput);
                    var category = await connection.QueryAsync<Category>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return new BaseValidate(param.Get<int>("@StatusCode"), param.Get<string>("@Message"));
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
    }
}
