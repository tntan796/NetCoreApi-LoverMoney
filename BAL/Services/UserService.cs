using BLL.Intefaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Implements
{
    public class UserService : IUserService
    {
        private readonly ICategoryRepository _categoryRepository;
        public Task<string> AddCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteCustomer(string id)
        {
            throw new System.NotImplementedException();
        }

        public ResponseList<IEnumerable<Category>> GetCategories(FilterBase filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> GetCategoryById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateCategory(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
