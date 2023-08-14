using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.FilterParams
{
    public class ProductFilter
    {
        public string? Name { get; set; }
        public Guid? CategoryId { get; set; } 
        public Guid? BrandId { get; set; } 
        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }
        public int? StartPrice { get; set; }
        public int? EndPrice { get; set; }
    }
}
