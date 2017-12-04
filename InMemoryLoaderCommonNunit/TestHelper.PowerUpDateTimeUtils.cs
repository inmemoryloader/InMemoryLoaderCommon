//
// TestHelper.PowerUpDateTimeUtils.cs
//
// Author: responsive kaysta <>
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
using System.Linq;
using InMemoryLoaderCommon;
using PowerUpDateTimeUtils;

namespace InMemoryLoaderCommonNunit
{
    internal partial class TestHelper : AbstractCommonBase
    {
        #region SpecialDays

        const int yearToCheck = 2018;
        static DateTime ostersonntag = new DateTime (2018, 4, 1);
        static DateTime pfingstsonntag = new DateTime (2018, 5, 20);

        /// <summary>
        /// Gets the easter sunday date test.
        /// </summary>
        /// <returns><c>true</c>, if easter sunday date test was gotten, <c>false</c> otherwise.</returns>
        internal bool GetEasterSundayDateTest ()
        {
            object [] paramArg = { yearToCheck };
            var result = (DateTime)ComponentLoader.InvokeMethod (base.DateTimeUtils, "GetEasterSundayDate", paramArg);

            if (result.Equals (ostersonntag)) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Gets the german special days test.
        /// </summary>
        /// <returns><c>true</c>, if german special days test was gotten, <c>false</c> otherwise.</returns>
        internal bool GetGermanSpecialDaysTest ()
        {
            object [] paramArg = { yearToCheck };
            var result = (GermanSpecialDays)ComponentLoader.InvokeMethod (base.DateTimeUtils, "GetGermanSpecialDays", paramArg);

            var gsdPfingstsonntag = result.Where (dt => dt.Key.Equals(GermanSpecialDayKey.Pfingstsonntag)).SingleOrDefault().Value;

            if (gsdPfingstsonntag.Date.Equals (pfingstsonntag)) {
                return true;
            } else {
                return false;
            }
        }

        #endregion

        // IsGermanHoliday
    }
}
