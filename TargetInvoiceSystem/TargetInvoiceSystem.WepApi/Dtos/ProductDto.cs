using System;

namespace TargetInvoiceSystem.WepApi.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Balance { get; set; }
        public Guid StockDtoId { get; set; }
    }
}
