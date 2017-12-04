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
        /// <summary>
        /// The year to check.
        /// </summary>
        const int yearToCheck = 2018;

        #region DateTimeUtils.SpecialDays

        /// <summary>
        /// The ostersonntag.
        /// </summary>
        static DateTime ostersonntag = new DateTime(2018, 4, 1);
        /// <summary>
        /// The pfingstsonntag.
        /// </summary>
        static DateTime pfingstsonntag = new DateTime(2018, 5, 20);

        /// <summary>
        /// Gets the easter sunday date test.
        /// </summary>
        /// <returns><c>true</c>, if easter sunday date test was gotten, <c>false</c> otherwise.</returns>
        internal bool GetEasterSundayDateTest()
        {
            object[] paramArg = { yearToCheck };
            var result = (DateTime)ComponentLoader.InvokeMethod(base.DateTimeUtils, "GetEasterSundayDate", paramArg);

            return result.Equals(ostersonntag);
        }

        /// <summary>
        /// Gets the german special days test.
        /// </summary>
        /// <returns><c>true</c>, if german special days test was gotten, <c>false</c> otherwise.</returns>
        internal bool GetGermanSpecialDaysTest()
        {
            object[] paramArg = { yearToCheck };
            var result = (GermanSpecialDays)ComponentLoader.InvokeMethod(base.DateTimeUtils, "GetGermanSpecialDays", paramArg);

            var gsdPfingstsonntag = result.SingleOrDefault(dt => dt.Key.Equals(GermanSpecialDayKey.Pfingstsonntag)).Value;

            return gsdPfingstsonntag.Date.Equals(pfingstsonntag);
        }

        #endregion

        #region DateTimeUtils.IsGermanHoliday

        /// <summary>
        /// Ises the german holiday test.
        /// </summary>
        /// <returns><c>true</c>, if german holiday test was ised, <c>false</c> otherwise.</returns>
        internal bool IsGermanHolidayTest()
        {
            object[] paramArg = { ostersonntag };
            var result = (GermanSpecialDay)ComponentLoader.InvokeMethod(base.DateTimeUtils, "IsGermanHoliday", paramArg);

            if (!result.IsHoliday || !result.IsNationwide)
                return false;
            return true;
        }

        #endregion

        #region DateTimeUtils.CalendarWeek

        /// <summary>
        /// The calendarweek date time.
        /// </summary>
        static DateTime calendarweekDateTime = new DateTime(2018, 12, 8);

        /// <summary>
        /// Gets the calendar week test.
        /// </summary>
        /// <returns><c>true</c>, if calendar week test was gotten, <c>false</c> otherwise.</returns>
        internal bool GetCalendarWeekTest()
        {
            object[] paramArg = { calendarweekDateTime };
            var result = (CalendarWeek)ComponentLoader.InvokeMethod(base.DateTimeUtils, "GetCalendarWeek", paramArg);
            return result.Week.Equals(49);
        }

        /// <summary>
        /// Gets the german calendar week test.
        /// </summary>
        /// <returns><c>true</c>, if german calendar week test was gotten, <c>false</c> otherwise.</returns>
        internal bool GetGermanCalendarWeekTest()
        {
            object[] paramArg = { calendarweekDateTime };
            var result = (CalendarWeek)ComponentLoader.InvokeMethod(base.DateTimeUtils, "GetGermanCalendarWeek", paramArg);
            return result.Week.Equals(49);
        }

        /// <summary>
        /// Gets the german calendar week start date test.
        /// </summary>
        /// <returns><c>true</c>, if german calendar week start date test was gotten, <c>false</c> otherwise.</returns>
        internal bool GetGermanCalendarWeekStartDateTest()
        {
            var weekStartDateTime = new DateTime(2018, 1, 15);
            object[] paramArg = { 3, 2018 };
            var result = ComponentLoader.InvokeMethod(base.DateTimeUtils, "GetGermanCalendarWeekStartDate", paramArg);
            return result.Equals(weekStartDateTime);
        }

        /// <summary>
        /// Gets the calendar week start date test.
        /// </summary>
        /// <returns><c>true</c>, if calendar week start date test was gotten, <c>false</c> otherwise.</returns>
        internal bool GetCalendarWeekStartDateTest()
        {
            var weekStartDateTime = new DateTime(2018, 2, 12);
            object[] paramArg = { 7, 2018 };
            var result = ComponentLoader.InvokeMethod(base.DateTimeUtils, "GetCalendarWeekStartDate", paramArg);
            return result.Equals(weekStartDateTime);
        }

        #endregion

    }

}