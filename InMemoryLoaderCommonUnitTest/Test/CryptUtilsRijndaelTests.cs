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
	public class CryptUtilsRijndaelTests
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
		/// Crypts the rijndael test1.
		/// </summary>
		/// <returns>The rijndael test1.</returns>
		/// <param name="paramString">Parameter string.</param>
		public static string CryptRijndaelTest1 (string paramString)
		{
			try {
				object[] paramEncrypt = { paramString };
				var encrypt = appBase.ComponentLoader.InvokeMethod (cryptUtils.Assembly, cryptUtils.Class, "Encrypt", paramEncrypt);

				var encryptString = Convert.ToString(encrypt);

				return encryptString;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Crypts the rijndael test2.
		/// </summary>
		/// <returns>The rijndael test2.</returns>
		/// <param name="paramString">Parameter string.</param>
		public static string CryptRijndaelTest2 (string paramString)
		{
			try {
				object[] paramDecrypt = { paramString };
				var decrypt = appBase.ComponentLoader.InvokeMethod (cryptUtils.Assembly, cryptUtils.Class, "Decrypt", paramDecrypt);

				var isString = Convert.ToString(decrypt);

				return isString;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}

