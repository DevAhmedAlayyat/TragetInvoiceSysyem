using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TargetInvoiceSystem.Core.Entities;

namespace TargetInvoiceSystem.Infrastructure.Data.Config
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasOne(u => u.MainUnit)
                   .WithMany(m => m.Unit)
                   .HasForeignKey(u => u.MainUnitId);

            builder.HasOne(u => u.SubUnit)
                   .WithMany(s => s.Unit)
                   .HasForeignKey(u => u.SubUnitId);
        }
    }
}
