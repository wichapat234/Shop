using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Models;
using Shop.Models.DBModels;
using Shop.TransactionViewModels;
using Shop.ProductViewModels;
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
        private const string format = "yyyy-MM-dd";
        private DateTime startdate;
        private DateTime enddate;

        public Repository_Transaction(_711_databaseContext context)
        {
            this.context = context;
        }

        public List<billViewModel> Get_Bill(searchParam model)
        {
            if (model.startdate != "")
            {

                startdate = DateTime.ParseExact(model.startdate, format, CultureInfo.InvariantCulture);
            }
            if(model.enddate != "")
            {
                enddate = DateTime.ParseExact(model.enddate, format, CultureInfo.InvariantCulture);
            }
            IQueryable<billViewModel> queryResult = from a in context.Bill
                                                       where 
                                                       (model.startdate == "" || startdate <= a.Date) && (model.enddate == "" || enddate >= a.Date) &&
                                                       (model.NumberBill == "" || a.NumberBill.Contains(model.NumberBill))

                                                       select new billViewModel
                                                       {
                                                           IdBill = a.IdBill,
                                                           PriceBefore = a.PriceBefore,
                                                           TotalDiscount = a.TotalDiscount,
                                                           PriceAfter = a.PriceAfter,
                                                           DateTime = a.Date,
                                                           NumberBill = a.NumberBill
                                                       };
            return queryResult.ToList();
        }
        public List<billdetailViewModel> Get_Data_Detailbill(billdetailParam modelParam)
        {
            IQueryable<billdetailViewModel> detailbill = from b in context.BillDetail
                                                          where b.IdBill == modelParam.IdBill
                                                         join p in context.Product on b.IdProduct equals p.IdProduct
                                                          join u in context.Unit on p.IdUnit equals u.IdUnit
                                                          select new billdetailViewModel
                                                          {
                                                              NameUnit = u.NameUnit,
                                                              NameProduct = p.ProductName,
                                                              ProductPrice = p.ProductPrice,
                                                              Count = b.Count,
                                                              Discount = b.Discount,
                                                              totalPrice = b.TotalPrice,
                                                              lastPrice = b.LastPrice
                                                          };
            return detailbill.ToList();
        }
        public billViewModel Get_Data_Bill(billdetailParam modelParam)
        {
            IQueryable<billViewModel> bill = from a in context.Bill
                                                     where a.IdBill == modelParam.IdBill
                                             select new billViewModel
                                                     {
                                                         DateTime = a.Date,
                                                         NumberBill = a.NumberBill,
                                                         PriceBefore = a.PriceBefore,
                                                         PriceAfter = a.PriceAfter,
                                                         TotalDiscount = a.TotalDiscount
                                                     };
            return bill.SingleOrDefault();
        }
        public int Insert_Detail_Bill(addBillAndBilldetailParam model1)
        {
            int idbill = 0;
            string status;
            startdate = DateTime.ParseExact(model1.bill.Date, format , CultureInfo.InvariantCulture);
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {

                    var count = context.Bill.Count();
                    int num = count+1;
                    var name = "Bill-";
                    var NumberBill = name + num;
                    var bill = new Bill()
                    
                    {
                        PriceBefore = model1.bill.PriceBefore,
                        TotalDiscount = model1.bill.TotalDiscount,
                        PriceAfter = model1.bill.PriceAfter,
                        Date = startdate,
                        NumberBill = NumberBill,
                    };
                    context.Bill.Add(bill);
                    context.SaveChanges();

                    idbill = bill.IdBill;

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
