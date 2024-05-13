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
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            SeedData dataSeed = new SeedData();

            builder.HasData(dataSeed.Manufacturer1,
                dataSeed.Manufacturer2,
                dataSeed.Manufacturer3,
                dataSeed.Manufacturer4,
                dataSeed.Manufacturer5);
        }
    }
}
