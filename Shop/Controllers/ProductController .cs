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
using Shop.ProductViewModels;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {

        private readonly Repository_Product repository_product; 
        private readonly Repository_Unit repository_unit;
        

        public ProductController(Repository_Product repository_product, Repository_Unit repository_unit)
        {
            this.repository_product = repository_product;
            this.repository_unit = repository_unit;
        }
        [HttpPost]
        public IActionResult List_Product() // done
        {
            List<ProductViewModel> model = repository_product.Get_Product();
            return Json(model);
        }
        [HttpGet]
       public IActionResult Check_Edit_Product([FromBody] ProductParam model) // done
        {
            string status;
            status = repository_product.Check_Product(model);
            return Json(status);
        }
        [HttpGet]
        public IActionResult Update_Product([FromQuery] ProductAddandEditParam model) // done 
        {
            string status;
            status = repository_product.Update_Product(model);
            return Json(status);
        }
        [HttpGet]
        public IActionResult Insert_Product([FromQuery] ProductAddandEditParam model) // done
        {
            string status;
            status = repository_product.Insert_Product(model);
            return Json(status);
        }
        [HttpGet]
        public IActionResult Delete_Product([FromQuery] ProductParam model) // done
        {
            string status;
            status = repository_product.Delete_Product(model);
            return Json(status);
        }
        [HttpGet]
        public IActionResult Get_Edit_Product(ProductParam modelParam) // done
        {
            ProductAddandEditViewModel model = repository_product.Get_Edit_Product(modelParam);
            model.getUnit = repository_product.Get_Unit();
            return Json(model);
        }
        [HttpGet]
        public IActionResult Add_Product_Page() //done
        {
            ProductAddandEditViewModel model = new ProductAddandEditViewModel();
            model.getUnit = repository_product.Get_Unit();
            return Json(model);
        }
    }
}

