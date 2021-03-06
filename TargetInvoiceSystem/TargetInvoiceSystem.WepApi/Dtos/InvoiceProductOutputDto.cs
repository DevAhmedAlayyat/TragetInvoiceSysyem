﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetInvoiceSystem.WepApi.Dtos
{
    public class InvoiceProductOutputDto
    {
        public string ProductName { get; set; }
        public string MainUnti { get; set; }
        public string SubUnit { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public double NetPrice { get; set; }
        public int Qty { get; set; }
        public string StockName { get; set; }
    }
}
