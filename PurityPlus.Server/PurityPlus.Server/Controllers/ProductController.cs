using Amazon.Runtime;
using Microsoft.AspNetCore.Authorization;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

       
        [HttpPost]
        public async Task<IActionResult> Post(ProductPostApiModel product)
        {
            try
            {
                await _productService.AddProduct(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid ProductId)
        {
           return Ok(_productService.GetProductById(ProductId));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationFilter pagination, [FromQuery] ProductFilter productFilter) {

            return Ok(_productService.GetProducts(pagination, productFilter));
        }
    }
}
