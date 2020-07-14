using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TargetInvoiceSystem.Core.Entities;

namespace TargetInvoiceSystem.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Stock)
                   .WithMany(s => s.Products)
                   .HasForeignKey(p => p.StockId);
        }
    }
}
