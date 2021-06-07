using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Constan;
using Shop.Models;
using Shop.Models.DBModels;
using Shop.Repositories1;
using Shop.TransactionViewModels;

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
        [HttpPost]
        public IActionResult Get_Listbill([FromBody] searchParam model) // done
        {
            List<billViewModel> model1 = repository_transaction.Get_Bill(model);

            return Json(model1);
        }
        public IActionResult Add_Bill() // done
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert_detail_bill([FromBody] addBillAndBilldetailParam model1)
        {
            string status;
            int idbill = repository_transaction.Insert_Detail_Bill(model1);
            if(idbill == 0)
            {
                status = constant.ERROR;
            }
            else
            {
                status = constant.SUCCEES;
            }
            var objData = new { idbill, status };
            return Json(objData);
        }

        [HttpGet]
        public IActionResult Detail_Bill([FromQuery] billdetailParam modelParam)
        {
            getBillAndBilldetailViewModel model = new getBillAndBilldetailViewModel();
            model.bill = repository_transaction.Get_Data_Bill(modelParam);
            model.detail = repository_transaction.Get_Data_Detailbill(modelParam);
            return Json(model);
        }
    }
}

