using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities;

namespace TargetInvoiceSystem.Core.ServicesInterfaces
{
    public interface IUnitService : IRepository<Unit>
    {
        Task<IEnumerable<Unit>> GetAllUnitsAsync();
        Task<IEnumerable<Unit>> GetSubUnitsForMainUnitByIdAsync(Guid id);
    }
}
