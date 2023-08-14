using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurityPlus.Database.Entity;
using PurityPlus.Services.Classes;
using PurityPlus.Services.DTO;
using PurityPlus.Services.FilterParams;
using PurityPlus.Services.Interface;

namespace PurityPlus.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(CategoryDTO Category) {

            _categoryService.AddCategory(Category);

            return Ok();
        
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationFilter pagination, [FromQuery] CategoryFilter CategoryFilter) 
        { 
            return Ok(_categoryService.GetAllCategories(pagination, CategoryFilter));
        }
    }
}
