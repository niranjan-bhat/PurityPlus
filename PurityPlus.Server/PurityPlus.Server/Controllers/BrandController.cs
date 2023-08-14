using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurityPlus.Services.Classes;
using PurityPlus.Services.DTO;
using PurityPlus.Services.FilterParams;
using PurityPlus.Services.Interface;
using PurityPlus.Services.Services;

namespace PurityPlus.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService BrandService)
        {
            _brandService = BrandService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(BrandDTO brand)
        {
            _brandService.AddBrand(brand);

            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationFilter pagination, [FromQuery] BrandFilter brandFilter)
        {

            return Ok(_brandService.GetAllBrands(pagination, brandFilter));
        }
    }
}
