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
    public class ProductController : Controller
    {
        NorthwindDbContext db = new NorthwindDbContext();

        public ActionResult Index()
        {
            //匯出資料欄位
            var exportColumns =
                ExportColumnAttributeHelper<ProductViewModel>.GetExportColumns()
                    .Select(c => new SelectListItem()
                    {
                        Value = c.ColumnName,
                        Text = c.Name,
                        Selected = true
                    })
                    .ToList();

            ViewBag.ExportColumns = exportColumns;

            //要匯出的資料
            var exportData = db.Products.OrderBy(x => x.ProductID).ToList();

            Mapper.CreateMap<Product, ProductViewModel>()
                .ForMember(d => d.SupplierName, o => o.MapFrom(s => s.Supplier.CompanyName))
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.CategoryName))
                .ForMember(d => d.Discontinued, o => o.MapFrom(s => s.Discontinued ? "已停止" : "--"));

            var result = Mapper.Map<List<ProductViewModel>>(exportData);

            return View(result);
        }

        [HttpPost]
        public ActionResult HasData()
        {
            JObject jo = new JObject();
            bool result = !db.Products.Count().Equals(0);
            jo.Add("Msg", result.ToString());
            return Content(JsonConvert.SerializeObject(jo), "application/json");
        }


        public ActionResult Export(string fileName, string selectedColumns)
        {
            var exportData = db.Products.OrderBy(x => x.ProductID).ToList();

            Mapper.CreateMap<Product, ProductViewModel>()
                .ForMember(d => d.SupplierName, o => o.MapFrom(s => s.Supplier.CompanyName))
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.CategoryName))
                .ForMember(d => d.Discontinued, o => o.MapFrom(s => s.Discontinued ? "已停止" : "--"));

            var result = Mapper.Map<List<ProductViewModel>>(exportData);

            var dt = ExportDataHelper.GetExportDataTable(result, selectedColumns);

            var exportFileName = string.IsNullOrWhiteSpace(fileName)
                ? string.Concat(
                    "ProductData_",
                    DateTime.Now.ToString("yyyyMMddHHmmss"),
                    ".xlsx")
                : string.Concat(fileName, ".xlsx");

            return new ExportExcelResult
            {
                SheetName = "產品資料",
                FileName = exportFileName,
                ExportData = dt
            };
        }
    }

}