using System;

namespace TargetInvoiceSystem.WepApi.Dtos
{
    public class UnitInputDto : BaseDto
    {
        public MainUnitDto MainUnitDto { get; set; }
        public SubUnitDto SubUnitDto { get; set; }
    }
}
