using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TargetInvoiceSystem.Core.Entities;

namespace TargetInvoiceSystem.Infrastructure.Data.Config
{
    public class InvoiceProductConfiguration : IEntityTypeConfiguration<InvoiceProduct>
    {
        public void Configure(EntityTypeBuilder<InvoiceProduct> builder)
        {
            builder.HasOne(ip => ip.ProductUnit)
                   .WithMany(pu => pu.InvoiceProducts)
                   .HasForeignKey(ip => ip.ProductUnitId);

            builder.HasOne(ip => ip.Invoice)
                   .WithMany(i => i.InvoiceProducts)
                   .HasForeignKey(ip => ip.InvoiceId);
        }
    }
}
