using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.DBModels;

namespace Shop.ViewModels
{
    public class bill_idViewmodel
    {
        public int IdBill { get; set; }
    }

    public class bill_totalViewmodel
    {
        public int IdBill { get; set; }
        public double PriceBefore { get; set; }
        public double TotalDiscount { get; set; }
        public double PriceAfter { get; set; }
        public DateTime Date { get; set; }

    }

    public class bill_detailparam
    {
        public int IdProduct { get; set; }
        public int Count { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
        public double LastPrice { get; set; }
        public int IdBill { get; set; }

        public double PriceBefore { get; set; }
        public double TotalDiscount { get; set; }
        public double PriceAfter { get; set; }
        public DateTime Date { get; set; }
        public string NameBill { get; set; }

    }
    public class billViewmodel
    {
        public List<Bill> bill { get; set; }

    }

    public class DetailbillViewmodel
    {

        public List<BillproductViewmodel> bill_detail { get; set; }
        public List<EditProductViewmodel> product { get; set; }
        public bill_totalViewmodel bill_total { get; set; }
        public BillDetail billDetail { get; set; }
    }
    public class BillproductViewmodel
    {

        public double? Discount { get; set; }
        public string NameProduct { get; set; }
        public string NameUnit { get; set; }
        public double ProductPrice { get; set; }
        public double totalPrice { get; set; }
        public int? Count { get; set; }

    }

    public class EditProductViewmodel
    {
        public int IdUnit { get; set; }
        public string NameUnit { get; set; }
        public string NameProduct { get; set; }
        public int Product_Id { get; set; }
        public double ProductPrice { get; set; }
        public List<Unit> unit { get; set; }

    }
    public class Unitparam
    {
        public int IdNoun { get; set; }
        public string Name { get; set; }
    }
    public class Unitviewmodel
    {
        public int IdUnit { get; set; }
        public string NameUnit { get; set; }
    }

    public class Products
    {
        public List<Product> products { get; set; }
    }
    public class Productsparam
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int IdNoun { get; set; }
    }


}
