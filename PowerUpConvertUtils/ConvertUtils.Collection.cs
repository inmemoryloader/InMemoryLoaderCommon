using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;

namespace PowerUpConvertUtils
{
	public partial class ConvertUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Converts to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="list">List.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public DataTable ConvertTo<T>(IList<T> list)
		{
			DataTable table = CreateTable<T>();
			Type entityType = typeof(T);
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

			foreach (T item in list)
			{
				DataRow row = table.NewRow();

				foreach (PropertyDescriptor prop in properties)
				{
					row[prop.Name] = prop.GetValue(item);
				}

				table.Rows.Add(row);
			}

			return table;
		}
		/// <summary>
		/// Converts to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="rows">Rows.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public IList<T> ConvertTo<T>(IList<DataRow> rows)
		{
			IList<T> list = null;

			if (rows != null)
			{
				list = new List<T>();

				foreach (DataRow row in rows)
				{
					T item = CreateItem<T>(row);
					list.Add(item);
				}
			}

			return list;
		}
		/// <summary>
		/// Converts to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="table">Table.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public IList<T> ConvertTo<T>(DataTable table)
		{
			if (table == null)
			{
				return null;
			}

			List<DataRow> rows = new List<DataRow>();

			foreach (DataRow row in table.Rows)
			{
				rows.Add(row);
			}

			return ConvertTo<T>(rows);
		}
		/// <summary>
		/// Creates the item.
		/// </summary>
		/// <returns>The item.</returns>
		/// <param name="row">Row.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public T CreateItem<T>(DataRow row)
		{
			T obj = default(T);
			if (row != null)
			{
				obj = Activator.CreateInstance<T>();

				foreach (DataColumn column in row.Table.Columns)
				{
					PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
					try
					{
						object value = row[column.ColumnName];
						prop.SetValue(obj, value, null);
					}
					catch
					{
						// You can log something here
						throw;
					}
				}
			}

			return obj;
		}
		/// <summary>
		/// Creates the table.
		/// </summary>
		/// <returns>The table.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public DataTable CreateTable<T>()
		{
			Type entityType = typeof(T);
			DataTable table = new DataTable(entityType.Name);
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

			foreach (PropertyDescriptor prop in properties)
			{
				table.Columns.Add(prop.Name, prop.PropertyType);
			}

			return table;
		}
	}
}

