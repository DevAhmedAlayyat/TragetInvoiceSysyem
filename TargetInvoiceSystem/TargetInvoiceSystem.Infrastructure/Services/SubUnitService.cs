using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.Core.ServicesInterfaces;

namespace TargetInvoiceSystem.Infrastructure.Services
{
    public class SubUnitService : Repository<SubUnit>, ISubUnitService
    {
        private readonly DbContext _context;

        public SubUnitService(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
