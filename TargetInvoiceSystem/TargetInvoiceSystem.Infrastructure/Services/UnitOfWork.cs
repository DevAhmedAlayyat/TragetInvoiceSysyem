using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.ServicesInterfaces;

namespace TargetInvoiceSystem.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public UnitOfWork(DbContext context, 
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }
        public IAuthRegister authRegister { get; private set; }

        public IAuthLogin authLogin { get; private set; }
        public IMainUnitService mainUnitService { get; private set; }
        public ISubUnitService subUnitService { get; private set; }
        public IUnitService unitService { get; private set; }
        public IStockService stockService { get; private set; }
        public IProductService productService { get; private set; }
        public IPersonService personService { get; private set; }
        public IInvoiceService invoiceService { get; private set; }

        public IInvoiceService InvoiceService
        {
            get
            {
                return invoiceService ?? new InvoiceService(_context);
            }
        }

        public IPersonService PersonService
        {
            get
            {
                return personService ?? new PersonService(_context);
            }
        }

        public IProductService ProductService
        {
            get
            {
                return productService ?? new ProductService(_context);
            }
        }

        public IStockService StockService
        {
            get
            {
                return stockService ?? new StockService(_context);
            }
        }
        public IUnitService UnitService
        {
            get
            {
                return unitService ?? new UnitService(_context);
            }
        }
        public ISubUnitService SubUnitService
        {
            get
            {
                return subUnitService ?? new SubUnitService(_context);
            }
        }
        public IMainUnitService MainUnitService
        {
            get
            {
                return mainUnitService ?? new MainUnitService(_context);
            }
        }
        public IAuthRegister AuthRegister
        {
            get
            {
                return authRegister ?? new AuthRegister(_userManager);
            }
        }
        public IAuthLogin AuthLogin
        {
            get
            {
                return authLogin ?? new AuthLogin(_configuration, _userManager);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
