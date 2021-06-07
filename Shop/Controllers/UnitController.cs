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
using Shop.UnitViewModels;

namespace Shop.Controllers
{
    public class UnitController : Controller
    {

        private readonly Repository_Unit repository_unit;
        
        public UnitController(Repository_Unit repository_unit)
        {
            this.repository_unit = repository_unit;
        }
        [HttpGet]
        public IActionResult List_Unit() // done
        {
            UnitIndexViewModel model = new UnitIndexViewModel();
            model.getUnit = repository_unit.Get_Unit();
            return Json(model);
        }

       [HttpGet]
        public IActionResult Get_Edit_Unit([FromQuery] UnitParam model) // done
        {
            UnitEditViewModel modelView = new UnitEditViewModel();
            modelView = repository_unit.Get_Edit_Unit(model);
            return Json(modelView);
        }

        [HttpGet]
        public IActionResult Check_Edit_Unit([FromQuery] UnitParam model) // done
        {
            string status;
            status = repository_unit.Check_Unit(model);
            return Json(status);
        }

        [HttpPost]
        public IActionResult Update_Unit([FromBody] UnitAddOREditParam model )  // done
        {
            string status;
            status = repository_unit.Update_Unit(model);
            return Json(status);
        }





        public IActionResult Add_Unit_Page() // done
        {
            return View();
        }
        [HttpGet]
        public IActionResult Insert_Unit([FromQuery] UnitAddOREditParam model) // done
        {
            string status;
            status = repository_unit.Insert_Unit(model);
            return Json(status);
        }
        [HttpGet]
        public IActionResult Delete_Unit([FromQuery] UnitParam model) // done
        {
            string status;
            status = repository_unit.Delete_Unit(model);
            return Json(status);
        }

    }
}

