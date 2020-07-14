using System.Collections.Generic;

namespace TargetInvoiceSystem.Core.Entities
{
    public class Stock : BaseEntity
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
