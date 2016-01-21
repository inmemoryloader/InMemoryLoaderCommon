using NUnit.Framework;
using System;
using System.Collections;
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
	public class CryptUtilsHashUtilsTests
	{
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The crypt utils.
		/// </summary>
		private static IDynamicClassSetup cryptUtils = appBase.CommonComponentLoader.CryptComponent;

		/// <summary>
		/// Determines if hash utils test3 the specified paramAlgo paramString.
		/// </summary>
		/// <returns><c>true</c> if hash utils test3 the specified paramAlgo paramString; otherwise, <c>false</c>.</returns>
		/// <param name="paramAlgo">Parameter algo.</param>
		/// <param name="paramString">Parameter string.</param>
		public static string HashUtilsTest3 (string paramAlgo, string paramString)
		{
			try {

				object[] paramKind = { paramAlgo };
				var setAlgorithmKind = (string)appBase.ComponentLoader.InvokeMethod (cryptUtils.Assembly, cryptUtils.Class, "SetAlgorithmKind", paramKind);

				object[] paramEncrypt = { paramString };
				var hashString = (string)appBase.ComponentLoader.InvokeMethod (cryptUtils.Assembly, cryptUtils.Class, "ComputeHashAsString", paramEncrypt);

				return hashString;
			} catch (Exception ex) {
				throw ex;
			}		
		}
		/// <summary>
		/// Determines if hash utils test2 the specified paramKind.
		/// </summary>
		/// <returns><c>true</c> if hash utils test2 the specified paramKind; otherwise, <c>false</c>.</returns>
		/// <param name="paramKind">Parameter kind.</param>
		public static string HashUtilsTest2 (string paramKind)
		{
			try {
				object[] paramEncrypt = { paramKind };
				var setAlgorithmKind = (string)appBase.ComponentLoader.InvokeMethod (cryptUtils.Assembly, cryptUtils.Class, "SetAlgorithmKind", paramEncrypt);

				return setAlgorithmKind;
			} catch (Exception ex) {
				throw ex;
			}		
		}
		/// <summary>
		/// Determines if hash utils test1.
		/// </summary>
		/// <returns><c>true</c> if hash utils test1; otherwise, <c>false</c>.</returns>
		public static bool HashUtilsTest1 ()
		{
			try {
				object[] paramEncrypt = { true };
				var supportedAlgorithmKind = (IEnumerable)appBase.ComponentLoader.InvokeMethod (cryptUtils.Assembly, cryptUtils.Class, "GetSupportedAlgorithmKind", paramEncrypt);

				return supportedAlgorithmKind != null;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}