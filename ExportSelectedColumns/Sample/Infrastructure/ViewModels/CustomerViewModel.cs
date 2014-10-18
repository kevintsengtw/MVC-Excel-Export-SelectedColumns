using Sample.Infrastructure.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Sample.Infrastructure.ViewModels
{
    public class CustomerViewModel
    {
        [Display(Name = "Customer ID")]
        public string CustomerID { get; set; }

        [Display(Name = "公司名稱")]
        [ExportColumn(Name = "公司名稱", Order = 1)]
        public string CompanyName { get; set; }

        [Display(Name = "聯絡者姓名")]
        [ExportColumn(Name = "聯絡者姓名", Order = 2)]
        public string ContactName { get; set; }

        [Display(Name = "聯絡者職稱")]
        [ExportColumn(Name = "聯絡者職稱", Order = 3)]
        public string ContactTitle { get; set; }

        [Display(Name = "地址")]
        [ExportColumn(Name = "地址", Order = 4)]
        public string Address { get; set; }

        [Display(Name = "城市")]
        [ExportColumn(Name = "城市", Order = 5)]
        public string City { get; set; }

        [Display(Name = "區域")]
        [ExportColumn(Name = "區域", Order = 6)]
        public string Region { get; set; }

        [Display(Name = "郵遞區號")]
        [ExportColumn(Name = "郵遞區號", Order = 7)]
        public string PostalCode { get; set; }

        [Display(Name = "國家")]
        [ExportColumn(Name = "國家", Order = 8)]
        public string Country { get; set; }

        [Display(Name = "電話號碼")]
        [ExportColumn(Name = "電話號碼", Order = 9)]
        public string Phone { get; set; }

        [Display(Name = "傳真號碼")]
        [ExportColumn(Name = "傳真號碼", Order = 10)]
        public string Fax { get; set; }
    }

}