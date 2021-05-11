using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Models;
using Shop.Models.DBModels;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories1
{
    public class Repository_Product
    {
        private readonly _711_databaseContext context;
        private string status = "";

        public Repository_Product(_711_databaseContext context)
        {
            this.context = context;
        }

        public List<Productsparam> Get_Product()
        {
            IQueryable<Productsparam> queryResult = from a in context.Product
                                                    join b in context.Unit on a.IdUnit equals b.IdUnit
                                                    select new Productsparam
                                                    {
                                                        Product_Id = a.IdProduct,
                                                        NameUnit = b.NameUnit,
                                                        NameProduct = a.ProductName,
                                                        ProductPrice = a.ProductPrice
                                                    };
            return queryResult.ToList();
        }

        public string Check_Product(int id)
        {
            var edit = context.Product.Where(o => o.IdProduct == id).SingleOrDefault();
            if (edit != null)
            {
                status = "Seccess";
            }
            else
            {
                status = "Fail";
            }
            var data = new { edit, status };

            return status;
        }
        public EditProductViewmodel Get_Edit_Product(int id)
        {
            IQueryable<EditProductViewmodel> result = from a in context.Product
                                                      where a.IdProduct == id
                                                      join b in context.Unit on a.IdUnit equals b.IdUnit
                                                      select new EditProductViewmodel
                                                      {
                                                          IdUnit = a.IdUnit,
                                                          Product_Id = a.IdProduct,
                                                          NameUnit = b.NameUnit,
                                                          NameProduct = a.ProductName,
                                                          ProductPrice = a.ProductPrice
                                                      };
            EditProductViewmodel data = result.SingleOrDefault();
            return data;
        }
        public string Insert_Product(Productsparam product)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var id_product = (from b in context.Product
                                      where b.ProductName.ToLower().Contains(product.ProductName.ToLower()) && b.IdUnit == product.IdUnit
                                      select b.IdProduct).Count();
                    if (id_product == 0)
                    {
                        var product1 = new Product()
                        {
                            ProductName = product.ProductName,
                            ProductPrice = product.ProductPrice,
                            IdUnit = product.IdUnit


                        };
                        context.Product.Add(product1);
                        context.SaveChanges();
                        status = "seccess";
                    }
                    else
                    {
                        status = "fail";
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    status = "Eror";
                }
            }
            return status;
        }
        public string Delete_Product(Productsparam product)
        {

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var del = context.Product.Where(o => o.IdProduct == product.IdProduct).SingleOrDefault();
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
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    status = "Eror";
                }
            }

            return status;
        }

        public string Update_Product(Productsparam product)
        {

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var count_row_product = (from b in context.Product
                                             where b.IdProduct != product.IdProduct && b.ProductName.ToLower().Contains(product.ProductName.ToLower()) && b.IdUnit == product.IdUnit
                                             select b.IdProduct).Count();
                    if (count_row_product == 0)
                    {
                        var result = context.Product.SingleOrDefault(b => b.IdProduct == product.IdProduct);
                        if (result != null)
                        {
                            result.ProductName = product.ProductName;
                            result.ProductPrice = product.ProductPrice;
                            result.IdUnit = product.IdUnit;
                            context.SaveChanges();
                            status = "seccess";

                        }
                        else
                        {
                            status = "null";
                        }
                    }
                    else
                    {
                        status = "fail";
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    status = "Eror";
                }

            }
            return status;
        }



    }
}
