using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.Infrastructure.Data.Config;

namespace TargetInvoiceSystem.Infrastructure.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new InvoiceConfgiuration());
            builder.ApplyConfiguration(new InvoiceProductConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductUnitConfiguration());
            builder.ApplyConfiguration(new UnitConfiguration());
        }        

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
        public DbSet<MainUnit> MainUnits { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<SubUnit> SubUnits { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
