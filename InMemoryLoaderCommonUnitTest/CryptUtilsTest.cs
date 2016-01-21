using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class CryptUtilsTest
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(CryptUtilsTest));

		/// <summary>
		/// Crypts the utils hash utils test case.
		/// </summary>
		[Test ()]
		public void CryptUtilsHashUtilsTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CryptUtilsHashUtilsTestCase");

				// IsTrue
				var isTrue1 = CryptUtilsHashUtilsTests.HashUtilsTest1 ();
				Assert.IsTrue (isTrue1);
				log.InfoFormat ("HashUtilsTest1 = true : {0}", isTrue1);

				// True
				string paramKind = "SHA1";
				var algoKing = CryptUtilsHashUtilsTests.HashUtilsTest2 (paramKind);
				Assert.AreEqual(paramKind, paramKind);
				log.InfoFormat ("HashUtilsTest2 = true : {0}", string.Equals(paramKind, paramKind));

				// True equal
				string paramAlgoKind = "SHA1";
				string paramToEncrypt = "Some splendid Text";
				string paramEncrypted = "]0\n\u00a0»Zì‰”¥mê‰\u001cQUÄï\u008fÅ";

				var encrypted = CryptUtilsHashUtilsTests.HashUtilsTest3 (paramAlgoKind, paramToEncrypt);
				string stringEncrypted = encrypted;

				Assert.AreEqual (paramEncrypted, stringEncrypted);
				log.InfoFormat ("HashUtilsTest3 = true : {0}", string.Equals(paramEncrypted, stringEncrypted));

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Crypts the utils rijndael test case.
		/// </summary>
		[Test ()]
		public void CryptUtilsRijndaelTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CryptUtilsRijndaelTestCase");

				var cryptString = "This is some Text";

				var cryptedString = "2rv8yVGKCF0Dcn0bWlwrxvaCHdvXes1Rx2TVXZkdC54=";

				var returnCryptedString = CryptUtilsRijndaelTests.CryptRijndaelTest1 (cryptString);

				Assert.AreEqual (cryptedString, returnCryptedString);

				log.InfoFormat ("CryptRijndaelTest1 are equal : {0} {1}", cryptedString, returnCryptedString);

				var returnDeryptedString = CryptUtilsRijndaelTests.CryptRijndaelTest2 (returnCryptedString);

				Assert.AreEqual (cryptString, returnDeryptedString);

				log.InfoFormat ("CryptRijndaelTest1 are equal : {0} {1}", cryptString, returnDeryptedString);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}
	}
}

