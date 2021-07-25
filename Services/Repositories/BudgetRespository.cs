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
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BudgetRespository : IBudgetRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<BudgetRespository> _logger;

        public BudgetRespository(
             IConfiguration configuration,
             ILogger<BudgetRespository> logger)
        {
            _connectionString = configuration.GetConnectionString("LoverMoneyConnection");
            _logger = logger;
        }
        public async Task<string> DeleteBudget(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Budget_Delete";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    await connection.QueryAsync<Budget>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return id;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<Budget> GetBudgetById(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Budget_Get_By_Id";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    var budget = await connection.QuerySingleAsync<Budget>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return budget;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Budget>> GetBudgets(FilterBase filter)
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
                    var wallet = connection.Query<Budget>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    var result = new ResponseList<IEnumerable<Budget>>(wallet, param.Get<int>("@total"), param.Get<int>("@totalFiltered"));
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetBudget(Budget budget)
        {
            try
            {
                const string storeProcedureName = "lm_Budget_Set";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", budget.Id);
                    param.Add("@Name", budget.Name);
                    param.Add("@Note", budget.Note);
                    param.Add("@Amount", budget.Amount);
                    param.Add("@CategoryId", budget.CategoryId);
                    param.Add("@CurrencyCode", budget.CurrencyCode);
                    param.Add("@StartDate", budget.StartDate);
                    param.Add("@EndDate", budget.EndDate);
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
