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
    public class BankRepository : IBankRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<BankRepository> _logger;

        public BankRepository(
             IConfiguration configuration,
             ILogger<BankRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("LoverMoneyConnection");
            _logger = logger;
        }
        public async Task<string> DeleteBank(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Bank_Delete";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    await connection.QueryAsync<Bank>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return id;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<Bank> GetBankById(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Bank_Get_By_Id";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    var bank = await connection.QuerySingleAsync<Bank>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return bank;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Bank>> GetBanks(FilterBase filter)
        {
            try
            {
                const string storeProcedureName = "lm_Bank_Get_List";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@filter", filter.filter);
                    param.Add("@offset", filter.offSet);
                    param.Add("@pageSize", filter.pageSize);
                    param.Add("@total", 0, DbType.Int32, ParameterDirection.InputOutput);
                    param.Add("@totalFiltered", 0, DbType.Int32, ParameterDirection.InputOutput);
                    var account = connection.Query<Bank>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    var result = new ResponseList<IEnumerable<Bank>>(account, param.Get<int>("@total"), param.Get<int>("@totalFiltered"));
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<string> SetBank(Bank bank)
        {
            try
            {
                const string storeProcedureName = "lm_Bank_Set";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", bank.Id);
                    param.Add("@Name", bank.Name);
                    param.Add("@CountryCode", bank.CountryCode);
                    param.Add("@Icon", bank.Icon);
                    param.Add("@MetaSearch", bank.MetaSearch);
                    param.Add("@Otp", bank.Otp);
                    param.Add("@IsFree", bank.IsFree);
                    param.Add("@IsDebug", bank.IsDebug);
                    param.Add("@HasBalance", bank.HasBalance);
                    param.Add("@Browser", bank.Browser);
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
    }
}
