using System;
using System.Reflection;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using KalenFlix.Annotations;

namespace KalenFlix.Database
{
    class DataMapper<TEntity> where TEntity : class, new()
    {
        public TEntity Map(DataRow row)
        {
            var columnNames = row.Table.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();

            var objectProperties = typeof(TEntity).GetProperties().Where(p => p.GetCustomAttributes(typeof(DataColumnAttribute), true).Any());

            TEntity entity = new TEntity();

            foreach (var p in objectProperties)
            {
                PropertyMapper(typeof(TEntity), row, p, entity);
            }
            return entity;
        }

        public IEnumerable<TEntity> Map(DataTable table)
        {
            var columnNames = table.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();

            var objectProperties = typeof(TEntity).GetProperties().Where(p => p.GetCustomAttributes(typeof(DataColumnAttribute), true).Any());

            foreach (DataRow row in table.Rows)
            {
                TEntity entity = new TEntity();
                foreach (var p in objectProperties)
                {
                    PropertyMapper(typeof(TEntity), row, p, entity);
                }
                yield return entity;
            }
        }

        private static void PropertyMapper(Type type, DataRow row, PropertyInfo prop, object entity)
        {
            List<string> possibleColumnNames = GetDataNames(type, prop.Name);

            foreach (var columnName in possibleColumnNames)
            {
                if (!String.IsNullOrWhiteSpace(columnName) && row.Table.Columns.Contains(columnName))
                {
                    var propertyValue = row[columnName];
                    if (propertyValue != DBNull.Value)
                    {
                        ParsePrimitive(prop, entity, row[columnName]);
                        break;
                    }
                    else
                    {
                        propertyValue = null;
                        break;
                    }
                }
            }
        }

        private static List<string> GetDataNames(Type type, string propertyName)
        {
            var property = type.GetProperty(propertyName).GetCustomAttributes(false).Where(a => a.GetType().Name == "DataColumnAttribute").FirstOrDefault();

            if (property != null)
            {
                return ((DataColumnAttribute)property).ValueNames;
            }
            return new List<string>();
        }

        private static void ParsePrimitive(PropertyInfo prop, object entity, object value)
        {
            if (value == null)
            {
                prop.SetValue(entity, null, null);
            }
            else if (prop.PropertyType == typeof(string))
            {
                prop.SetValue(entity, value.ToString().Trim(), null);
            }
            else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
            {
                prop.SetValue(entity, int.Parse(value.ToString()), null);
            }
            else if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
            {
                prop.SetValue(entity, Convert.ToInt32(value) == 1, null);
            }
            else if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
            {
                prop.SetValue(entity, Convert.ToDateTime(value), null);
            }
        }

    }
}