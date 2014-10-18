using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Infrastructure.Helpers
{
    public class ExportColumnObject
    {
        public Guid ID { get; set; }

        /// <summary>
        /// 欄位輸出名稱.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// 欄位順序.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// 欄位（屬性）名稱.
        /// </summary>
        /// <value>
        /// The name of the column.
        /// </value>
        public string ColumnName { get; set; }

        public ExportColumnObject()
        {
            this.ID = Guid.NewGuid();
        }

    }

}