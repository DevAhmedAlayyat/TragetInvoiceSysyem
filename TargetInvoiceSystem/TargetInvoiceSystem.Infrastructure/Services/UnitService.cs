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
    public class UnitService : Repository<Unit>, IUnitService
    {
        private readonly DbContext Context;

        public UnitService(DbContext context) : base(context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Unit>> GetAllUnitsAsync()
        {
            var units = await _context.Units.Include(u => u.MainUnit)
                                            .Include(u => u.SubUnit)
                                            .ToListAsync();
            return units;
        }

        public async Task<IEnumerable<Unit>> GetSubUnitsForMainUnitByIdAsync(Guid id)
        {
            var units = await _context.Units.Include(u => u.MainUnit)
                                            .Include(u => u.SubUnit)
                                            .Where(u => u.MainUnitId == id)
                                            .ToListAsync();
            return units;
        }

        private AppDbContext _context
        {
            get { return Context as AppDbContext; }
        }
    }
}
