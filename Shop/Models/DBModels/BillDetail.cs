using System;
using System.Collections.Generic;

namespace Shop.Models.DBModels
{
    public partial class BillDetail
    {
        public int IdBillDetail { get; set; }
        public int IdProduct { get; set; }
        public int Count { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal LastPrice { get; set; }
        public int IdBill { get; set; }

        public virtual Bill IdBillNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
