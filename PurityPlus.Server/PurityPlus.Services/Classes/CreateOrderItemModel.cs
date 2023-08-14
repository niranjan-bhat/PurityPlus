using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.Classes
{
    public class CreateOrderItemModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
