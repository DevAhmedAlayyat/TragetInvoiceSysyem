using System.Collections.Generic;

namespace TargetInvoiceSystem.Core.Entities
{
    public class Person : BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public bool IsCustomer { get; set; }
        public double Balance { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
