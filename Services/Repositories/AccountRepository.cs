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
    public class AccountRepository : IAccountRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<AccountRepository> _logger;

        public AccountRepository(
             IConfiguration configuration,
             ILogger<AccountRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("LoverMoneyConnection");
            _logger = logger;
        }
        public async Task<string> DeleteAccount(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Account_Delete";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    param.Add("@StatusCode", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                    param.Add("@Message", "", DbType.String, direction: ParameterDirection.InputOutput);
                    var category = await connection.QueryAsync<Account>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return id;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<AccountReponse> GetAccountById(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Account_Get_By_Id";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    var account = await connection.QuerySingleAsync<AccountReponse>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return account;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<AccountReponse> GetAccountByUserNamePassword(string userName, string password)
        {
            try
            {
                const string storeProcedureName = "lm_Account_Get_By_UserName_Password";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@UserName", userName);
                    param.Add("@Password", password);
                    var account = await connection.QueryFirstOrDefaultAsync<AccountReponse>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return account;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<AccountReponse>> GetAccounts(FilterBase filter)
        {
            try
            {
                const string storeProcedureName = "lm_Account_Get_List";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@filter", filter.filter);
                    param.Add("@offset", filter.offSet);
                    param.Add("@pageSize", filter.pageSize);
                    param.Add("@total", 0, DbType.Int32, ParameterDirection.InputOutput);
                    param.Add("@totalFiltered", 0, DbType.Int32, ParameterDirection.InputOutput);
                    var account = connection.Query<AccountReponse>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    var result = new ResponseList<IEnumerable<AccountReponse>>(account, param.Get<int>("@total"), param.Get<int>("@totalFiltered"));
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<string> SetAccountUser(AccountReponse account)
        {
            try
            {
                const string storeProcedureName = "lm_Account_Create_User";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", account.Id);
                    param.Add("@UserName", account.UserName);
                    param.Add("@Password", account.Password);
                    param.Add("@CreatedDate", account.CreatedDate);
                    param.Add("@CreatedBy", account.CreateBy);
                    param.Add("@StatusId", account.StatusId);
                    param.Add("@OldPassword", account.OldPassword);
                    param.Add("@UserId", account.UserId);
                    param.Add("@FirstName", account.FirstName);
                    param.Add("@LastName", account.LastName);
                    param.Add("@Email", account.Email);
                    param.Add("@Address", account.Address);
                    param.Add("@Phone", account.Phone);
                    param.Add("@IdentityNo", account.IdentityNo);
                    param.Add("@IsVip", account.IsVip);
                    param.Add("@RoleId", account.RoleId);
                    param.Add("@OutputRequestId", "", DbType.String, ParameterDirection.InputOutput);
                    var result = await connection.ExecuteAsync(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    var id = param.Get<string>("@OutputRequestId");
                    return id;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<string> SetAccount(Account account)
        {
            try
            {
                const string storeProcedureName = "lm_Account_Set";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", account.Id);
                    param.Add("@UserName", account.UserName);
                    param.Add("@Password", account.Password);
                    param.Add("@CreatedDate", account.CreatedDate);
                    param.Add("@CreatedBy", account.CreateBy);
                    param.Add("@StatusId", account.StatusId);
                    param.Add("@OldPassword", account.OldPassword);
                    param.Add("@UserId", account.UserId);
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

        public async Task<AccountReponse> GetAccountByUserName(string userName)
        {
            try
            {
                const string storeProcedureName = "lm_Account_Get_By_UserName";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@UserName", userName);
                    var account = await connection.QueryFirstOrDefaultAsync<AccountReponse>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return account;
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
