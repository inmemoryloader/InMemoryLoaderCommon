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

		/// <summary>
		/// Checks the utils URL test case.
		/// </summary>
		[Test ()]
		public void CheckUtilsUrlTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CheckUtilsUrlTestCase");

				// Is true
				var isTrue1 = CheckUtilsUrlTests.IsUrlTest1();
				Assert.IsTrue(isTrue1);
				log.InfoFormat ("IsUrlTest1 = true is {0}", isTrue1);

				// Is false
				var isTrue2 = CheckUtilsUrlTests.IsUrlTest2();
				Assert.IsFalse(isTrue2);
				log.InfoFormat ("IsUrlTest2 = true is {0}", isTrue2);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}

		/// <summary>
		/// Checks the utils long test case.
		/// </summary>
		[Test ()]
		public void CheckUtilsLongTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CheckUtilsLongTestCase");

				// Is true
				var isTrue1 = CheckUtilsLongTests.IsLongTest1();
				Assert.IsTrue(isTrue1);
				log.InfoFormat ("IsLongTest1 = true is {0}", isTrue1);

				// Is true
				var isTrue2 = CheckUtilsLongTests.IsLongTest2();
				Assert.IsTrue(isTrue2);
				log.InfoFormat ("IsLongTest2 = true is {0}", isTrue2);

				// Is false
				var isTrue3 = CheckUtilsLongTests.IsLongTest3();
				Assert.IsFalse(isTrue3);
				log.InfoFormat ("IsLongTest3 = true is {0}", isTrue3);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}

		/// <summary>
		/// Checks the utils int test case.
		/// </summary>
		[Test ()]
		public void CheckUtilsIntTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CheckUtilsIntTestCase");

				// Is true
				var isTrue1 = CheckUtilsIntegerTests.IsIntTest1();
				Assert.IsTrue(isTrue1);
				log.InfoFormat ("IsIntTest1 = true is {0}", isTrue1);

				// Is true
				var isTrue2 = CheckUtilsIntegerTests.IsIntTest2();
				Assert.IsTrue(isTrue2);
				log.InfoFormat ("IsIntTest2 = true is {0}", isTrue2);

				// Is true
				var isTrue3 = CheckUtilsIntegerTests.IsIntTest3();
				Assert.IsTrue(isTrue3);
				log.InfoFormat ("IsIntTest3 = true is {0}", isTrue3);

				// Is false
				var isTrue4 = CheckUtilsIntegerTests.IsIntTest4();
				Assert.IsFalse(isTrue4);
				log.InfoFormat ("IsIntTest4 = true is {0}", isTrue4);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString());
			}
		}

		/// <summary>
		/// Checks the utils float test case.
		/// </summary>
		[Test ()]
		public void CheckUtilsFloatTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CheckUtilsFloatTestCase");

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

		/// <summary>
		/// Checks the utils double test case.
		/// </summary>
		[Test ()]
		public void CheckUtilsDoubleTestCase ()
		{
			try {
				log.InfoFormat ("{0}", "CheckUtilsDoubleTestCase");

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

		/// <summary>
		/// Checks the utils decimal test case.
		/// </summary>
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

		/// <summary>
		/// Checks the utils date test case.
		/// </summary>
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

