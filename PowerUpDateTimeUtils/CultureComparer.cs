using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Globalization;

namespace PowerUpDateTimeUtils
{
	/// <summary>
	/// Vergleichsklasse für Kulturen
	/// </summary>
	internal class CultureComparer : IComparer
	{
		/// <summary>
		/// Vergleicht die Namen zweier Kulturen
		/// </summary>
		public int Compare(object x, object y)
		{
			CultureInfo ci1 = (CultureInfo)x;
			CultureInfo ci2 = (CultureInfo)y;
			return ci1.Name.CompareTo(ci2.Name);
		}
	}
}

