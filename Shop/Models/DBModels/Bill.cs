using System;
using System.Collections.Generic;

namespace Shop.Models.DBModels
{
    public partial class Bill
    {
        public int IdBill { get; set; }
        public double PriceBefore { get; set; }
        public double TotalDiscount { get; set; }
        public double PriceAfter { get; set; }
        public DateTime Date { get; set; }
    }
}
