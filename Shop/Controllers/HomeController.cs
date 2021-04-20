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
            var product = from a in context.SumaryBill
                          join b in context.Bill on a.IdsumaryBill equals b.IdsumaryBill
                          select new billViewmodel
                          {
                              Id_Summary = a.IdsumaryBill,
                              Date = a.Date,
                              Bill_Number = a.BillNumber,
                              Price_Before = a.PriceBefore,
                              Price_After = a.PriceAfter,
                              Discount = a.TotalDiscount
                          };

            return View(product);
        }
        public IActionResult List_Product()
        {
            var product = from a in context.Product
                          orderby a.IdProduct
                          join b in context.Noun on a.IdNoun equals b.IdNoun
                          select new EditProductViewmodel
                          {
                              Product_Id = a.IdProduct,
                              NameUnit = b.Name,
                              NameProduct = a.ProductName,
                              ProductPrice = a.ProductPrice
                          };


            //return Ok(product);
            return View(product);
        }
        public IActionResult Add_Bill()
        {

            return View();
        }
        public IActionResult Get_dataProduct()
        {
            //Products model = new Products();
            var bill = new Bill()
            {
                BillNumber = 1
            };
            context.Bill.Add(bill);
            context.SaveChanges();

            var products = context.Product.ToList();
            return Json(products);
        }
        public IActionResult Data_Product_Select([FromBody] Productsparam model)
        {
                var json_data = from a in context.Product
                             where a.IdProduct == model.IdProduct
                              join b in context.Noun on a.IdNoun equals b.IdNoun
                              select new EditProductViewmodel
                              {
                                  NameUnit = b.Name,
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
            var Noun = context.Noun.ToList();
            return View(Noun);
        }
        public IActionResult Edit_Unit_Page(int? id)
        {
            var json_data = from a in context.Noun
                            where a.IdNoun == id
                            select new Unit { IdNoun = a.IdNoun, Name = a.Name };
            return View(json_data);
            ///   return View();
        }
        public IActionResult Edit_Product_Page(int? id)
        {
            //   int idproduct = id;
            EditProductViewmodel model = new EditProductViewmodel();
            model = (from a in context.Product
                     where a.IdProduct == id
                     join b in context.Noun on a.IdNoun equals b.IdNoun
                     select new EditProductViewmodel
                     {
                         IdNoun = a.IdNoun,
                         Product_Id = a.IdProduct,
                         NameUnit = b.Name,
                         NameProduct = a.ProductName,
                         ProductPrice = a.ProductPrice
                     }).FirstOrDefault();
            model.noun = context.Noun.ToList();
            return View(model);
            //  return View();
        }
        public IActionResult Detail_Bill(int? id)
        {
            DetailbillViewmodel model = new DetailbillViewmodel();
            model.bill = (from b in context.Bill
                         where b.BillNumber == id
                         join p in context.Product on b.IdProduct equals p.IdProduct
                         join u in context.Noun on p.IdNoun equals u.IdNoun
                          select new Bill2Viewmodel
                         {
                             NameUnit = u.Name,
                             NameProduct = p.ProductName,
                             ProductPrice = p.ProductPrice,
                             Count = b.Count,
                             Discount = b.Discount
                         }).ToList();;
            model.sumarybill = (from a in context.SumaryBill
                                join b in context.Bill on a.IdsumaryBill equals b.IdsumaryBill
                                select new billViewmodel
                                {
                                    Date = a.Date,
                                    Bill_Number = a.BillNumber,
                                    Price_Before = a.PriceBefore,
                                    Price_After = a.PriceAfter,
                                    Discount = a.TotalDiscount
                                }).FirstOrDefault();
            return View(model);
        }

        public IActionResult Update([FromBody] Unitparam model)
        {
            int check_update = 1;
            IQueryable<Unit> json_data = from a in context.Noun
                                         where model.Name == a.Name
                                         select new Unit { Name = a.Name };
            if (json_data.Count() == 0)
            {
                var result = context.Noun.SingleOrDefault(b => b.IdNoun == model.IdNoun);

                if (result != null)
                {
                    result.Name = model.Name;
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
                result.IdNoun = model.IdNoun;
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
            var Noun = context.Noun.ToList();

            return View(Noun);
        }

        public IActionResult Insert_Unit([FromBody] Unitparam model)
        {
            int checked_insert = 1;
            var result = context.Noun.Where(a => a.Name == model.Name).Count();
            if (result != 0)
            {
                checked_insert = 0;
            }
            else if (result == 0)
            {
                var nou = new Noun()
                {
                    Name = model.Name
                };
                context.Noun.Add(nou);
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
                IdNoun = model.IdNoun

            };
            context.Product.Add(product);
            context.SaveChanges();
            return Json(product);
        }

        public IActionResult Delete([FromBody] Unitparam model)
        {
            var del = context.Noun.Where(o => o.IdNoun == model.IdNoun).FirstOrDefault();
            if (del != null)
            {
                context.Noun.Remove(del);
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

