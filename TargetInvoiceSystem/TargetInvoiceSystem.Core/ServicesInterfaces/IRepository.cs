using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TargetInvoiceSystem.Core.ServicesInterfaces
{
    public interface IRepository<Tentity> where Tentity : class
    {
        Task<Tentity> GetByIdAsync(object id);
        Task<IEnumerable<Tentity>> GetAllAsync();
        Task<Tentity> InsertAsync(Tentity entity);
        Task UpdateAsync(Tentity entity);
        Task DeleteAsync(Tentity entity);
    }
}
