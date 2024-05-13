using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SellWise.Infrastructure.Data.Models;
using SellWise.Infrastructure.Data.SeedDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWise.Infrastructure.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            SeedData dataSeed = new SeedData();

            builder.HasData(dataSeed.Product1,
                    dataSeed.Product2,
                    dataSeed.Product3,
                    dataSeed.Product4,
                    dataSeed.Product5);
        }
    }
}
