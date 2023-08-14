using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PurityPlus.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Database
{
    public class PurityPlusDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public PurityPlusDbContext(DbContextOptions<PurityPlusDbContext> options)
        : base(options)
        {
        }
        internal DbSet<Product> Products { get; set; }
        internal DbSet<Brand> Brands { get; set; }
        internal DbSet<Category> Categories { get; set; }
        internal DbSet<Order> Orders { get; set; }
        internal DbSet<OrderItem> OrdersItems { get; set; }
        internal DbSet<Payment> PaymentMethods { get; set; }
        internal DbSet<Review> Reviews { get; set; }

    }
}
