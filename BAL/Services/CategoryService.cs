using BLL.Intefaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<Category> _logger;

        public CategoryService(
            ICategoryRepository categoryRepository, ILogger<Category> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public string SetCategory(Category category)
        {
            try
            {
                return this._categoryRepository.SetCategory(category);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<BaseValidate> DeleteCategory(string id)
        {
            try
            {
                return await this._categoryRepository.DeleteCustomer(id);
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
                var result = this._categoryRepository.GetCategories(filter);
                return result;
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
                return await this._categoryRepository.GetCategoryById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
