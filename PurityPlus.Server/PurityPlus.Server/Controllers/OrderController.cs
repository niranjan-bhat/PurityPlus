using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurityPlus.Services.Classes;
using PurityPlus.Services.DTO;
using PurityPlus.Services.FilterParams;
using PurityPlus.Services.Services.Interface;

namespace PurityPlus.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService OrderService)
        {
            _orderService = OrderService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationFilter PaginationFilter, [FromQuery] OrderFilter OrderFilter) 
        {
            return Ok(_orderService.GetAllOrder(PaginationFilter, OrderFilter));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderModel Order)
        {
            await _orderService.CreateOrder(Order);
            return Ok();
        }
    }
}
