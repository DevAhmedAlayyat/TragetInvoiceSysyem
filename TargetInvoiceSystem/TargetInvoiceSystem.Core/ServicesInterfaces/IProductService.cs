using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities;

namespace TargetInvoiceSystem.Core.ServicesInterfaces
{
    public interface IProductService : IRepository<ProductUnit>
    {
        Task<IEnumerable<ProductUnit>> GetAllProductsAsync();
        Task<ProductUnit> GetProductAsync(Guid id);
    }
}
