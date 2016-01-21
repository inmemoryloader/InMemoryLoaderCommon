using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;
using System.Collections;

namespace PowerUpConvertUtils
{
	public partial class ConvertUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Strings to hashtable.
		/// </summary>
		/// <returns>The to hashtable.</returns>
		/// <param name="str">String.</param>
		/// <param name="delimit">Delimit.</param>
		public Hashtable StringToHashtable(string paramString, char[] paramDelimit)
		{
			Hashtable ht = new Hashtable();
			int count = 0;
			foreach (string substr in paramString.Split(paramDelimit))
			{
				ht.Add(count++, substr);
			}
			return ht;
		}
	}
}

