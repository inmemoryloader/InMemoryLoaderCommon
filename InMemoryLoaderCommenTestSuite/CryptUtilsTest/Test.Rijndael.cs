using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;

namespace InMemoryLoaderCommenTestSuite.CryptUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The crypt string.
		/// </summary>
		private static string cryptString = "This is some Text";
		/// <summary>
		/// The crypted string.
		/// </summary>
		private static string cryptedString = "2rv8yVGKCF0Dcn0bWlwrxvaCHdvXes1Rx2TVXZkdC54=";

		public static bool CryptRijndaelTest ()
		{
			bool cryptRijndaelTest = false;

			cryptRijndaelTest = CryptRijndaelTest1 ();
			cryptRijndaelTest = CryptRijndaelTest2 ();

			return cryptRijndaelTest;
		}

		/// <summary>
		/// Crypts the rijndael test1.
		/// </summary>
		/// <returns>The rijndael test1.</returns>
		/// <param name="paramString">Parameter string.</param>
		private static bool CryptRijndaelTest1 ()
		{
			try {
				bool isTrue = false;

				object[] paramEncrypt = { cryptString };
				var encrypt = appBase.ComponentLoader.InvokeMethod (cryptUtils, "Encrypt", paramEncrypt);

				var encryptString = Convert.ToString (encrypt);

				if (encryptString.Equals (cryptedString)) {
					isTrue = true;
				}

				log.DebugFormat ("Encrypt (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Crypts the rijndael test2.
		/// </summary>
		/// <returns>The rijndael test2.</returns>
		/// <param name="paramString">Parameter string.</param>
		private static bool CryptRijndaelTest2 ()
		{
			try {
				bool isTrue = false;

				object[] paramDecrypt = { cryptedString };
				var decrypt = appBase.ComponentLoader.InvokeMethod (cryptUtils, "Decrypt", paramDecrypt);

				var decryptString = Convert.ToString (decrypt);

				if (decryptString.Equals (cryptString)) {
					isTrue = true;
				}

				log.DebugFormat ("Decrypt (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}