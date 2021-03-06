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
        public decimal PriceBefore { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal PriceAfter { get; set; }
        public DateTime Date { get; set; }
        public string NumberBill { get; set; }
        public virtual ICollection<BillDetail> BillDetail { get; set; }
    }
}
