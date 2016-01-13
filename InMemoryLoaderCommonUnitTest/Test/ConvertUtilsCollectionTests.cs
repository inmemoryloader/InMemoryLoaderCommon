using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Linq;
using System.Globalization;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;

namespace InMemoryLoaderCommonUnitTest
{
	public class ConvertUtilsCollectionTests
	{
		private static AppBase appBase = AppBase.Instance;

		private static DataTable GetTable ()
		{
			// Here we create a DataTable with four columns.
			DataTable table = new DataTable ();
			table.Columns.Add ("Dosage", typeof(int));
			table.Columns.Add ("Drug", typeof(string));
			table.Columns.Add ("Patient", typeof(string));
			table.Columns.Add ("Date", typeof(DateTime));

			// Here we add five DataRows.
			table.Rows.Add (25, "Indocin", "David", DateTime.Now);
			table.Rows.Add (50, "Enebrel", "Sam", DateTime.Now);
			table.Rows.Add (10, "Hydralazine", "Christoff", DateTime.Now);
			table.Rows.Add (21, "Combivent", "Janet", DateTime.Now);
			table.Rows.Add (100, "Dilantin", "Melanie", DateTime.Now);
			return table;
		}

		public class Example
		{
			public string Name {
				get;
				set;
			}

			public string LastName {
				get;
				set;
			}
		}

		private static IList<Example> GetList ()
		{
			var list = new List<Example> ();

			var ex1 = new Example (){ Name = "Tha 1. Name", LastName = "Tha 1. LastName" };
			list.Add (ex1);

			var ex2 = new Example (){ Name = "Tha 2. Name", LastName = "Tha 2. LastName" };
			list.Add (ex2);

			var ex3 = new Example (){ Name = "Tha 3. Name", LastName = "Tha 3. LastName" };
			list.Add (ex3);

			var ex4 = new Example (){ Name = "Tha 4. Name", LastName = "Tha 4. LastName" };
			list.Add (ex4);

			var ex5 = new Example (){ Name = "Tha 5. Name", LastName = "Tha 5. LastName" };
			list.Add (ex5);

			return list;
		}

		private static IDynamicClassInfo convertUtils = 
			appBase.ComponentLoader.ComponentRegistry.Where (str => str.Key.Class.Contains ("ConvertUtils")).SingleOrDefault ().Value;

		public static bool ConvertCollectionTest1 ()
		{
			try {
				var list = GetList ();
				object[] paramArg = { list };

				// var result = appBase.ComponentLoader.InvokeMethod (convertUtils, "ConvertTo", paramArg);

				return true;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}

