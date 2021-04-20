using System;
using System.Collections.Generic;

namespace Shop.Models.DBModels
{
    public partial class Bill
    {
        public int IdBill { get; set; }
        public int? IdProduct { get; set; }
        public int? Count { get; set; }
        public double? Discount { get; set; }
        public double? Totalprice { get; set; }
        public double? LastPrice { get; set; }
        public int BillNumber { get; set; }
        public int? IdsumaryBill { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual SumaryBill IdsumaryBillNavigation { get; set; }
    }
}
