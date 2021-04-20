﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.DBModels;

namespace Shop.ViewModels
{
    public class billViewmodel
    {
        public int Id_Summary { get; set; }
        public DateTime? Date { get; set; }
        public int Bill_Number { get; set; }
        public double Price_Before { get; set; }
        public double Price_After { get; set; }
        public double Discount { get; set; }

    }
    public class DetailbillViewmodel 
    {
        public List<Bill2Viewmodel> bill { get; set; }
        public billViewmodel sumarybill { get; set; }
    }
    public class Bill2Viewmodel
    {
        
        public double? Discount { get; set; }
        public string NameProduct { get; set; }
        public string NameUnit { get; set; }
        public double ProductPrice { get; set; }
        public int? Count { get; set; }

    }


    public class EditProductViewmodel
    {
        public int IdNoun { get; set; }
        public string NameUnit { get; set; }
        public string NameProduct { get; set; }
        public int Product_Id { get; set; }
        public double ProductPrice { get; set; }
        public List<Noun> noun { get; set; }

    }
    public class Unitparam
    {
        public int IdNoun { get; set; }
        public string Name { get; set; }
    }
    public class Unit
    {
        public int IdNoun { get; set; }
        public string Name { get; set; }
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