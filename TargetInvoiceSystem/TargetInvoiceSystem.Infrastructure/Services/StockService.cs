using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.Core.ServicesInterfaces;

namespace TargetInvoiceSystem.Infrastructure.Services
{
    public class StockService : Repository<Stock>, IStockService
    {
        public StockService(DbContext context) : base(context)
        {

        }
    }
}
