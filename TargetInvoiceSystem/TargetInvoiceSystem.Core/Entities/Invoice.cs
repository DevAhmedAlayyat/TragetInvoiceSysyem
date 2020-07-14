using System;
using System.Collections.Generic;

namespace TargetInvoiceSystem.Core.Entities
{
    public class Invoice : BaseEntity
    {
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public double NetPrice { get; set; }
        public int TotalQty { get; set; }
        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
