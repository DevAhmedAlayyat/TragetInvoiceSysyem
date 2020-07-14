using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetInvoiceSystem.WepApi.Dtos
{
    public class StockDto : BaseDto
    {
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
