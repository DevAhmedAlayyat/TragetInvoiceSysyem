using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetInvoiceSystem.WepApi.Dtos
{
    public class InvoiceOutputDto : BaseDto
    {
        public string UserName { get; set; }
        public string PersonName { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public double NetPrice { get; set; }
        public int TotalQty { get; set; }
        public bool IsSellInvoice { get; set; }
        public ICollection<InvoiceProductOutputDto> InvoiceProductOutputDtos { get; set; }
    }
}
