using System;
using System.Collections.Generic;

namespace Shop.Models.DBModels
{
    public partial class Bill
    {
        public Bill()
        {
            BillDetail = new HashSet<BillDetail>();
        }

        public int IdBill { get; set; }
        public double PriceBefore { get; set; }
        public double TotalDiscount { get; set; }
        public double PriceAfter { get; set; }
        public int BillNumber { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<BillDetail> BillDetail { get; set; }
    }
}
