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

namespace InMemoryLoaderCommonNunit
{
    /// <summary>
    /// In memory loader common nunit.
    /// </summary>
    [TestFixture ()]
    internal partial class InMemoryLoaderCommonNunit
    {
        /// <summary>
        /// Gets the console culture.
        /// </summary>
        /// <value>The console culture.</value>
        internal string ConsoleCulture { get { return ConfigurationManager.AppSettings ["ConsoleCulture"].ToString (); } }

        /// <summary>
        /// Gets the application key.
        /// </summary>
        /// <value>The application key.</value>
        internal string ApplicationKey { get { return ConfigurationManager.AppSettings ["ApplicationKey"].ToString (); } }

        /// <summary>
        /// The path.
        /// </summary>
        static string path = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Tests the abstract loader base.
        /// </summary>
        [Test ()]
        public void TestCase_AbstractCommonBase ()
        {
            var testHelper = new TestHelper (ConsoleCulture, path, false);

            Assert.IsTrue (testHelper.IsAssemblyPathSet ());
            Assert.IsTrue (testHelper.IsCultureSet ());
            Assert.IsTrue (testHelper.IsInMemoryLoaderSet ());
            Assert.IsTrue (testHelper.IsRegistrySet ());
            Assert.IsTrue (testHelper.IsInMemoryLoaderCommonSet ());
            Assert.IsTrue (testHelper.CommonUtilsSet ());
        }

        /// <summary>
        /// Tests the case power up check utils.
        /// </summary>
        [Test ()]
        public void TestCase_PowerUpCheckUtilsInt ()
        {
            var testHelper = new TestHelper (ConsoleCulture, path, true);

            Assert.IsTrue (testHelper.IsStringIntTest1 ());
            Assert.IsTrue (testHelper.IsStringIntTest2 ());
            Assert.IsTrue (testHelper.IsStringIntTest3 ());
            Assert.IsTrue (testHelper.IsStringIntTest4 ());
        }

        /// <summary>
        /// Tests the case power up check utils long.
        /// </summary>
        [Test ()]
        public void TestCase_PowerUpCheckUtilsLong ()
        {
            var testHelper = new TestHelper (ConsoleCulture, path, true);

            Assert.IsTrue (testHelper.IsStringLongTest1 ());
            Assert.IsTrue (testHelper.IsStringLongTest2 ());
            Assert.IsTrue (testHelper.IsStringLongTest3 ());
            Assert.IsTrue (testHelper.IsStringLongTest4 ());
        }

        /// <summary>
        /// Tests the case power up check utils date.
        /// </summary>
        [Test ()]
        public void TestCase_PowerUpCheckUtilsDate ()
        {
            var testHelper = new TestHelper (ConsoleCulture, path, true);

            Assert.IsTrue (testHelper.IsStringDateTest1 ());
            Assert.IsTrue (testHelper.IsStringDateTest2 ());
            Assert.IsTrue (testHelper.IsStringDateTest3 ());
            Assert.IsTrue (testHelper.IsStringDateTest4 ());
        }

        /// <summary>
        /// Tests the case power up check utils byte.
        /// </summary>
        [Test ()]
        public void TestCase_PowerUpCheckUtilsByte ()
        {
            var testHelper = new TestHelper (ConsoleCulture, path, true);
            Assert.IsTrue (testHelper.IsStringByte1 ());
        }

        /// <summary>
        /// Tests the case get easter sunday date test.
        /// </summary>
        [Test ()]
        public void TestCase_GetEasterSundayDateTest ()
        {
            var testHelper = new TestHelper (ConsoleCulture, path, true);
            Assert.IsTrue (testHelper.GetEasterSundayDateTest ());
        }

        /// <summary>
        /// Tests the case get german special days test.
        /// </summary>
        [Test ()]
        public void TestCase_GetGermanSpecialDaysTest ()
        {
            var testHelper = new TestHelper (ConsoleCulture, path, true);
            Assert.IsTrue (testHelper.GetGermanSpecialDaysTest ());
        }

    }

}