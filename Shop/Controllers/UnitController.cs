using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Models;
using Shop.Models.DBModels;
using Shop.Repositories1;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class UnitController : Controller
    {

        private readonly Repository_Unit repository_unit;
        private string status;

        public UnitController(Repository_Unit repository_unit)
        {
            this.repository_unit = repository_unit;
        }
        public IActionResult List_Unit() // done
        {
            Unitviewmodel model = new Unitviewmodel();
            model.unit = repository_unit.Get_Unit();
            return View(model);
        }
      
        public IActionResult Edit_Unit_Page(int id) // done
        {
            Unitviewmodel model = new Unitviewmodel();
            model.unit1 = repository_unit.Get_Edit_Unit(id);
            return View(model);
        }
        public IActionResult Check_Edit_Unit([FromBody] Unitparam model1) // done
        {
            int id = model1.IdUnit;
            status = repository_unit.Check_Unit(id);
            var data = new { status, id };
            return Json(data);
        }
        public IActionResult Update_Unit([FromBody] Unitparam unit)  // done
        {
            status = repository_unit.Update_Unit(unit);
            return Json(status);
        }
        public IActionResult Add_Unit_Page() // done
        {
            return View();
        }
        public IActionResult Add_Product_Page() //done
        {
            EditProductViewmodel model = new EditProductViewmodel();
            model.unit = repository_unit.Get_Unit();
            return View(model);
        }
        public IActionResult Insert_Unit([FromBody] Unitparam unit) // done
        {

            status = repository_unit.Insert_Unit(unit);
            return Json(status);
        }
        public IActionResult Delete([FromBody] Unitparam unit) // done
        {
            status = repository_unit.Delete_Unit(unit);
            return Json(status);
        }

    }
}

