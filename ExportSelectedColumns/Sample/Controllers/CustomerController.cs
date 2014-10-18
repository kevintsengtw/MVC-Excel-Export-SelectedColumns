using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sample.Infrastructure.ActionResults;
using Sample.Infrastructure.Helpers;
using Sample.Infrastructure.ViewModels;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Sample.Controllers
{
    public class CustomerController : Controller
    {
        NorthwindDbContext db = new NorthwindDbContext();

        public ActionResult Index()
        {
            //匯出資料欄位
            var exportColumns =
                ExportColumnAttributeHelper<CustomerViewModel>.GetExportColumns()
                    .Select(c => new SelectListItem()
                    {
                        Value = c.ColumnName,
                        Text = c.Name,
                        Selected = true
                    })
                    .ToList();

            ViewBag.ExportColumns = exportColumns;

            //要匯出的資料
            var exportData = db.Customers.OrderBy(x => x.CustomerID).ToList();

            Mapper.CreateMap<Customer, CustomerViewModel>();
            var result = Mapper.Map<List<CustomerViewModel>>(exportData);

            return View(result);
        }

        [HttpPost]
        public ActionResult HasData()
        {
            JObject jo = new JObject();
            bool result = !db.Customers.Count().Equals(0);
            jo.Add("Msg", result.ToString());
            return Content(JsonConvert.SerializeObject(jo), "application/json");
        }


        public ActionResult Export(string fileName, string selectedColumns)
        {
            var exportData = db.Customers.OrderBy(x => x.CustomerID).ToList();

            Mapper.CreateMap<Customer, CustomerViewModel>();
            var result = Mapper.Map<List<CustomerViewModel>>(exportData);

            var dt = ExportDataHelper.GetExportDataTable(result, selectedColumns);

            var exportFileName = string.IsNullOrWhiteSpace(fileName)
                ? string.Concat(
                    "CustomerData_",
                    DateTime.Now.ToString("yyyyMMddHHmmss"),
                    ".xlsx")
                : string.Concat(fileName, ".xlsx");

            return new ExportExcelResult
            {
                SheetName = "客戶資料",
                FileName = exportFileName,
                ExportData = dt
            };
        }

    }

}