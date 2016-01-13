using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class ConvertUtilsTest
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(ConvertUtilsTest));


		[Test ()]
		public void ConvertUtilsCollectionTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "ConvertUtilsCollectionTestCase");

				// Is true
				var isTrue1 = ConvertUtilsCollectionTests.ConvertCollectionTest1 ();
				Assert.IsTrue (isTrue1);
				log.InfoFormat ("ConvertCollectionTest1 = true is {0}", isTrue1);


			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Converts the utils byte array test case.
		/// </summary>
		[Test ()]
		public void ConvertUtilsByteArrayTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "ConvertUtilsByteArrayTestCase");

				// Is true
				var isTrue1 = ConvertUtilsByteArrayTests.ConvertByteArrayTest1 ();
				Assert.IsTrue (isTrue1);
				log.InfoFormat ("ConvertByteArrayTest1 = true is {0}", isTrue1);

				// Is true
				var isTrue2 = ConvertUtilsByteArrayTests.ConvertByteArrayTest2 ();
				Assert.IsTrue (isTrue2);
				log.InfoFormat ("ConvertByteArrayTest2 = true is {0}", isTrue2);

				// Is true
				var isTrue3 = ConvertUtilsByteArrayTests.ConvertByteArrayTest3 ();
				Assert.IsTrue (isTrue3);
				log.InfoFormat ("ConvertByteArrayTest3 = true is {0}", isTrue3);


			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}

		/// <summary>
		/// Converts the utils bool test case.
		/// </summary>
		[Test ()]
		public void ConvertUtilsBoolTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "ConvertUtilsBoolTestCase");

				// Is true
				var isTrue1 = ConvertUtilsBoolTests.ConvertBoolTest1 ();
				Assert.IsTrue (isTrue1);
				log.InfoFormat ("ConvertBoolTest1 = true is {0}", isTrue1);

				// Is false
				var isTrue2 = ConvertUtilsBoolTests.ConvertBoolTest2 ();
				Assert.IsFalse (isTrue2);
				log.InfoFormat ("ConvertBoolTest1 = false is {0}", isTrue2);

				// Is true
				var isTrue3 = ConvertUtilsBoolTests.ConvertBoolTest3 ();
				Assert.IsTrue (isTrue3);
				log.InfoFormat ("ConvertBoolTest3 = true is {0}", isTrue3);


			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}
	}
}

