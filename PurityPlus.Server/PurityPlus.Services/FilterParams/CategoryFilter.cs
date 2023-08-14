using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.FilterParams
{
    public  class CategoryFilter
    {
        public Guid? CategoryId { get; set; }
        public string? Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
