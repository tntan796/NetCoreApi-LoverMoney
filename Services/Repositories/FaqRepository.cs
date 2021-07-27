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
    public class FaqRepository : IFaqRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<FaqRepository> _logger;

        public FaqRepository(
             IConfiguration configuration,
             ILogger<FaqRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("LoverMoneyConnection");
            _logger = logger;
        }
        public async Task<int> DeleteFaq(int id)
        {
            try
            {
                const string storeProcedureName = "lm_Faq_Delete";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    await connection.QueryAsync<Faq>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return id;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<Faq> GetFaqById(int id)
        {
            try
            {
                const string storeProcedureName = "lm_Faq_Get_By_Id";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    var faq = await connection.QuerySingleAsync<Faq>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return faq;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Faq>> GetFaqs(FilterBase filter)
        {
            try
            {
                const string storeProcedureName = "lm_Faq_Get_List";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@filter", filter.filter);
                    param.Add("@offset", filter.offSet);
                    param.Add("@pageSize", filter.pageSize);
                    param.Add("@total", 0, DbType.Int32, ParameterDirection.InputOutput);
                    param.Add("@totalFiltered", 0, DbType.Int32, ParameterDirection.InputOutput);
                    var account = connection.Query<Faq>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    var result = new ResponseList<IEnumerable<Faq>>(account, param.Get<int>("@total"), param.Get<int>("@totalFiltered"));
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<int> SetFaq(Faq faq)
        {
            try
            {
                const string storeProcedureName = "lm_Faq_Set";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", faq.Id);
                    param.Add("@Question", faq.Question);
                    param.Add("@Answer", faq.Answer);
                    param.Add("@System", faq.System);
                    param.Add("@OutputRequestId", "", DbType.String, ParameterDirection.InputOutput);
                    var result = await connection.ExecuteAsync(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return param.Get<int>("@OutputRequestId");
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
