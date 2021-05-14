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
    public class TransactionController : Controller
    {
        private readonly Repository_Transaction repository_transaction;

        public TransactionController(Repository_Transaction repository_transaction)
        {
            this.repository_transaction = repository_transaction;
        }

        public IActionResult List_Bill()
        {
            return View();
        }
        public IActionResult Get_Listbill([FromBody] searchViewmodel model) // done
        {
            List<addbillViewmodel> model1 = repository_transaction.Get_Bill(model);
            return Json(model1);
        }
        public IActionResult Add_Bill() // done
        {
            return View();
        }
        public IActionResult insert_detail_bill([FromBody] bill_detailparam model1)
        {
            int idbill = repository_transaction.Insert_Detail_Bill(model1);
            return Json(idbill);
        }
        public IActionResult Detail_Bill(int id)
        {
            bill_detailViewmodel model = new bill_detailViewmodel();
            model.bill = repository_transaction.Get_Data_Bill(id);
            model.detail = repository_transaction.Get_Data_Detailbill(id);
            return View(model);
        }
        public IActionResult GatdataProduct()
        {
            List<EditProductViewmodel> model = repository_transaction.Get_Data_Product();
            return Json(model);
        }
    }
}

