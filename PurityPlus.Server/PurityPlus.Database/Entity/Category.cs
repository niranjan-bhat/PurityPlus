using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Database.Entity
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid? ParentCategoryId { get; set; }  // Nullable foreign key
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public Category ParentCategory { get; set; }  // Navigation to the parent category
        public ICollection<Category> ChildCategories { get; set; }  // Navigation to child categories
        public ICollection<Product> Products { get; set; }
    }
}
