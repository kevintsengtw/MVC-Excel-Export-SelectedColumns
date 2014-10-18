using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Sample.Infrastructure.Attributes;

namespace Sample.Infrastructure.Helpers
{
    public class ExportColumnAttributeHelper<T> where T : class
    {
        /// <summary>
        /// Gets the export columns.
        /// </summary>
        /// <returns></returns>
        public static List<ExportColumnObject> GetExportColumns()
        {
            var type = typeof(T);
            var infos = type.GetProperties();

            var result = infos.Select(x => x.Name)
                              .Select(propertyName => GetProperty(type, propertyName))
                              .Select(GetExportColumnInstance)
                              .Where(instance => instance != null)
                              .ToList();

            return result.OrderBy(x => x.Order).ToList();
        }

        /// <summary>
        /// Gets the export column instance.
        /// </summary>
        /// <param name="pInfo">The p information.</param>
        /// <returns></returns>
        public static ExportColumnObject GetExportColumnInstance(PropertyInfo pInfo)
        {
            if (null == pInfo) return null;
            try
            {
                var arr = pInfo.GetCustomAttributes(typeof(ExportColumnAttribute), true);

                if (arr.Length.Equals(0)) return null;

                var attr = arr[0] as ExportColumnAttribute;

                var instance = new ExportColumnObject()
                {
                    ColumnName = pInfo.Name,
                    Name = attr.Name,
                    Order = attr.Order
                };

                return instance;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="propName">Name of the property.</param>
        /// <returns></returns>
        private static PropertyInfo GetProperty(Type type, string propName)
        {
            try
            {
                var infos = type.GetProperties()
                                .Where(info => propName.ToLower().Equals(info.Name.ToLower()));

                foreach (var info in infos)
                {
                    return info;
                }
            }
            catch
            {
                throw;
            }
            return null;
        }
    }

}