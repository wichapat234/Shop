using System;
using System.Collections.Generic;

namespace Shop.Models.DBModels
{
    public partial class BillDetail
    {
        public int IdBillDetail { get; set; }
        public int? IdProduct { get; set; }
        public int? Count { get; set; }
        public double? Discount { get; set; }
        public double? TotalPrice { get; set; }
        public double? LastPrice { get; set; }
        public int? IdBill { get; set; }

        public virtual Bill IdBillNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
