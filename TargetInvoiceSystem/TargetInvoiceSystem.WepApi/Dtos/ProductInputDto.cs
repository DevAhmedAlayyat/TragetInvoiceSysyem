using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetInvoiceSystem.WepApi.Dtos
{
    public class ProductInputDto
    {
        public ProductDto ProductDto { get; set; }
        public Guid UnitDtoId { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }

    }
}
