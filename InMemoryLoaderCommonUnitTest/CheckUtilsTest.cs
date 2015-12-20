using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;

namespace InMemoryLoaderCommonUnitTest
{
	/// <summary>
	/// Check utils test.
	/// </summary>
	[TestFixture ()]
	public class CheckUtilsTest
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(CheckUtilsTest));

		// IDynamicClassInfo classInfo = compLoader.ComponentRegistry.Where (str => str.Key.Class.Contains("CheckUtils")).SingleOrDefault().Value;

		[Test ()]
		public void CheckUtilsFloatTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CheckUtilsDecimalTestCase");

				// Is true
				var isTrue1 = CheckUtilsFloatTests.IsFloatTest1();
				Assert.IsTrue(isTrue1);
				log.InfoFormat ("IsFloatTest1 = true is {0}", isTrue1);

				// Is false
				var isTrue2 = CheckUtilsFloatTests.IsFloatTest2();
				Assert.IsFalse(isTrue2);
				log.InfoFormat ("IsFloatTest2 = true is {0}", isTrue2);

				// Is true
				var isTrue3 = CheckUtilsFloatTests.IsFloatTest3();
				Assert.IsTrue(isTrue3);
				log.InfoFormat ("IsFloatTest3 = true is {0}", isTrue3);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}

		[Test ()]
		public void CheckUtilsDoubleTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CheckUtilsDecimalTestCase");

				// Is true
				var isTrue1 = CheckUtilsDoubleTests.IsDoubleTest1();
				Assert.IsTrue(isTrue1);
				log.InfoFormat ("IsDoubleTest1 = true is {0}", isTrue1);

				// Is false
				var isTrue2 = CheckUtilsDoubleTests.IsDoubleTest2();
				Assert.IsFalse(isTrue2);
				log.InfoFormat ("IsDoubleTest2 = true is {0}", isTrue2);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}

		[Test ()]
		public void CheckUtilsDecimalTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CheckUtilsDecimalTestCase");

				// Is true
				var isTrue1 = CheckUtilsDecimalTests.IsDecimalTest1();
				Assert.IsTrue(isTrue1);
				log.InfoFormat ("IsDecimalTest1 = true is {0}", isTrue1);

				// Is true
				var isTrue2 = CheckUtilsDecimalTests.IsDecimalTest2();
				Assert.IsTrue(isTrue2);
				log.InfoFormat ("IsDecimalTest2 = true is {0}", isTrue2);

				// Is false
				var isTrue3 = CheckUtilsDecimalTests.IsDecimalTest3();
				Assert.IsFalse(isTrue3);
				log.InfoFormat ("IsDecimalTest3 = false is {0}", isTrue3);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}

		[Test ()]
		public void CheckUtilsDateTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CheckUtilsDateTestCase");

				// Is true
				var isTrue1 = CheckUtilsDateTests.IsDateTest1();
				Assert.IsTrue(isTrue1);
				log.InfoFormat ("IsDateTest1 = true is {0}", isTrue1);

				// Is true
				var isTrue2 = CheckUtilsDateTests.IsDateTest2();
				Assert.IsTrue(isTrue2);
				log.InfoFormat ("IsDateTest2 = true is {0}", isTrue2);

				// Is false
				var isTrue3 = CheckUtilsDateTests.IsDateTest3();
				Assert.IsFalse(isTrue3);
				log.InfoFormat ("IsDateTest3 = false is {0}", isTrue3);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}

		/// <summary>
		/// Checks the utils byte test cases.
		/// </summary>
		[Test ()]
		public void CheckUtilsByteTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CheckUtilsByteTestCase");

				// Is true
				var isTrue1 = CheckUtilsByteTests.IsByteTest1();
				Assert.IsTrue(isTrue1);
				log.InfoFormat ("IsByteTest1 = true is {0}", isTrue1);

				// Is false
				var isTrue2 = CheckUtilsByteTests.IsByteTest2();
				Assert.IsFalse(isTrue2);
				log.InfoFormat ("IsByteTest2 = false is {0}", isTrue2);

				// Is true
				var isTrue3 = CheckUtilsByteTests.IsByteTest3();
				Assert.IsTrue(isTrue3);
				log.InfoFormat ("IsByteTest3 = true is {0}", isTrue3);

				// Is false
				var isTrue4 = CheckUtilsByteTests.IsByteTest4();
				Assert.IsFalse(isTrue4);
				log.InfoFormat ("IsByteTest4 = false is {0}", isTrue4);

				// Is true
				var isTrue5 = CheckUtilsByteTests.IsByteTest5();
				Assert.IsTrue(isTrue5);
				log.InfoFormat ("IsByteTest5 = true is {0}", isTrue5);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}

	}
}

