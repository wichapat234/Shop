using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.DBModels;

namespace Shop.ViewModels
{
    public class bill_totalViewmodel
    {
        public decimal PriceBefore { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal PriceAfter { get; set; }
        public string NumberBill { get; set; }
        public DateTime Date { get; set; }
    }

    public class addbillViewmodel
    {
        public int IdBill { get; set; }
        public decimal PriceBefore { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal PriceAfter { get; set; }
        public string Dateformate { get; set; }
        public string NumberBill { get; set; }
        public string Date { get; set; }
    }
    public class addbilldetailViewmodel
    {
        public int IdProduct { get; set; }
        public int Count { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal LastPrice { get; set; }
    }
    public class BillproductViewmodel
    {
        public decimal Discount { get; set; }
        public string NameProduct { get; set; }
        public string NameUnit { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal totalPrice { get; set; }
        public int Count { get; set; }
    }

    public class searchViewmodel
    {
        public string date { get; set; }
        public string NumberBill { get; set; }
    }


    public class bill_detailViewmodel
    {
        public List<BillproductViewmodel> detail { get; set; }
        public bill_totalViewmodel bill { get; set; }
        
    }
    public class bill_detailparam
    {
        public List<addbilldetailViewmodel> detail { get; set; }
        public addbillViewmodel bill { get; set; }

    }


    public class DetailbillViewmodel
    {
        public List<BillproductViewmodel> bill_detail { get; set; }
        public bill_totalViewmodel bill_total { get; set; }
    }
    
    public class EditProductViewmodel
    {
        public int IdUnit { get; set; }
        public string NameUnit { get; set; }
        public string NameProduct { get; set; }
        public int Product_Id { get; set; }
        public decimal ProductPrice { get; set; }
        public List<Unit> unit { get; set; }
    }
    public class Unitparam
    {

        public int IdUnit { get; set; }
        public string Name { get; set; }
    }
    public class Unitviewmodel
    {
        public List<Unit> unit { get; set; }
        public Unit unit1 { get; set; }
        public int IdUnit { get; set; }
    }
    public class Productsparam
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int IdUnit { get; set; }
        public string NameUnit { get; set; }
        public string NameProduct { get; set; }
        public int Product_Id { get; set; }
    }

}
