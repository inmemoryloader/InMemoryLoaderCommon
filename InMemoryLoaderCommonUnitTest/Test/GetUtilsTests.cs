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
	public class GetUtilsTests
	{
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The get utils.
		/// </summary>
		private static IDynamicClassSetup getUtils = appBase.CommonComponentLoader.GetComponent;

		/// <summary>
		/// Gets the utils test1.
		/// </summary>
		/// <returns>The utils test1.</returns>
		public static object GetUtilsTest1 ()
		{
			try {
				object[] paramObject = { null };

				var getDateTime = appBase.ComponentLoader.InvokeMethod (getUtils.Assembly, getUtils.Class, "GetDateTime", paramObject);

				return getDateTime;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the utils test2.
		/// </summary>
		/// <returns>The utils test2.</returns>
		public static object GetUtilsTest2 ()
		{
			try {
				byte min = 0;
				byte max = 255;
				object[] paramObject = { 12, min, max };

				var getRandom = appBase.ComponentLoader.InvokeMethod (getUtils.Assembly, getUtils.Class, "GetRandomNumbers", paramObject);

				return getRandom;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}

