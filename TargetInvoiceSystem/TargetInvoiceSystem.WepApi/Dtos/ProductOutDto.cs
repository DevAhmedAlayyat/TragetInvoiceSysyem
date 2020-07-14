namespace TargetInvoiceSystem.WepApi.Dtos
{
    public class ProductOutDto : BaseDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string StockName { get; set; }
        public string MainUnti { get; set; }
        public string SubUnit { get; set; }
        public int Balance { get; set; }
        public double SellPrice { get; set; }
        public double BuyPrice { get; set; }
    }
}
