//
// TestHelper.PowerUpCheckUtils.cs
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

using System;
using InMemoryLoaderCommon;
using System.Globalization;

namespace InMemoryLoaderCommonNunit
{
    internal partial class TestHelper: AbstractCommonBase
    {
        

        /// <summary>
        /// The is decimal.
        /// </summary>
        private const Decimal isDecimal = 3.12m;
        /// <summary>
        /// The is double.
        /// </summary>
        private const Double isDouble = 3.12;
        /// <summary>
        /// The is float.
        /// </summary>
        private const float isFloat = 1.32f;
        /// <summary>
        /// The is string float.
        /// </summary>
        private const string isStringFloat = "5.687";
        /// <summary>
        /// The is string int.
        /// </summary>
        private const string isStringLong = "521345678";
        /// <summary>
        /// The is string URL.
        /// </summary>
        private const string isStringUrl = "http://www.google.ch/";
        /// <summary>
        /// The is string no URL.
        /// </summary>
        private const string isStringNoUrl = "Some String";
        /// <summary>
        /// The is string int.
        /// </summary>
        private const string isStringInt = "521";
        /// <summary>
        /// The is string.
        /// </summary>
        private const string isString = "Some String";


        #region IsStringIntTest

        /// <summary>
        /// The is int.
        /// </summary>
        private const int isInt = 123;

        /// <summary>
        /// Determines if is string int test1.
        /// </summary>
        /// <returns><c>true</c> if is string int test1; otherwise, <c>false</c>.</returns>
        internal bool IsStringIntTest1()
        {
            object[] paramArg = { isInt };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringInt", paramArg);
            return result;
        }
        /// <summary>
        /// Determines if is string int test2.
        /// </summary>
        /// <returns><c>true</c> if is string int test2; otherwise, <c>false</c>.</returns>
        internal bool IsStringIntTest2()
        {
            object[] paramArg = { isStringInt };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringInt", paramArg);
            return result;
        }
        /// <summary>
        /// Determines if is string int test3.
        /// </summary>
        /// <returns><c>true</c> if is string int test3; otherwise, <c>false</c>.</returns>
        internal bool IsStringIntTest3()
        {
            object[] paramArg = { isStringInt, CultureInfo.CurrentCulture };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringInt", paramArg);
            return result;
        }
        /// <summary>
        /// Determines if is string int test4.
        /// </summary>
        /// <returns><c>true</c> if is string int test4; otherwise, <c>false</c>.</returns>
        internal bool IsStringIntTest4()
        {
            object[] paramArg = { isString, CultureInfo.CurrentCulture };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringInt", paramArg);
            return result == false;
        }

        #endregion

        #region IsStringLongTest

        /// <summary>
        /// The is int.
        /// </summary>
        private const long isLong = 12345678;

        /// <summary>
        /// Determines whether this instance is string long test1.
        /// </summary>
        /// <returns><c>true</c> if this instance is string long test1; otherwise, <c>false</c>.</returns>
        internal bool IsStringLongTest1()
        {
            object[] paramArg = { isLong };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringLong", paramArg);
            return result;
        }
        /// <summary>
        /// Determines whether this instance is string long test2.
        /// </summary>
        /// <returns><c>true</c> if this instance is string long test2; otherwise, <c>false</c>.</returns>
        internal bool IsStringLongTest2()
        {
            object[] paramArg = { isStringInt };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringLong", paramArg);
            return result;
        }
        /// <summary>
        /// Determines whether this instance is string long test3.
        /// </summary>
        /// <returns><c>true</c> if this instance is string long test3; otherwise, <c>false</c>.</returns>
        internal bool IsStringLongTest3()
        {
            object[] paramArg = { isStringInt, CultureInfo.CurrentCulture };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringLong", paramArg);
            return result;
        }
        /// <summary>
        /// Determines whether this instance is string long test4.
        /// </summary>
        /// <returns><c>true</c> if this instance is string long test4; otherwise, <c>false</c>.</returns>
        internal bool IsStringLongTest4()
        {
            object[] paramArg = { isString, CultureInfo.CurrentCulture };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringLong", paramArg);
            return result == false;
        }

        #endregion

        #region IsStringDateTest

        /// <summary>
        /// The is date.
        /// </summary>
        private static DateTime isDate = DateTime.Now;
        /// <summary>
        /// The is string date.
        /// </summary>
        private static string isStringDate = DateTime.Now.ToString();

        /// <summary>
        /// Determines whether this instance is string date test1.
        /// </summary>
        /// <returns><c>true</c> if this instance is string date test1; otherwise, <c>false</c>.</returns>
        internal bool IsStringDateTest1()
        {
            object[] paramArg = { isDate };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringDate", paramArg);
            return result;
        }
        /// <summary>
        /// Determines whether this instance is string date test2.
        /// </summary>
        /// <returns><c>true</c> if this instance is string date test2; otherwise, <c>false</c>.</returns>
        internal bool IsStringDateTest2()
        {
            object[] paramArg = { isStringDate };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringDate", paramArg);
            return result;
        }
        /// <summary>
        /// Determines whether this instance is string date test3.
        /// </summary>
        /// <returns><c>true</c> if this instance is string date test3; otherwise, <c>false</c>.</returns>
        internal bool IsStringDateTest3()
        {
            object[] paramArg = { isStringDate, CultureInfo.CurrentCulture };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringDate", paramArg);
            return result;
        }
        /// <summary>
        /// Determines whether this instance is string date test4.
        /// </summary>
        /// <returns><c>true</c> if this instance is string date test4; otherwise, <c>false</c>.</returns>
        internal bool IsStringDateTest4()
        {
            object[] paramArg = { isString, CultureInfo.CurrentCulture };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringDate", paramArg);
            return result == false;
        }

        #endregion 

        #region IsStringByte

        /// <summary>
        /// The single byte value.
        /// </summary>
        private const byte singleByteVal = 49;

        /// <summary>
        /// Determines whether this instance is string byte1.
        /// </summary>
        /// <returns><c>true</c> if this instance is string byte1; otherwise, <c>false</c>.</returns>
        internal bool IsStringByte1()
        {
            object[] paramArg = { singleByteVal };
            var result = ComponentLoader.InvokeMethod(CheckUtils, "IsStringByte", paramArg);
            return result;
        }

        #endregion

    }

}