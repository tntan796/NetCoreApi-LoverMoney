using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IUserService
    {
        ResponseList<IEnumerable<Category>> GetCategories(FilterBase filter);
        Task<Category> GetCategoryById(string id);
        Task<string> AddCategory(Category category);
        Task<bool> UpdateCategory(Category category);
        Task<bool> DeleteCustomer(string id);
    }
}
