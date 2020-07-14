using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TargetInvoiceSystem.Core.Entities;

namespace TargetInvoiceSystem.Infrastructure.Data.Config
{
    public partial class InvoiceConfgiuration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasOne(i => i.User)
                   .WithMany(u => u.Invoices)
                   .HasForeignKey(i => i.UserId);
            builder.HasOne(i => i.Person)
                   .WithMany(p => p.Invoices)
                   .HasForeignKey(i => i.PersonId);
        }
    }
}
