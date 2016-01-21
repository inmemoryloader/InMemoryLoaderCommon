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
	public class DataTableHelper
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static ILog log = LogManager.GetLogger (typeof(DataTableHelper));

		/// <summary>
		/// Initializes a new instance of the <see cref="InMemoryLoaderCommon.DataTableHelper"/> class.
		/// </summary>
		public DataTableHelper ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
		}

		/// <summary>
		/// Converts to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="list">List.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public DataTable ConvertTo<T>(IList<T> paramList)
		{
			DataTable table = CreateTable<T>();
			Type entityType = typeof(T);
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

			foreach (T item in paramList)
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

