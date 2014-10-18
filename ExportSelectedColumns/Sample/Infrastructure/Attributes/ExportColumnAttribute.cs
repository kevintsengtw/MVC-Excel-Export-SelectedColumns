using System;

namespace Sample.Infrastructure.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class ExportColumnAttribute : Attribute
    {
        /// <summary>
        /// 欄位顯示名稱.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// 欄位顯示順序.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Order { get; set; }

        public ExportColumnAttribute()
        {
        }
    }

}