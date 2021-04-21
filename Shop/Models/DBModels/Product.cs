using System;
using System.Collections.Generic;

namespace Shop.Models.DBModels
{
    public partial class Product
    {
        public Product()
        {
            BillDetail = new HashSet<BillDetail>();
        }

        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int IdUnit { get; set; }

        public virtual Unit IdUnitNavigation { get; set; }
        public virtual ICollection<BillDetail> BillDetail { get; set; }
    }
}
