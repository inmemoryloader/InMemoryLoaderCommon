using System;

namespace InMemoryLoaderCommon
{
	public class ObjectHelper
	{
		/// <summary>
		/// Returns the Value
		/// </summary>
		/// <returns>The field value.</returns>
		/// <param name="filedName">Filed name.</param>
		/// <param name="paramObject">Parameter object.</param>
		public static object GetFieldValue(string filedName, object paramObject)
		{
			var value = paramObject.GetType ().GetField (filedName).GetValue (paramObject);
			return value;
		}

	}
}

