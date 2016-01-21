using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;

namespace InMemoryLoaderCommon
{
	public class CollectionHelper
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static ILog log = LogManager.GetLogger (typeof(CollectionHelper));

		/// <summary>
		/// Initializes a new instance of the <see cref="InMemoryLoaderCommon.CollectionHelper"/> class.
		/// </summary>
		public CollectionHelper ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
		}

		/// <summary>
		/// Converts to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="rows">Rows.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public IList<T> ConvertTo<T>(IList<DataRow> paramRows)
		{
			IList<T> list = null;

			if (paramRows != null)
			{
				list = new List<T>();

				foreach (DataRow row in paramRows)
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
		public IList<T> ConvertTo<T>(DataTable paramTable)
		{
			if (paramTable == null)
			{
				return null;
			}

			List<DataRow> rows = new List<DataRow>();

			foreach (DataRow row in paramTable.Rows)
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
		public T CreateItem<T>(DataRow paramRow)
		{
			T obj = default(T);
			if (paramRow != null)
			{
				obj = Activator.CreateInstance<T>();

				foreach (DataColumn column in paramRow.Table.Columns)
				{
					PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
					try
					{
						object value = paramRow[column.ColumnName];
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
	}
}