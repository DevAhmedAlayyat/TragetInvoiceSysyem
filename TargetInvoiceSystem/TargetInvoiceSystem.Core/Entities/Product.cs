using System;

namespace TargetInvoiceSystem.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Balance { get; set; }
        public Guid StockId { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual ProductUnit ProductUnit { get; set; }
    }
}
