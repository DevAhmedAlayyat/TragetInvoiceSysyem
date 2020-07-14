using System;

namespace TargetInvoiceSystem.Core.Entities
{
    public class InvoiceProduct : BaseEntity
    {
        public Guid ProductUnitId { get; set; }
        public virtual ProductUnit ProductUnit { get; set; }
        public Guid InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public int Qty { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public double NetPrice { get; set; }
    }
}
