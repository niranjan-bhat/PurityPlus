using PurityPlus.Services.Classes;
using PurityPlus.Services.DTO;
using PurityPlus.Services.FilterParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.Services.Interface
{
    public interface IOrderService
    {
        Task<OrderDTO> CreateOrder(CreateOrderModel order);
        PagedResponse<OrderDTO> GetAllOrder(PaginationFilter PaginationFilter, OrderFilter OrderFilter);
        OrderDTO UpdatePayment(OrderDTO order);
    }
}
