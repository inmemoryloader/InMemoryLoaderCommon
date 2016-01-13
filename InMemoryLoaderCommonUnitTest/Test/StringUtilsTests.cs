using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;

namespace InMemoryLoaderCommonUnitTest
{
	public class StringUtilsTests
	{
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The string utils.
		/// </summary>
		private static IDynamicClassSetup stringUtils = appBase.CommonComponentLoader.StringComponent;


		public static object StringUtilsTest1 ()
		{
			try {
				var strToAbbr = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.";
				object[] paramObject = { strToAbbr, 64 };

				var getString = appBase.ComponentLoader.InvokeMethod (stringUtils.Assembly, stringUtils.Class, "Abbreviate", paramObject);

				return getString;
			} catch (Exception ex) {
				throw ex;
			}		
		}


		public static object StringUtilsTest2 ()
		{
			try {
				var strToAbbr = "Lorem ipsum dolor sit amet, Lorem ipsum dolor sit amet, Lorem ipsum dolor sit amet, Lorem ipsum dolor sit amet";
				object[] paramObject = { strToAbbr, "sit" };

				var getString = appBase.ComponentLoader.InvokeMethod (stringUtils.Assembly, stringUtils.Class, "CountOccurenceOfString", paramObject);

				return getString;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}

