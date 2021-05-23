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
    public class Repository_Unit
    {
        private readonly _711_databaseContext context;
        public Repository_Unit(_711_databaseContext context)
        {
            this.context = context;
        }

        public List<Unit> Get_Unit()
        {
            IQueryable<Unit> queryResult = from a in context.Unit
                                           select a;
            return queryResult.ToList();
        }

        public string Check_Unit(int id)
        {
            string status;
            var edit = context.Unit.Where(o => o.IdUnit == id).SingleOrDefault();
            if (edit != null)
            {
                status = "Success";
            }
            else
            {
                status = "Null";
            }

            return status;
        }
        public Unit Get_Edit_Unit(int id)
        {
            IQueryable<Unit> result = from a in context.Unit
                                      where a.IdUnit == id
                                      select a;
            Unit data = result.SingleOrDefault();
            return data;
        }
        public string Insert_Unit(Unitparam unit)
        {
            string status;
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var id_unit = (from b in context.Unit
                                   where b.NameUnit.ToLower().Contains(unit.Name.ToLower())
                                   select b.IdUnit).Count();

                    if (id_unit == 0)
                    {
                        var result = context.Unit.Where(a => a.NameUnit == unit.Name).Count();
                        var nou = new Unit()
                        {
                            NameUnit = unit.Name
                        };
                        context.Unit.Add(nou);
                        context.SaveChanges();
                        status = "Success";
                    }
                    else
                    {
                        status = "Duplicate";
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    status = "Error";
                }
            }
            return status;
        }
        public string Delete_Unit(Unitparam unit)
        {
            string status;
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var del = context.Unit.Where(o => o.IdUnit == unit.IdUnit).SingleOrDefault();
                    if (del != null)
                    {
                        context.Unit.Remove(del);
                        context.SaveChanges();
                        status = "Success";
                    }

                    else
                    {
                        status = "Null";

                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    status = "Error";

                }


            }

            return status;
        }

        public string Update_Unit(Unitparam unit)
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
                            status = "Success";
                        }
                        else
                        {
                            status = "Null";
                        }
                    }
                    else
                    {
                        status = "Duplicate";
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    status = "Error";
                }
            }
            return status;
        }



    }
}
