using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.DBModels;

namespace Shop.TransactionViewModels
{
    public class billViewModel
    {
        public int IdBill { get; set; }
        public decimal PriceBefore { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal PriceAfter { get; set; }
        public DateTime DateTime { get; set; }
        public string Dateformate => $"{DateTime.ToString("dd/MM/yyyy")}";
        public string NumberBill { get; set; }

    }
    public class billdetailViewModel
    {
        public string NameUnit { get; set; }
        public string NameProduct { get; set; }
        public decimal Discount { get; set; }    
        public decimal ProductPrice { get; set; }
        public decimal totalPrice { get; set; }
        public decimal lastPrice { get; set; }
        public int Count { get; set; }
    }
    public class getBillAndBilldetailViewModel
    {
        public List<billdetailViewModel> detail { get; set; }
        public billViewModel bill { get; set; }
    }


    public class searchParam
    {
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string NumberBill { get; set; }
    }
    public class billdetailParam
    {
        public int IdBill { get; set; }
    }
    public class addBillParam
    {
        public decimal PriceBefore { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal PriceAfter { get; set; }
        public string Date { get; set; }

    }
    public class addBilldetailParam
    {
        public int IdProduct { get; set; }
        public int Count { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal LastPrice { get; set; }
    }


    public class addBillAndBilldetailParam
    {
        public List<addBilldetailParam> detail { get; set; }
        public addBillParam bill { get; set; }
    }



}
