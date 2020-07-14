using System;
using System.Collections.Generic;

namespace TargetInvoiceSystem.Core.Entities
{
    public class ProductUnit : BaseEntity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    }
}
