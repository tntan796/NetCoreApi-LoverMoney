using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface ICategoryService
    {
        ResponseList<IEnumerable<Category>> GetCategories(FilterBase filter);
        Task<Category> GetCategoryById(string id);
        string SetCategory(Category category);
        Task<BaseValidate> DeleteCategory(string id);
    }
}
