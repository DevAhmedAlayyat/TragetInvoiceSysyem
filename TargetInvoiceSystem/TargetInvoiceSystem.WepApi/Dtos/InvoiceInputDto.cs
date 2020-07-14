using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetInvoiceSystem.WepApi.Dtos
{
    public class InvoiceInputDto : BaseDto
    {
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public double NetPrice { get; set; }
        public int TotalQty { get; set; }
        public virtual ICollection<InvoiceProductDto> InvoiceProducts { get; set; }
        public string UserId { get; set; }
        public bool IsSellInvoice { get; set; }
        public Guid PersonId { get; set; }
    }
}
