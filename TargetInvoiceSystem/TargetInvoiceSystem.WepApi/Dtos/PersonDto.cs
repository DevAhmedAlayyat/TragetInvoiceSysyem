using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetInvoiceSystem.WepApi.Dtos
{
    public class PersonDto : BaseDto
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public bool IsCustomer { get; set; }
        public double Balance { get; set; }
    }
}
