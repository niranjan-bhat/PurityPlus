using PurityPlus.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.DTO
{
    public  class OrderDTO
    {
        public Guid OrderId { get; set; }
        public Guid ApplicationUserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ApplicationUserDTO ApplicationUser { get; set; }
        public PaymentDTO Payment { get; set; }
        public ICollection<OrderItemDTO> OrderItems { get; set; }
    }
}
