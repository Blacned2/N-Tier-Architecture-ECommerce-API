using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Data.Models;
using System.Collections.Generic;

namespace OnlineLezzetler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet, Route("CategoryList")]
        public ActionResult<List<Category>> GetCategoryList()
        {
            var CategoryList = _categoryService.GetCategoryList();
            return CategoryList.ResultObject;
        }

        [HttpGet, Route("Category/{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var Category = _categoryService.GetCategory(id);
            return Category.ResultObject;
        }

        [HttpPost, Route("Category")]
        public ActionResult PostCategory(Category model)
        {
            var result = _categoryService.AddCategory(model);
            return Ok();
        }

        [HttpDelete, Route("CategoryDelete/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            return Ok();
        }

        [HttpPut, Route("CategoryEdit/{id}")]
        public ActionResult EditCategory(int id, Category model)
        {
            var result = _categoryService.EditCategory(id, model);
            return Ok();
        }
    }
}
