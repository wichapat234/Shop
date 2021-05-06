﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Models;
using Shop.Models.DBModels;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private _711_databaseContext context;
        private DateTime datemodel;
        private string format;
        public HomeController(_711_databaseContext context)
        {
            this.context = context;
        }
        public IActionResult List_Bill()
        {
            return View();
        }
        public IActionResult List_Product()
        {
            var product = from a in context.Product
                          orderby a.IdProduct
                          join b in context.Unit on a.IdUnit equals b.IdUnit
                          select new EditProductViewmodel
                          {
                              Product_Id = a.IdProduct,
                              NameUnit = b.NameUnit,
                              NameProduct = a.ProductName,
                              ProductPrice = a.ProductPrice
                          };
            return View(product);
        }
        public IActionResult Get_Listbill([FromBody] searchViewmodel model)
        {
            if (model.date != "")
            {
                format = "yyyy-MM-dd";
                CultureInfo provider = CultureInfo.InvariantCulture;
                provider = new CultureInfo("en-US");
                datemodel = DateTime.ParseExact(model.date, format, provider);

                // datemodel = DateTime.Parse(model.date.ToString());
            }

            var product = (from a in context.Bill
                           where  (a.NumberBill.Contains(model.NumberBill) && model.date == "") ||
                                  (model.NumberBill != "" && model.date != "" && a.Date == datemodel && a.NumberBill.Contains(model.NumberBill)) ||
                                  (model.date != "" && model.NumberBill == "" && a.Date == datemodel)

                           select new addbillViewmodel
                           {
                               IdBill = a.IdBill,
                               PriceBefore = a.PriceBefore,
                               TotalDiscount = a.TotalDiscount,
                               PriceAfter = a.PriceAfter,
                               Dateformate = a.DateFormate,
                               NumberBill = a.NumberBill

                           }).ToList();
            return Json(product);
        }
        public IActionResult Add_Bill()
        {

            return View();
        }
        public IActionResult insert_detail_bill([FromBody] bill_detailparam model1)
        {
            // try catch , roll Back ***********
            int numberbill;
            var number = (from b in context.Bill
                          orderby b.IdBill descending  // count row insert numberbill
                          select new bill_idViewmodel
                          {
                              bill = b.IdBill
                          }).FirstOrDefault(); 

            if (number == null)
            {
                numberbill = 0;
            }
            else
            {
                numberbill = number.bill;
            }

            var name = "Bill-";
            var NumberBill = name + numberbill; 
            var bill = new Bill()
            {
                PriceBefore = model1.bill.PriceBefore,
                TotalDiscount = model1.bill.TotalDiscount,
                PriceAfter = model1.bill.PriceAfter,
                Date = model1.bill.Date,
                NumberBill = NumberBill,
            };
            context.Bill.Add(bill);
            context.SaveChanges();

            int idbill = bill.IdBill;

            foreach (var data in model1.detail.ToList())
            {
                var billdetails = new BillDetail()
                {

                    IdProduct = data.IdProduct,
                    Count = data.Count,
                    Discount = data.Discount,
                    TotalPrice = data.TotalPrice,
                    LastPrice = data.LastPrice,
                    IdBill = idbill

                };
                context.BillDetail.Add(billdetails);
                context.SaveChanges();

            }
            return Json(idbill);
        }

        public IActionResult GatdataProduct()
        {
            DetailbillViewmodel model = new DetailbillViewmodel();
            model.product = (from a in context.Product
                             join b in context.Unit on a.IdUnit equals b.IdUnit
                             select new EditProductViewmodel
                             {
                                 Product_Id = a.IdProduct,
                                 NameUnit = b.NameUnit,
                                 NameProduct = a.ProductName,
                                 ProductPrice = a.ProductPrice
                             }).ToList();
           // model.billDetail = context.BillDetail.OrderByDescending(a => a.IdBillDetail).FirstOrDefault();
            

            return Json(model);
        }
        public IActionResult Data_Product_Select([FromBody] Productsparam model)
        {
            var json_data = from a in context.Product
                            where a.IdProduct == model.IdProduct
                            join b in context.Unit on a.IdUnit equals b.IdUnit
                            select new EditProductViewmodel
                            {
                                NameUnit = b.NameUnit,
                                NameProduct = a.ProductName,
                                ProductPrice = a.ProductPrice
                            };
            return Json(json_data);
        }
        public IActionResult Shoping()
        {
            return View();
        }
        public IActionResult List_Unit()
        {
            var Noun = context.Unit.ToList();
            return View(Noun);
        }
        public IActionResult Edit_Unit_Page(int? id)
        {

            var json_data = from a in context.Unit
                            where a.IdUnit == id
                            select new Unitviewmodel { IdUnit = a.IdUnit, NameUnit = a.NameUnit };
            return View(json_data);
            ///   return View();
        }
        public IActionResult Check_Edit_Unit([FromBody] Unitparam model)
        {
            var status = "";
            var edit = context.Unit.Where(o => o.IdUnit == model.IdUnit).FirstOrDefault();
            if (edit != null)
            {
                status = "Seccess";
            }
            else
            {
                status = "Fail";
            }
            var data = new { edit, status};

              return Json(data);
        }



        public IActionResult Edit_Product_Page(int? id)
        {
            //   int idproduct = id;
            EditProductViewmodel model = new EditProductViewmodel();
                model = (from a in context.Product
                         where a.IdProduct == id
                         join b in context.Unit on a.IdUnit equals b.IdUnit
                         select new EditProductViewmodel
                         {
                             IdUnit = a.IdUnit,
                             Product_Id = a.IdProduct,
                             NameUnit = b.NameUnit,
                             NameProduct = a.ProductName,
                             ProductPrice = a.ProductPrice
                         }).FirstOrDefault();
                model.unit = context.Unit.ToList();
            return View(model);
                
            //  return View();
        }
        public IActionResult Detail_Bill(int? id)
        {
            DetailbillViewmodel model = new DetailbillViewmodel();
            model.bill_detail = (from b in context.BillDetail
                                 where b.IdBill == id
                                 join p in context.Product on b.IdProduct equals p.IdProduct
                                 join u in context.Unit on p.IdUnit equals u.IdUnit
                                 select new BillproductViewmodel
                                 {
                                     NameUnit = u.NameUnit,
                                     NameProduct = p.ProductName,
                                     ProductPrice = p.ProductPrice,
                                     Count = b.Count,
                                     Discount = b.Discount,
                                     totalPrice = b.TotalPrice
                                 }).ToList(); ;

            model.bill_total = (from a in context.Bill
                                where a.IdBill == id
                                select new bill_totalViewmodel
                                {
                                    Date = a.Date,
                                    NumberBill = a.NumberBill,
                                    PriceBefore = a.PriceBefore,
                                    PriceAfter = a.PriceAfter,
                                    TotalDiscount = a.TotalDiscount
                                }).FirstOrDefault();
            return View(model);
        }

        public IActionResult Update([FromBody] Unitparam model)  //แก้ภายในให้ถูก **********
        {
            int check_update = 1;
            IQueryable<Unitviewmodel> json_data = from a in context.Unit
                                                  where model.Name == a.NameUnit
                                                  select new Unitviewmodel { NameUnit = a.NameUnit };
            if (json_data.Count() == 0)
            {
                var result = context.Unit.SingleOrDefault(b => b.IdUnit == model.IdUnit);

                if (result != null)
                {
                    result.NameUnit = model.Name;
                    context.SaveChanges();
                }
            }
            else
            {

                check_update = 0;
            }

            return Json(check_update);
        }
        public IActionResult Update_Product([FromBody] Productsparam model) //แก้ภายในให้ถูก **********
        {
            var status = "";
            var result = context.Product.SingleOrDefault(b => b.IdProduct == model.IdProduct);
            if (result != null)
            {
                result.ProductName = model.ProductName;
                result.ProductPrice = model.ProductPrice;
                result.IdUnit = model.IdUnit;
                context.SaveChanges();
                 status = "Seccess";
            }
            else
            {
                 status = "Fail";
            }
            return Json(status);
        }
        public IActionResult Add_Unit_Page()
        {
            return View();
        }
        public IActionResult Add_Product_Page()
        {
            var Noun = context.Unit.ToList();

            return View(Noun);
        }

        public IActionResult Insert_Unit([FromBody] Unitparam model) //case ตัวใหญ่ตัวเล็ก **************
        {
            int checked_insert = 1;
            var result = context.Unit.Where(a => a.NameUnit == model.Name).Count();
            if (result != 0)
            {
                checked_insert = 0;
            }
            else if (result == 0)
            {
                var nou = new Unit()
                {
                    NameUnit = model.Name
                };
                context.Unit.Add(nou);
                context.SaveChanges();

            }
            return Json(checked_insert);
        }

        public IActionResult Insert_Product([FromBody] Productsparam model) //format return **********
        {

            var product = new Product()
            {
                ProductName = model.ProductName,
                ProductPrice = model.ProductPrice,
                IdUnit = model.IdUnit

            };
            context.Product.Add(product);
            context.SaveChanges();
            return Json(product);
        }

        public IActionResult Delete([FromBody] Unitparam model) //format return เช็ตเคสลบ********** t
        {
            var status = "";
            var del = context.Unit.Where(o => o.IdUnit == model.IdUnit).FirstOrDefault();
            if (del != null)
            {
                context.Unit.Remove(del);
                context.SaveChanges();
                status = "Seccess";               
            }
            
            else
            {
                status = "Fail";

            }
            
            return Json(status);
        }
        public IActionResult Delete_Product([FromBody] Productsparam model) //format return เช็ตเคสลบ ********** t
        {
            var status = "";
            var del = context.Product.Where(o => o.IdProduct == model.IdProduct).FirstOrDefault();
            if (del != null)
            {
                context.Product.Remove(del);
                context.SaveChanges();
                status = "Seccess";
            }
            else
            {
                status = "Fail";
            }
            return Json(status);
        }
    }
}

