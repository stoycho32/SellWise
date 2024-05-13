using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SellWise.Infrastructure.Data.EntityConfiguration;
using SellWise.Infrastructure.Data.Models;

namespace SellWise.Data
{
    public class ApplicationDbContext : IdentityDbContext<Cashier>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<Sale> Sales { get; set; } 
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.ApplyConfiguration(new SaleProductConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ManufacturerConfiguration());

            base.OnModelCreating(builder);
        }

    }
}