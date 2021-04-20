using System;
using System.Collections.Generic;

namespace Shop.Models.DBModels
{
    public partial class Noun
    {
        public Noun()
        {
            Product = new HashSet<Product>();
        }

        public int IdNoun { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
