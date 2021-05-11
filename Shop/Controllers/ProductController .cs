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
    public class ProductController : Controller
    {

        private readonly Repository_Product repository_product; 
        private readonly Repository_Unit repository_unit;
        private string status;

        public ProductController(Repository_Product repository_product, Repository_Unit repository_unit)
        {
            this.repository_product = repository_product;
            this.repository_unit = repository_unit;
        }
        public IActionResult List_Product() // done
        {
            List<Productsparam> model = repository_product.Get_Product();
            return View(model);
        }
       public IActionResult Check_Edit_Product([FromBody] Productsparam model) // done
        {
            int id = model.IdProduct;
            status = repository_product.Check_Product(id);
            var data = new { status, id };
            return Json(data);
        }
        public IActionResult Update_Product([FromBody] Productsparam model) // done
        {
            status = repository_product.Update_Product(model);
            return Json(status);
        }
        public IActionResult Insert_Product([FromBody] Productsparam model) // done
        {
            status = repository_product.Insert_Product(model);
            return Json(status);
        }
        public IActionResult Delete_Product([FromBody] Productsparam model) // done
        {
            status = repository_product.Delete_Product(model);
            return Json(status);
        }
        public IActionResult Edit_Product_Page(int id) // done
        {
            EditProductViewmodel model = repository_product.Get_Edit_Product(id);
            model.unit = repository_unit.Get_Unit();
            return View(model);
        }
        public IActionResult Add_Product_Page() //done
        {
            EditProductViewmodel model = new EditProductViewmodel();
            model.unit = repository_unit.Get_Unit();
            return View(model);
        }
    }
}

