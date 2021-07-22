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
    public class UserRepsitory : IUserRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<UserRepsitory> _logger;

        public UserRepsitory(
             IConfiguration configuration,
             ILogger<UserRepsitory> logger)
        {
            _connectionString = configuration.GetConnectionString("LoverMoneyConnection");
            _logger = logger;
        }
        public async Task<BaseValidate> DeleteUser(string id)
        {
            try
            {
                const string storeProcedureName = "lm_User_Delete";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    param.Add("@StatusCode", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                    param.Add("@Message", "", DbType.String, direction: ParameterDirection.InputOutput);
                    var category = await connection.QueryAsync<User>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return new BaseValidate(param.Get<int>("@StatusCode"), param.Get<string>("@Message"));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<User> GetUserById(string id)
        {
            try
            {
                const string storeProcedureName = "lm_User_Get_By_Id";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    var category = await connection.QuerySingleAsync<User>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return category;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<User>> GetUsers(FilterBase filter)
        {
            try
            {
                const string storeProcedureName = "lm_User_Get_List";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@filter", filter.filter);
                    param.Add("@offset", filter.offSet);
                    param.Add("@pageSize", filter.pageSize);
                    param.Add("@total", 0, DbType.Int32, ParameterDirection.InputOutput);
                    param.Add("@totalFiltered", 0, DbType.Int32, ParameterDirection.InputOutput);
                    var account = connection.Query<User>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    var result = new ResponseList<IEnumerable<User>>(account, param.Get<int>("@total"), param.Get<int>("@totalFiltered"));
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetUser(User user)
        {
            try
            {
                const string storeProcedureName = "lm_User_Set";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", user.Id);
                    param.Add("@FirstName", user.FirstName);
                    param.Add("@LastName", user.LastName);
                    param.Add("@Email", user.Email);
                    param.Add("@Address", user.Address);
                    param.Add("@Phone", user.Phone);
                    param.Add("@IdentityNo", user.IdentityNo);
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
