using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetInvoiceSystem.WepApi.Dtos
{
    public class InvoiceProductDto
    {
        public Guid ProductUnitId { get; set; }
        public int Qty { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public double NetPrice { get; set; }
    }
}
