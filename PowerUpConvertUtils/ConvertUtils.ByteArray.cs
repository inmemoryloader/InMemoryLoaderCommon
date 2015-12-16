using System;
using log4net;
using PowerUpBase;
using System.Globalization;
using System.IO;
using System.Text;

namespace PowerUpConvertUtils
{
	public partial class ConvertUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Strings to byte array.
		/// </summary>
		/// <returns>The to byte array.</returns>
		/// <param name="str">String.</param>
		public byte[] StringToByteArray(string str)
		{
			MemoryStream ms = new MemoryStream();
			BinaryWriter br = new BinaryWriter(ms);
			br.Write(str);
			byte[] byteReturn = ms.ToArray();
			return byteReturn;
		}
		/// <summary>
		/// Strings to byte array.
		/// </summary>
		/// <returns>The to byte array.</returns>
		/// <param name="str">String.</param>
		/// <param name="encoding">Encoding.</param>
		public byte[] StringToByteArray(string str, Encoding encoding)
		{
			MemoryStream ms = new MemoryStream();
			BinaryWriter br = new BinaryWriter(ms, encoding);
			br.Write(str);
			byte[] byteReturn = ms.ToArray();
			return byteReturn;
		}
		/// <summary>
		/// Files the content to byte array.
		/// </summary>
		/// <returns>The content to byte array.</returns>
		/// <param name="file">File.</param>
		public byte[] FileContentToByteArray(string file)
		{
			byte[] buff = null;
			FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
			BinaryReader br = new BinaryReader(fs);
			long numBytes = new FileInfo(file).Length;
			buff = br.ReadBytes((int)numBytes);
			return buff;
		}
	}
}

