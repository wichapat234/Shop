using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.DBModels;

namespace Shop.ProductViewModels
{
    public class ProductViewModel
    {
        public int IdProduct { get; set; }
        public string NameUnit { get; set; }
        public string NameProduct { get; set; }
        public decimal ProductPrice { get; set; }
        public int IdUnit { get; set; }

    }
    public class ProductAddandEditViewModel : ProductViewModel
    {
        public List<Unit> getUnit { get; set; }
    }



    public class ProductParam
    {
        public int IdProduct { get; set; }
    }
    public class ProductAddandEditParam : ProductParam
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int IdUnit { get; set; }
    }

}
