using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;

namespace InMemoryLoaderCommonUnitTest
{
	public class CheckUtilsByteTests
	{
		private static AppBase appBase = AppBase.Instance;

		private static IDynamicClassSetup checkComponent = appBase.CommonComponentLoader.CheckComponent;

		private const int isInt = 64;

		private static byte[] isByte = new byte[isInt];

		/// <summary>
		/// Determines if is byte = true
		/// </summary>
		/// <returns><c>true</c> if is byte test1; otherwise, <c>false</c>.</returns>
		public static bool IsByteTest1 ()
		{
			try {
				object[] paramArg = { isByte[2] };

				var result = appBase.ComponentLoader.InvokeMethod (checkComponent.Assembly, checkComponent.Class, "IsStringByte", paramArg);
				var isTrue = Convert.ToBoolean(result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
		/// <summary>
		/// Determines if is byte = false
		/// </summary>
		/// <returns><c>true</c> if is byte test2; otherwise, <c>false</c>.</returns>
		public static bool IsByteTest2 ()
		{
			try {
				object[] paramArg = { "SomeString" };

				var result = appBase.ComponentLoader.InvokeMethod (checkComponent.Assembly, checkComponent.Class, "IsStringByte", paramArg);
				var isTrue = Convert.ToBoolean(result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
		/// <summary>
		/// Determines if is byte = true
		/// </summary>
		/// <returns><c>true</c> if is byte test3; otherwise, <c>false</c>.</returns>
		public static bool IsByteTest3 ()
		{
			try {
				object[] paramArg = { isByte[2], NumberStyles.None };

				var result = appBase.ComponentLoader.InvokeMethod (checkComponent.Assembly, checkComponent.Class, "IsStringByte", paramArg);
				var isTrue = Convert.ToBoolean(result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
		/// <summary>
		/// Determines if is byte = false
		/// </summary>
		/// <returns><c>true</c> if is byte test3; otherwise, <c>false</c>.</returns>
		public static bool IsByteTest4 ()
		{
			try {
				object[] paramArg = { "SomeString", NumberStyles.None, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod (checkComponent.Assembly, checkComponent.Class, "IsStringByte", paramArg);
				var isTrue = Convert.ToBoolean(result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
		/// <summary>
		/// Determines if is byte = true
		/// </summary>
		/// <returns><c>true</c> if is byte test3; otherwise, <c>false</c>.</returns>
		public static bool IsByteTest5 ()
		{
			try {
				object[] paramArg = { isByte[2], NumberStyles.None, CultureInfo.CurrentCulture };

				var result = appBase.ComponentLoader.InvokeMethod (checkComponent.Assembly, checkComponent.Class, "IsStringByte", paramArg);
				var isTrue = Convert.ToBoolean(result);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

