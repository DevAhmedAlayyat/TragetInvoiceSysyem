using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TargetInvoiceSystem.Core.Entities
{
    public class User : IdentityUser
    {
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
