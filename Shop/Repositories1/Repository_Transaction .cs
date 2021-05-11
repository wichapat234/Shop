using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Models;
using Shop.Models.DBModels;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories1
{
    public class Repository_Transaction
    {
        private readonly _711_databaseContext context;
        private string status;
        private string format;
        private int idbill;
        private DateTime datemodel;

        public Repository_Transaction(_711_databaseContext context)
        {
            this.context = context;
        }

        public List<addbillViewmodel> Get_Bill(searchViewmodel model)
        {
            if (model.date != "")
            {
                format = "yyyy-MM-dd";
                CultureInfo provider = CultureInfo.InvariantCulture;
                provider = new CultureInfo("en-US");
                datemodel = DateTime.ParseExact(model.date, format, provider);
            }
            IQueryable<addbillViewmodel> queryResult = from a in context.Bill
                                                       where (a.NumberBill.Contains(model.NumberBill) && model.date == "") ||
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

                                                       };
            return queryResult.ToList();
        }
        public List<BillproductViewmodel> Get_Data_Detailbill(int id)
        {
            IQueryable<BillproductViewmodel> detailbill = from b in context.BillDetail
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
                                                          };
            return detailbill.ToList();
        }
        public bill_totalViewmodel Get_Data_Bill(int id)
        {
            IQueryable<bill_totalViewmodel> bill = from a in context.Bill
                                                     where a.IdBill == id
                                                     select new bill_totalViewmodel
                                                     {
                                                         Date = a.Date,
                                                         NumberBill = a.NumberBill,
                                                         PriceBefore = a.PriceBefore,
                                                         PriceAfter = a.PriceAfter,
                                                         TotalDiscount = a.TotalDiscount
                                                     };
            return bill.SingleOrDefault();
        }
        public List<EditProductViewmodel> Get_Data_Product()
        {
            IQueryable<EditProductViewmodel> dataProduct = from a in context.Product
                                                           join b in context.Unit on a.IdUnit equals b.IdUnit
                                                           select new EditProductViewmodel
                                                           {
                                                               Product_Id = a.IdProduct,
                                                               NameUnit = b.NameUnit,
                                                               NameProduct = a.ProductName,
                                                               ProductPrice = a.ProductPrice
                                                           };
            return dataProduct.ToList();
        }
        public int Insert_Detail_Bill(bill_detailparam model1)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var count = context.Bill.Count();
                    var name = "Bill-";
                    var NumberBill = name + count;
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

                    idbill = bill.IdBill;

                    foreach (var data in model1.detail1.ToList())
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
                    transaction.Commit();
                }
                catch (Exception )
                {
                    transaction.Rollback();
                }
            }
            return idbill;
        }

    }
}
