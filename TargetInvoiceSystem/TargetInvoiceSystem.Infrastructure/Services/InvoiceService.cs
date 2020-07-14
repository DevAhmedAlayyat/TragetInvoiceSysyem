using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.Core.ServicesInterfaces;
using TargetInvoiceSystem.Infrastructure.Data;

namespace TargetInvoiceSystem.Infrastructure.Services
{
    public class InvoiceService : Repository<Invoice>, IInvoiceService
    {
        private readonly DbContext Context;
        public InvoiceService(DbContext context) : base(context)
        {
            Context = context;
        }

        public async Task<Invoice> GetInvoiceAsync(Guid id)
        {
            var invoice = await _context.Invoices.Include(i => i.InvoiceProducts)
                                                 .ThenInclude(ip => ip.ProductUnit)
                                                 .ThenInclude(pu => pu.Product)
                                                 .ThenInclude(p => p.Stock)
                                                 .Include(i => i.InvoiceProducts)
                                                 .ThenInclude(ip => ip.ProductUnit)
                                                 .ThenInclude(pu => pu.Unit)
                                                 .ThenInclude(u => u.MainUnit)
                                                 .ThenInclude(pu => pu.Unit)
                                                 .ThenInclude(u => u.SubUnit)
                                                 .Include(i => i.Person)
                                                 .Include(i => i.User)
                                                 .SingleOrDefaultAsync(i => i.Id == id);
            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesAsync()
        {
            var invoices = await _context.Invoices.Include(i => i.InvoiceProducts)
                                                  .ThenInclude(ip => ip.ProductUnit)
                                                  .ThenInclude(pu => pu.Product)
                                                  .ThenInclude(p => p.Stock)
                                                  .Include(i => i.InvoiceProducts)
                                                  .ThenInclude(ip => ip.ProductUnit)
                                                  .ThenInclude(pu => pu.Unit)
                                                  .ThenInclude(u => u.MainUnit)
                                                  .ThenInclude(pu => pu.Unit)
                                                  .ThenInclude(u => u.SubUnit)
                                                  .Include(i => i.Person)
                                                  .Include(i => i.User)
                                                  .ToListAsync();
            return invoices;
        }

        private AppDbContext _context
        {
            get { return Context as AppDbContext; }
        }
    }
}
