using System.Collections.Generic;

namespace TargetInvoiceSystem.Core.Entities
{
    public class SubUnit : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Unit> Unit { get; set; }
    }
}
