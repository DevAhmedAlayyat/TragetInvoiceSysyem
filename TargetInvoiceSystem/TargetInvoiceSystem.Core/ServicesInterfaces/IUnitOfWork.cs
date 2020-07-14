using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TargetInvoiceSystem.Core.ServicesInterfaces
{
    public interface IUnitOfWork
    {
        public IAuthRegister AuthRegister { get; }
        public IAuthLogin AuthLogin { get; }
        public IMainUnitService MainUnitService { get; }
        public ISubUnitService SubUnitService { get; }
        public IUnitService UnitService { get; }
        public IStockService StockService { get; }
        public IProductService ProductService { get; }
        public IPersonService PersonService { get; }
        public IInvoiceService InvoiceService { get; }
        Task SaveChangesAsync();
    }
}
