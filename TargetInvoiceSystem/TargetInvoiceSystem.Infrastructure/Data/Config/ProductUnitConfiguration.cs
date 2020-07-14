using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TargetInvoiceSystem.Core.Entities;

namespace TargetInvoiceSystem.Infrastructure.Data.Config
{
    public class ProductUnitConfiguration : IEntityTypeConfiguration<ProductUnit>
    {
        public void Configure(EntityTypeBuilder<ProductUnit> builder)
        {
            builder.HasOne(pu => pu.Product)
                   .WithOne(p => p.ProductUnit)
                   .HasForeignKey<ProductUnit>(x => x.ProductId);
            builder.HasOne(pu => pu.Unit)
                   .WithMany(u => u.ProductUnits)
                   .HasForeignKey(pu => pu.UnitId);
        }
    }
}
