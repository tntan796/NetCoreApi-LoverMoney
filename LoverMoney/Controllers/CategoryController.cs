using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;

namespace LoverMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(
             ICategoryService categoryService
            )
        {
            this._categoryService = categoryService;

        }

        [HttpGet]
        public BaseResponse<ResponseList<IEnumerable<Category>>> Get([FromQuery]FilterBase filterBase)
        {
            try
            {
                ResponseList<IEnumerable<Category>> result = _categoryService.GetCategories(filterBase);
                return new BaseResponse<ResponseList<IEnumerable<Category>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<Category>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<Category>> GetCategoryById(string id)
        {
            try
            {
                Category result = await _categoryService.GetCategoryById(id);
                return new BaseResponse<Category>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Category>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public BaseResponse<string> SetCategory([FromBody] Category category)
        {
            try
            {
                string result = _categoryService.SetCategory(category);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> DeleteCategory(string id)
        {
            try
            {
                string result = await _categoryService.DeleteCategory(id);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }
    }
}