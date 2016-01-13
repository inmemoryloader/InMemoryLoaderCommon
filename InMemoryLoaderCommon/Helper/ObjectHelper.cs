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
		public static object GetFieldValue (string fieldName, object paramObject)
		{
			var value = paramObject.GetType ().GetField (fieldName).GetValue (paramObject);
			return value;
		}

		/// <summary>
		/// Gets the property value.
		/// </summary>
		/// <returns>The property value.</returns>
		/// <param name="filedName">Filed name.</param>
		/// <param name="paramObject">Parameter object.</param>
		public static object GetPropertyValue (string propertyName, object paramObject)
		{
			var value = paramObject.GetType ().GetProperty (propertyName).GetValue (paramObject);
			return value;
		}
	}
}

