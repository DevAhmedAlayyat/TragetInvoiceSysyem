using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.Core.ServicesInterfaces;
using TargetInvoiceSystem.Infrastructure.Data;

namespace TargetInvoiceSystem.Infrastructure.Services
{
    public class MainUnitService : Repository<MainUnit>, IMainUnitService
    {
        private readonly DbContext Context;
        public MainUnitService(DbContext context) : base(context)
        {
            Context = context;
        }
        public async Task<IEnumerable<MainUnit>> GetAllMainUnitsWithSubUnitsAsync()
        {
            var mainWSubUnits = await _context.MainUnits.Include(m => m.Unit)
                                                        .ThenInclude(u => u.SubUnit)
                                                        .ToListAsync();
            return mainWSubUnits;
        }

        public async Task<IEnumerable<MainUnit>> GetSubUnitsByMainUnitIdAsync(Guid id)
        {
            var subUnits = await _context.MainUnits.Include(m => m.Unit)
                                                   .ThenInclude(u => u.SubUnit)
                                                   .Where(m => m.Id == id)
                                                   .ToListAsync();            
            return subUnits;
        }
      

        private AppDbContext _context
        {
            get { return Context as AppDbContext; }
        }
    }
}
