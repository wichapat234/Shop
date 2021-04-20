using System;
using System.Collections.Generic;

namespace Shop.Models.DBModels
{
    public partial class SumaryBill
    {
        public SumaryBill()
        {
            Bill = new HashSet<Bill>();
        }

        public int IdsumaryBill { get; set; }
        public double PriceBefore { get; set; }
        public double TotalDiscount { get; set; }
        public double PriceAfter { get; set; }
        public int BillNumber { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Bill> Bill { get; set; }
    }
}
