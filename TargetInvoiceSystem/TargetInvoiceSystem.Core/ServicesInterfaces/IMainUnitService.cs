using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities;

namespace TargetInvoiceSystem.Core.ServicesInterfaces
{
    public interface IMainUnitService : IRepository<MainUnit>
    {
        Task<IEnumerable<MainUnit>> GetAllMainUnitsWithSubUnitsAsync();
        Task<IEnumerable<MainUnit>> GetSubUnitsByMainUnitIdAsync(Guid id);
    }
}
