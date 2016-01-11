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
	public class ConvertUtilsByteArrayTests
	{
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The convert utils.
		/// </summary>
		private static IDynamicClassSetup convertUtils = appBase.CommonComponentLoader.ConvertComponent;



		public static bool ConvertByteArrayTest1 ()
		{
			try {
				object[] paramArg = { "Some String" };

				var result = appBase.ComponentLoader.InvokeMethod (convertUtils.Assembly, convertUtils.Class, "StringToByteArray", paramArg);

				return result is byte[];
			} catch (Exception ex) {
				throw ex;
			}		
		}

		public static bool ConvertByteArrayTest2 ()
		{
			try {
				object[] paramArg = { "Some String", Encoding.Default };

				var result = appBase.ComponentLoader.InvokeMethod (convertUtils.Assembly, convertUtils.Class, "StringToByteArray", paramArg);

				return result is byte[];
			} catch (Exception ex) {
				throw ex;
			}		
		}

		public static bool ConvertByteArrayTest3 ()
		{
			try {
				object[] paramArg = { "/media/kaysta/18B66500B664DFAC/Temp/IsNotYourShit.txt" };

				var result = appBase.ComponentLoader.InvokeMethod (convertUtils.Assembly, convertUtils.Class, "FileContentToByteArray", paramArg);

				return result is byte[];
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}

