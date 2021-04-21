using System;
using System.Collections.Generic;

namespace Shop.Models.DBModels
{
    public partial class Unit
    {
        public Unit()
        {
            Product = new HashSet<Product>();
        }

        public int IdUnit { get; set; }
        public string NameUnit { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
