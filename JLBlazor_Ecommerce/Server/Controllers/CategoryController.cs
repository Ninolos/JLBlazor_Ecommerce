using JLBlazor_Ecommerce.Server.Services.CategoryService;
using JLBlazor_Ecommerce.Shared.Models;
using JLBlazor_Ecommerce.Shared;
using Microsoft.AspNetCore.Mvc;

namespace JLBlazor_Ecommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories = _categoryService.GetCategories();

            if (categories.Result.Data.Any())
            {
                return Ok(categories.Result);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
