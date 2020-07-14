using System;
using System.Collections.Generic;

namespace TargetInvoiceSystem.Core.Entities
{
    public class Unit : BaseEntity
    {
        public Guid MainUnitId { get; set; }
        public virtual MainUnit MainUnit { get; set; }
        public Guid SubUnitId { get; set; }
        public virtual SubUnit SubUnit { get; set; }
        public virtual ICollection<ProductUnit> ProductUnits { get; set; }
    }
}
