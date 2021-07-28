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
    public class RoleDetailRepository : IRoleDetailRepository
    {

        private readonly string _connectionString;
        private readonly ILogger<RoleDetailRepository> _logger;

        public RoleDetailRepository(
             IConfiguration configuration,
             ILogger<RoleDetailRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("LoverMoneyConnection");
            _logger = logger;
        }

        public async Task<string> DeleteRoleDetail(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Role_Detail_Delete";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    await connection.QueryAsync<RoleDetail>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return id;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<RoleDetail> GetRoleDetailById(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Role_Detail_Get_By_Id";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    var category = await connection.QuerySingleAsync<RoleDetail>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return category;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<RoleDetail>> GetRoleDetails(FilterBase filter)
        {
            try
            {
                const string storeProcedureName = "lm_Role_Detail_Get_List";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@filter", filter.filter);
                    param.Add("@offset", filter.offSet);
                    param.Add("@pageSize", filter.pageSize);
                    param.Add("@total", 0, DbType.Int32, ParameterDirection.InputOutput);
                    param.Add("@totalFiltered", 0, DbType.Int32, ParameterDirection.InputOutput);
                    var category = connection.Query<RoleDetail>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    var result = new ResponseList<IEnumerable<RoleDetail>>(category, param.Get<int>("@total"), param.Get<int>("@totalFiltered"));
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetRoleDetail(RoleDetail roleDetail)
        {
            try
            {
                const string storeProcedureName = "lm_Role_Detail_Set";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", roleDetail.Id);
                    param.Add("@RoleId", roleDetail.RoleId);
                    param.Add("@ActionName", roleDetail.ActionName);
                    param.Add("@ActionCode", roleDetail.ActionCode);
                    param.Add("@Description", roleDetail.Description);
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
