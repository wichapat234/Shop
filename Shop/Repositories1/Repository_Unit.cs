using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Constan;
using Shop.Models;
using Shop.Models.DBModels;
using Shop.UnitViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories1
{
    public class Repository_Unit
    {
        private readonly _711_databaseContext context;
        public Repository_Unit(_711_databaseContext context)
        {
            this.context = context;
        }

        public List<UnitNameViewModel> Get_Unit()
        {
            IQueryable<UnitNameViewModel> queryResult = from a in context.Unit
                                           select new UnitNameViewModel
                                           {
                                               IdUnit = a.IdUnit,
                                               Name = a.NameUnit
                                           };
            return queryResult.ToList();
        }

        public string Check_Unit(UnitParam model)
        {
            string status;
            var edit = context.Unit.Where(o => o.IdUnit == model.IdUnit).SingleOrDefault();
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
        public UnitEditViewModel Get_Edit_Unit(UnitParam model)
        {
            IQueryable<UnitEditViewModel> result = from a in context.Unit
                                                     where a.IdUnit == model.IdUnit
                                                   select new UnitEditViewModel
                                                   {
                                                       Name = a.NameUnit
                                                   };
            UnitEditViewModel data = result.SingleOrDefault();
            return data;
        }
        public string Insert_Unit(UnitAddOREditParam model)
        {
            string status;
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var id_unit = (from b in context.Unit
                                   where b.NameUnit.ToLower() == (model.Name.ToLower())
                                   select b.IdUnit).Count();

                    if (id_unit == 0)
                    {
                        var result = context.Unit.Where(a => a.NameUnit == model.Name).Count();
                        var nou = new Unit()
                        {
                            NameUnit = model.Name
                        };
                        context.Unit.Add(nou);
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
        public string Delete_Unit(UnitParam model)
        {
            string status;
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var del = context.Unit.Where(o => o.IdUnit == model.IdUnit).SingleOrDefault();
                    if (del != null)
                    {
                        context.Unit.Remove(del);
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

        public string Update_Unit(UnitAddOREditParam unit)
        {
            string status;
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var id_unit = (from b in context.Unit
                                   where b.IdUnit != unit.IdUnit && b.NameUnit.ToLower().Contains(unit.Name.ToLower())
                                   select b.IdUnit).Count();
                    if (id_unit == 0)
                    {
                        var result = context.Unit.Where(b => b.IdUnit == unit.IdUnit).SingleOrDefault();
                        if (result != null)
                        {
                            result.NameUnit = unit.Name;
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
