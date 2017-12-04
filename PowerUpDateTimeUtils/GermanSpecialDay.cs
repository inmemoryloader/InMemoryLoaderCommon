//
// GermanSpecialDay.cs
//
// Author: responsive kaysta
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

namespace PowerUpDateTimeUtils
{
	/// <summary>
	/// Verwaltet einen speziellen deutschen Tag
	/// </summary>
	public class GermanSpecialDay : IComparable<GermanSpecialDay>
	{
		/// <summary>
		/// Der Schlüssel des speziellen Tags
		/// </summary>
		public GermanSpecialDayKey Key;

		/// <summary>
		/// Der Name des speziellen Tags
		/// </summary>
		public string Name;

		/// <summary>
		/// Das Datum des speziellen Tags
		/// </summary>
		public DateTime Date;

		/// <summary>
		/// Gibt an, ob der spezielle Tag bundesweit gilt
		/// </summary>
		public bool IsNationwide;

		/// <summary>
		/// Gibt an, ob es sich bei dem speziellen Tag
		/// um einen Feiertag handelt
		/// </summary>
		public bool IsHoliday;

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="paramKey">Der Schlüssel des speziellen Tags</param>
		/// <param name="paramName">Der Name des speziellen Tags</param>
		/// <param name="paramDate">Das Datum des speziellen Tags</param>
		/// <param name="paramIsNationwide">Gibt an, ob der spezielle Tag bundesweit gilt</param>
		/// <param name="paramIsHoliday">Gibt an, ob es sich bei dem speziellen Tag um einen Feiertag handelt</param>
		public GermanSpecialDay(GermanSpecialDayKey paramKey, string paramName, DateTime paramDate, bool paramIsNationwide, bool paramIsHoliday)
		{
			Key = paramKey;
			Name = paramName;
			Date = paramDate;
			IsNationwide = paramIsNationwide;
			IsHoliday = paramIsHoliday;
		}

		/// <summary>
		/// Vergleicht ein GermanSpecialDay-Objekt mit dem aktuellen
		/// </summary>
		/// <param name="otherSpecialDay">Das andere GermanSpecialDay-Objekt</param>
		public int CompareTo(GermanSpecialDay otherSpecialDay)
		{
			return Date.CompareTo(otherSpecialDay.Date);
		}

	}

}