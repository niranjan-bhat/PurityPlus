using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.DTO
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int StockQuantity { get; set; }
        public string[] ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public double? Rating { get; set; }

        public CategoryDTO Category { get; set; }
        public BrandDTO Brand { get; set; }
    }
}
