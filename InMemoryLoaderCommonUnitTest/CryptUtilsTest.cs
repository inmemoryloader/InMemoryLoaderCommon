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


		[Test ()]
		public void CryptUtilsRijndaelTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CryptUtilsRijndaelTestCase");

				var cryptString = "This is some Text";

				var cryptedString = "2rv8yVGKCF0Dcn0bWlwrxvaCHdvXes1Rx2TVXZkdC54=";

				var returnCryptedString = CryptUtilsRijndaelTests.CryptRijndaelTest1(cryptString);

				Assert.AreEqual(cryptedString, returnCryptedString);

				log.InfoFormat ("CryptRijndaelTest1 are equal : {0} {1}", cryptedString, returnCryptedString);

				var returnDeryptedString = CryptUtilsRijndaelTests.CryptRijndaelTest2(returnCryptedString);

				Assert.AreEqual(cryptString, returnDeryptedString);

				log.InfoFormat ("CryptRijndaelTest1 are equal : {0} {1}", cryptString, returnDeryptedString);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}
	}
}

