using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get([FromQuery]FilterBase filterBase)
        {
            var result = _categoryService.GetCategories(filterBase);
            //return new BaseResponse<IEnumerable<Customer>>(ApiResult.Success, result);
            return Json(result);
        }
    }
}