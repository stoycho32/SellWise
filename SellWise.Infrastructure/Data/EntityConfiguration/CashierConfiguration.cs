using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SellWise.Infrastructure.Data.Models;
using SellWise.Infrastructure.Data.SeedDatabase;

namespace SellWise.Infrastructure.Data.EntityConfiguration
{
    public class CashierConfiguration : IEntityTypeConfiguration<Cashier>
    {
        public void Configure(EntityTypeBuilder<Cashier> builder)
        {
            SeedData seedData = new SeedData();

            builder.HasData(new Cashier[]
            {
                seedData.AdminUser
            });
        }
    }
}
