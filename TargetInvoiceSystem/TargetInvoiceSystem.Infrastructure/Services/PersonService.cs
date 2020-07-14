using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.Core.ServicesInterfaces;

namespace TargetInvoiceSystem.Infrastructure.Services
{
    public class PersonService : Repository<Person>, IPersonService
    {
        public PersonService(DbContext context) : base(context)
        {
        }
    }
}
