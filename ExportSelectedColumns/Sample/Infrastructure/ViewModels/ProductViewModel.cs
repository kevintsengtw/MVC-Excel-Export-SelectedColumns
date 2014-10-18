using Sample.Infrastructure.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Sample.Infrastructure.ViewModels
{
    public class ProductViewModel
    {
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Display(Name = "產品名稱")]
        [ExportColumn(Name = "產品名稱", Order = 1)]
        public string ProductName { get; set; }

        [Display(Name = "供應商")]
        [ExportColumn(Name = "供應商", Order = 2)]
        public string SupplierName { get; set; }

        [Display(Name = "產品分類")]
        [ExportColumn(Name = "產品分類", Order = 3)]
        public string CategoryName { get; set; }

        [Display(Name = "Quantity Per Unit")]
        [ExportColumn(Name = "Quantity Per Unit", Order = 4)]
        public string QuantityPerUnit { get; set; }

        [Display(Name = "Unit Price")]
        [ExportColumn(Name = "Unit Price", Order = 5)]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Units In Stock")]
        [ExportColumn(Name = "Units In Stock", Order = 6)]
        public short? UnitsInStock { get; set; }

        [Display(Name = "Units On Order")]
        [ExportColumn(Name = "Units On Order", Order = 7)]
        public short? UnitsOnOrder { get; set; }

        [Display(Name = "Reorder Level")]
        [ExportColumn(Name = "Reorder Level", Order = 8)]
        public short? ReorderLevel { get; set; }

        [Display(Name = "Discontinued")]
        [ExportColumn(Name = "Discontinued", Order = 9)]
        public string Discontinued { get; set; }

    }

}