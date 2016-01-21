using System;
using log4net;
using InMemoryLoaderBase;
using System.Globalization;
using System.IO;
using System.Text;

namespace PowerUpConvertUtils
{
	public partial class ConvertUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Memories the stream to string.
		/// </summary>
		/// <returns>The stream to string.</returns>
		/// <param name="parmStream">Parm stream.</param>
		public string MemoryStreamToString(MemoryStream parmStream)
		{
			StreamReader reader = new StreamReader(parmStream);
			string text = reader.ReadToEnd();
			return text;
		}
		/// <summary>
		/// Bytes the array to string.
		/// </summary>
		/// <returns>The array to string.</returns>
		/// <param name="bytearray">Bytearray.</param>
		public string ByteArrayToString(byte[] paramByteArray)
		{
			MemoryStream stream = new MemoryStream(paramByteArray);
			StreamReader reader = new StreamReader(stream, true);
			StringBuilder sb = new StringBuilder(reader.ReadToEnd(), reader.ReadToEnd().Length);
			return sb.ToString();
		}
		/// <summary>
		/// Bytes the array to string.
		/// </summary>
		/// <returns>The array to string.</returns>
		/// <param name="bytearray">Bytearray.</param>
		/// <param name="encoding">Encoding.</param>
		public string ByteArrayToString(byte[] paramByteArray, Encoding paramEncoding)
		{
			MemoryStream stream = new MemoryStream(paramByteArray);
			StreamReader reader = new StreamReader(stream, paramEncoding);
			StringBuilder sb = new StringBuilder(reader.ReadToEnd(), reader.ReadToEnd().Length);
			return sb.ToString();
		}
	}
}

