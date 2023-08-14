using AutoMapper;
using PurityPlus.Database.Entity;
using PurityPlus.Database.Repository;
using PurityPlus.Services.Classes;
using PurityPlus.Services.DTO;
using PurityPlus.Services.FilterParams;
using PurityPlus.Services.Interface;
using PurityPlus.Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.Services
{
    public class OrderService : IOrderService
    {
        public IUnitOfWork _unitOfWork { get; }
        public IMapper _mapper { get; }
        public PaginationService<Order, OrderDTO> _paginationService { get; }

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, PaginationService<Order, OrderDTO> paginationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paginationService = paginationService;
        }


        public async Task<OrderDTO> CreateOrder(CreateOrderModel order)
        {
            var newOrder = new Order();
            newOrder.OrderId = Guid.NewGuid();
            newOrder.ApplicationUserId = order.ApplicationUserId;
            newOrder.CreatedAt = DateTime.UtcNow;
            newOrder.UpdatedAt = DateTime.UtcNow;
            newOrder.ShippingAddress = order.ShippingAddress;
            newOrder.BillingAddress = order.BillingAddress;
            newOrder.Status = "Active";
            var totalOrderAmount = 0;
            newOrder.OrderItems = new List<OrderItem>();
            foreach (var orderItems in order.OrderItems)
            {
                var product = await _unitOfWork.GetRepository<Product>().GetById(orderItems.ProductId);
                newOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = product.ProductId,
                    UnitPrice = orderItems.Quantity,
                    Quantity = orderItems.Quantity,
                    TotalPrice = (decimal)(orderItems.Quantity * product.DiscountedPrice),
                });
                totalOrderAmount = (int)(totalOrderAmount + (orderItems.Quantity * product.DiscountedPrice));
            }
            newOrder.TotalAmount = totalOrderAmount;
            newOrder.Payment = new Payment()
            {
                Status = "Paid",
                Amount = totalOrderAmount,
                PaymentMethod = "Net Banking",
            };
            _unitOfWork.GetRepository<Order>().Add(newOrder);
            _unitOfWork.SaveChanges();

            var insertedOrder = _unitOfWork.GetRepository<Order>().GetById(newOrder.OrderId);
            return _mapper.Map<OrderDTO>(insertedOrder);
        }

        public PagedResponse<OrderDTO> GetAllOrder(PaginationFilter PaginationFilter, OrderFilter OrderFilter)
        {
            IQueryable<Order> query = _unitOfWork.GetRepository<Order>().GetWithInclude(x => x.ApplicationUser, y => y.Payment).OrderByDescending(x=>x.CreatedAt);
            if (OrderFilter.OrderId.HasValue)
            {
                query = query.Where(x => x.OrderId == OrderFilter.OrderId.Value);
            }
            if (OrderFilter.ApplicationUserId.HasValue)
            {
                query = query.Where(x => x.ApplicationUserId == OrderFilter.ApplicationUserId.Value);
            }

            return _paginationService.GetPagedResponse(query, PaginationFilter);
        }

        public OrderDTO UpdatePayment(OrderDTO order)
        {
            throw new NotImplementedException();
        }
    }
}
