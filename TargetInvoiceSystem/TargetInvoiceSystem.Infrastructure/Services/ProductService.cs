using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.Core.ServicesInterfaces;
using TargetInvoiceSystem.Infrastructure.Data;

namespace TargetInvoiceSystem.Infrastructure.Services
{
    public class ProductService : Repository<ProductUnit>, IProductService
    {
        private readonly DbContext Context;
        public ProductService(DbContext context) : base(context)
        {
            Context = context;
        }

        public async Task<IEnumerable<ProductUnit>> GetAllProductsAsync()
        {
            var products = await _context.ProductUnits.Include(pu => pu.Product)
                                                      .ThenInclude(p => p.Stock)
                                                      .Include(pu => pu.Unit)
                                                      .ThenInclude(u => u.MainUnit)
                                                      .Include(pu => pu.Unit)
                                                      .ThenInclude(u => u.SubUnit)
                                                      .ToListAsync();
            return products;
        }

        public async Task<ProductUnit> GetProductAsync(Guid id)
        {
            var product = await _context.ProductUnits.Include(pu => pu.Product)
                                                      .ThenInclude(p => p.Stock)
                                                      .Include(pu => pu.Unit)
                                                      .ThenInclude(u => u.MainUnit)
                                                      .Include(pu => pu.Unit)
                                                      .ThenInclude(u => u.SubUnit)
                                                      .SingleOrDefaultAsync(pu => pu.ProductId == id);
            return product;
        }

        private AppDbContext _context
        {
            get { return Context as AppDbContext; }
        }
    }
}
