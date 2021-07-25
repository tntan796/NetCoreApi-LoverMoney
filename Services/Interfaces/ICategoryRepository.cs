using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Common;

namespace DAL.Interfaces
{
    public interface ICategoryRepository
    {
        ResponseList<IEnumerable<Category>> GetCategories(FilterBase filter);
        Task<Category> GetCategoryById(string id);
        string SetCategory(Category category);
        Task<string> DeleteCustomer(string id);
    }
}
