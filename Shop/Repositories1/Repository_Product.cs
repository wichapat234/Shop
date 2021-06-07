using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Constan;
using Shop.Models;
using Shop.Models.DBModels;
using Shop.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories1
{
    public class Repository_Product
    {
        private readonly _711_databaseContext context;

        public Repository_Product(_711_databaseContext context)
        {
            this.context = context;
        }

        public List<ProductViewModel> Get_Product()
        {
            IQueryable<ProductViewModel> queryResult = from a in context.Product
                                                    join b in context.Unit on a.IdUnit equals b.IdUnit
                                                    orderby a.IdProduct
                                                    select new ProductViewModel
                                                    {
                                                        IdProduct = a.IdProduct,
                                                        NameUnit = b.NameUnit,
                                                        NameProduct = a.ProductName,
                                                        ProductPrice = a.ProductPrice,
                                                        IdUnit = b.IdUnit
                                                    };
            return queryResult.ToList();
        }

        public string Check_Product(ProductParam model)
        {
            string status;
            var edit = context.Product.Where(o => o.IdProduct == model.IdProduct).SingleOrDefault();
            if (edit != null)
            {
                status = constant.SUCCEES;
            }
            else
            {
                status = constant.NULL;
            }

            return status;
        }
        public ProductAddandEditViewModel Get_Edit_Product(ProductParam modelParam)
        {
            IQueryable<ProductAddandEditViewModel> result = from a in context.Product
                                                      where a.IdProduct == modelParam.IdProduct
                                                            join b in context.Unit on a.IdUnit equals b.IdUnit
                                                      select new ProductAddandEditViewModel
                                                      {
                                                          IdUnit = a.IdUnit,
                                                          IdProduct = a.IdProduct,
                                                          NameUnit = b.NameUnit,
                                                          NameProduct = a.ProductName,
                                                          ProductPrice = a.ProductPrice
                                                      };
            ProductAddandEditViewModel data = result.SingleOrDefault();
            return data;
        }
        public List<Unit> Get_Unit()
        {
            IQueryable<Unit> queryResult = from a in context.Unit
                                           select a;
            return queryResult.ToList();
        }
        public string Insert_Product(ProductAddandEditParam product)
        {
            string status;
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
                        status = constant.SUCCEES;
                    }
                    else
                    {
                        status = constant.DUPLICATE;
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    status = constant.ERROR;
                }
            }
            return status;
        }
        public string Delete_Product(ProductParam product)
        {
            string status;
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var del = context.Product.Where(o => o.IdProduct == product.IdProduct).SingleOrDefault();
                    if (del != null)
                    {
                        context.Product.Remove(del);
                        context.SaveChanges();
                        status = constant.SUCCEES;
                    }
                    else
                    {
                        status = constant.NULL;
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    status = constant.ERROR;
                }
            }

            return status;
        }

        public string Update_Product(ProductAddandEditParam product)
        {
            string status;
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
                            status = constant.SUCCEES;

                        }
                        else
                        {
                            status = constant.NULL;
                        }
                    }
                    else
                    {
                        status = constant.DUPLICATE;
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    status = constant.ERROR;
                }

            }
            return status;
        }



    }
}
