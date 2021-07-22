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
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(
             IConfiguration configuration,
             ILogger<CategoryRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("LoverMoneyConnection");
            _logger = logger;
        }

        public async Task<BaseValidate> DeleteCustomer(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Category_Delete";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    param.Add("@StatusCode", 0 , DbType.Int32, direction: ParameterDirection.InputOutput);
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

        public ResponseList<IEnumerable<Category>> GetCategories(FilterBase filter)
        {
            try
            {
                const string storeProcedureName = "lm_Category_Get_List";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@filter", filter.filter);
                    param.Add("@offset", filter.offSet);
                    param.Add("@pageSize", filter.pageSize);
                    param.Add("@total", 0, DbType.Int32, ParameterDirection.InputOutput);
                    param.Add("@totalFiltered", 0, DbType.Int32, ParameterDirection.InputOutput);
                    var category = connection.Query<Category>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    var result = new ResponseList<IEnumerable<Category>>(category, param.Get<int>("@total"), param.Get<int>("@totalFiltered"));
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<Category> GetCategoryById(string id)
        {
            try
            {
                const string storeProcedureName = "lm_Category_Get_By_Id";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    var category = await connection.QuerySingleAsync<Category>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return category;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetCategory(Category category)
        {
            try
            {
                const string storeProcedureName = "lm_Category_Set";
                using(SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", category.Id);
                    param.Add("@Name", category.Name);
                    param.Add("@Metadata", category.Metadata);
                    param.Add("@Icon", category.Icon);
                    param.Add("@ParentId", category.ParentId);
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
