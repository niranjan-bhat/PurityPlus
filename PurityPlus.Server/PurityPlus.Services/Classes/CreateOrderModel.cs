using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.Classes
{
    public class CreateOrderModel
    {
        public Guid ApplicationUserId { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public IEnumerable<CreateOrderItemModel> OrderItems { get; set; }
    }
}
