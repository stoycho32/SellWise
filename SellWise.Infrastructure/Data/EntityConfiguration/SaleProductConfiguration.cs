using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SellWise.Infrastructure.Data.Models;

namespace SellWise.Infrastructure.Data.EntityConfiguration
{
    public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.SaleId });
        }
    }
}
