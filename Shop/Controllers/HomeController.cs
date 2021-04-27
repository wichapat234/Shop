using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public HomeController(_711_databaseContext context)
        {
            this.context = context;
        }
        public IActionResult List_Bill()
        {
            //var product = from a in context.Bill
            //              join b in context.Bill on a.IdBill equals b.IdBill
            //              select new billViewmodel
            //              {
            //                  Id_Summary = a.IdBill,
            //                  Date = a.Date,
            //                  Price_Before = a.PriceBefore,
            //                  Price_After = a.PriceAfter,
            //                  Discount = a.TotalDiscount
            //              };

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


            //return Ok(product);
            return View(product);
        }
        public IActionResult Add_Bill()
        {

            return View(); ;
        }
        [HttpPost]
        public IActionResult insert_detail_bill([FromBody] bill_detailparam model)
        {
            var billdetails = new BillDetail()
            {
                IdProduct = model.IdProduct,
                //Count = model.Count,
                //Discount = model.Discount,
                //TotalPrice = model.TotalPrice,
                //LastPrice = model.LastPrice,
                //IdBill = 1

            };
            context.BillDetail.Add(billdetails);
            context.SaveChanges();



            return Json(billdetails);
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
            return Json(model);
        }
        [HttpPost]
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
                                 select new Bill2Viewmodel
                                 {
                                     NameUnit = u.NameUnit,
                                     NameProduct = p.ProductName,
                                     ProductPrice = p.ProductPrice,
                                     Count = b.Count,
                                     Discount = b.Discount
                                 }).ToList(); ;
            model.bill = (from a in context.Bill
                          join b in context.Bill on a.IdBill equals b.IdBill
                          select new billViewmodel
                          {
                              Date = a.Date,
                              Price_Before = a.PriceBefore,
                              Price_After = a.PriceAfter,
                              Discount = a.TotalDiscount
                          }).FirstOrDefault();
            return View(model);
        }

        public IActionResult Update([FromBody] Unitparam model)
        {
            int check_update = 1;
            IQueryable<Unitviewmodel> json_data = from a in context.Unit
                                                  where model.Name == a.NameUnit
                                                  select new Unitviewmodel { NameUnit = a.NameUnit };
            if (json_data.Count() == 0)
            {
                var result = context.Unit.SingleOrDefault(b => b.IdUnit == model.IdNoun);

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
        public IActionResult Update_Product([FromBody] Productsparam model)
        {
            var result = context.Product.SingleOrDefault(b => b.IdProduct == model.IdProduct);

            if (result != null)
            {
                result.ProductName = model.ProductName;
                result.ProductPrice = model.ProductPrice;
                result.IdUnit = model.IdNoun;
                context.SaveChanges();
            }
            return Json(result);
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

        public IActionResult Insert_Unit([FromBody] Unitparam model)
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

        public IActionResult Insert_Product([FromBody] Productsparam model)
        {
            var product = new Product()
            {
                ProductName = model.ProductName,
                ProductPrice = model.ProductPrice,
                IdUnit = model.IdNoun

            };
            context.Product.Add(product);
            context.SaveChanges();
            return Json(product);
        }

        public IActionResult Delete([FromBody] Unitparam model)
        {
            var del = context.Unit.Where(o => o.IdUnit == model.IdNoun).FirstOrDefault();
            if (del != null)
            {
                context.Unit.Remove(del);
            }
            context.SaveChanges();
            return Json(del);
        }
        public IActionResult Delete_Product([FromBody] Productsparam model)
        {
            var del = context.Product.Where(o => o.IdProduct == model.IdProduct).FirstOrDefault();
            if (del != null)
            {
                context.Product.Remove(del);
            }
            context.SaveChanges();
            return Json(model);
        }
    }
}

