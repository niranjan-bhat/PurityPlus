using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.FilterParams
{
    public class OrderFilter
    {
        public Guid? ApplicationUserId { get; set; }
        public Guid? OrderId { get; set; }
    }
}
