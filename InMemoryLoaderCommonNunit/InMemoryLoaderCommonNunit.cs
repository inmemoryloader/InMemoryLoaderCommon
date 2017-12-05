//
// InMemoryLoaderCommonNunit.cs
//
// Author: responsive kaysta <me@responsive-kaysta.ch>
//
// Copyright (c) 2017 responsive kaysta
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using NUnit.Framework;
using System;
using System.Configuration;
using InMemoryLoaderCommonNunit.Application;
using log4net;

namespace InMemoryLoaderCommonNunit
{
    /// <summary>
    /// In memory loader common nunit.
    /// </summary>
    [TestFixture()]
    internal class InMemoryLoaderCommonNunit
    {
        /// <summary>
        /// The log.
        /// </summary>
        static readonly ILog Log = LogManager.GetLogger(typeof(InMemoryLoaderCommonNunit));
        /// <summary>
        /// Gets the console culture.
        /// </summary>
        /// <value>The console culture.</value>
        static readonly string ConsoleCulture = ConfigurationManager.AppSettings["System.ConsoleCulture"];
        /// <summary>
        /// The Path.
        /// </summary>
        static readonly string Path = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// The app base.
        /// </summary>
        static readonly ApplicationBase AppBase = ApplicationBase.Instance;

        [Test()]
        public void TestCase_ApplicationBase()
        {
            var appBaseSet = AppBase.GetType().ToString();
            Log.DebugFormat(AppBase.TestRunMessage, "TestCase_ApplicationBase");

            Assert.IsNotNullOrEmpty(appBaseSet);
        }

        /// <summary>
        /// TestCase_AbstractCommonBase
        /// </summary>
        [Test()]
        public void TestCase_AbstractCommonBase()
        {
            var testHelper = new TestHelper(ConsoleCulture, Path, false);
            Log.DebugFormat(AppBase.TestRunMessage, "TestCase_AbstractCommonBase");

            Assert.IsTrue(testHelper.GetAssemblyPath_Test());
            Assert.IsTrue(testHelper.SetCulture_Test());
            Assert.IsTrue(testHelper.SetInMemoryLoader_Test());
            Assert.IsTrue(testHelper.SetClassRegistry_Test());
            Assert.IsTrue(testHelper.SetInMemoryLoaderCommon_Test());
            Assert.IsTrue(testHelper.CommonUtils_Test());
        }

        /// <summary>
        /// TestCase_PowerUpCheckUtilsByte
        /// </summary>
        [Test()]
        public void TestCase_PowerUpCheckUtilsByte()
        {
            var testHelper = new TestHelper(ConsoleCulture, Path, true);
            Log.DebugFormat(AppBase.TestRunMessage, "TestCase_PowerUpCheckUtilsByte");

            Assert.IsTrue(testHelper.IsStringByte_Test1());
            Assert.IsTrue(testHelper.IsStringByte_Test2());
        }

        /// <summary>
        /// Tests the case power up check utils.
        /// </summary>
        [Test()]
        public void TestCase_PowerUpCheckUtilsInt()
        {
            var testHelper = new TestHelper(ConsoleCulture, Path, true);

            Assert.IsTrue(testHelper.IsStringInt_Test1());
            Assert.IsTrue(testHelper.IsStringInt_Test2());
            Assert.IsTrue(testHelper.IsStringInt_Test3());
            Assert.IsTrue(testHelper.IsStringInt_Test4());
        }

        /// <summary>
        /// Tests the case power up check utils long.
        /// </summary>
        [Test()]
        public void TestCase_PowerUpCheckUtilsLong()
        {
            var testHelper = new TestHelper(ConsoleCulture, Path, true);

            Assert.IsTrue(testHelper.IsStringLong_Test1());
            Assert.IsTrue(testHelper.IsStringLong_Test2());
            Assert.IsTrue(testHelper.IsStringLong_Test3());
            Assert.IsTrue(testHelper.IsStringLong_Test4());
        }

        /// <summary>
        /// Tests the case power up check utils date.
        /// </summary>
        [Test()]
        public void TestCase_PowerUpCheckUtilsDate()
        {
            var testHelper = new TestHelper(ConsoleCulture, Path, true);

            Assert.IsTrue(testHelper.IsStringDate_Test1());
            Assert.IsTrue(testHelper.IsStringDate_Test2());
            Assert.IsTrue(testHelper.IsStringDate_Test3());
            Assert.IsTrue(testHelper.IsStringDate_Test4());
        }

        /// <summary>
        /// Tests the case is URL valid test.
        /// </summary>
        [Test()]
        public void TestCase_IsUrlValidTest()
        {
            var testHelper = new TestHelper(ConsoleCulture, Path, true);
            Assert.IsTrue(testHelper.IsUrlValid_Test1());
        }

        /// <summary>
        /// Tests the case get easter sunday date test.
        /// </summary>
        [Test()]
        public void TestCase_GetEasterSundayDateTest()
        {
            var testHelper = new TestHelper(ConsoleCulture, Path, true);
            Assert.IsTrue(testHelper.GetEasterSundayDateTest());
        }

        /// <summary>
        /// Tests the case get german special days test.
        /// </summary>
        [Test()]
        public void TestCase_GetGermanSpecialDaysTest()
        {
            var testHelper = new TestHelper(ConsoleCulture, Path, true);
            Assert.IsTrue(testHelper.GetGermanSpecialDaysTest());
        }

        /// <summary>
        /// Tests the case is german holiday test.
        /// </summary>
        [Test()]
        public void TestCase_IsGermanHolidayTest()
        {
            var testHelper = new TestHelper(ConsoleCulture, Path, true);
            Assert.IsTrue(testHelper.IsGermanHolidayTest());
        }

        /// <summary>
        /// Tests the case calendar week test.
        /// </summary>
        [Test()]
        public void TestCase_CalendarWeekTest()
        {
            var testHelper = new TestHelper(ConsoleCulture, Path, true);
            Assert.IsTrue(testHelper.GetCalendarWeekTest());
            Assert.IsTrue(testHelper.GetGermanCalendarWeekTest());
            Assert.IsTrue(testHelper.GetGermanCalendarWeekStartDateTest());
            Assert.IsTrue(testHelper.GetCalendarWeekStartDateTest());
        }

        /// <summary>
        /// Tests the case rijndael test.
        /// </summary>
        [Test()]
        public void TestCase_RijndaelTest()
        {
            var testHelper = new TestHelper(ConsoleCulture, Path, true);
            Assert.IsTrue(testHelper.RijndaelTest());
        }

    }

}