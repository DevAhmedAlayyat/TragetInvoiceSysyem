using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities;

namespace TargetInvoiceSystem.Core.ServicesInterfaces
{
    public interface IInvoiceService : IRepository<Invoice>
    {
        Task<IEnumerable<Invoice>> GetInvoicesAsync();
        Task<Invoice> GetInvoiceAsync(Guid id);
    }
}
