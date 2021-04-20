using System;
using System.Collections.Generic;

namespace Shop.Models.DBModels
{
    public partial class Product
    {
        public Product()
        {
            Bill = new HashSet<Bill>();
        }

        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int IdNoun { get; set; }

        public virtual Noun IdNounNavigation { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
    }
}
