using System;
using log4net;
using InMemoryLoaderBase;
using System.IO;

namespace PowerUpFileSystemUtils
{
	public partial class FileSystemUtils : AbstractComponent
	{
		/// <summary>
		/// Creates the content of the binary file.
		/// </summary>
		/// <param name="fileName">File name.</param>
		/// <param name="fileContent">File content.</param>
		public void CreateBinaryFileContent(string fileName, byte[] fileContent)
		{
			try
			{
				//System.IO.FileStream fileStream = new FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
				//System.IO.BinaryWriter binWriter = new System.IO.BinaryWriter(fileStream, Encoding.Default);
				//binWriter.Write(fileContent, 0, fileContent.Length);
				//binWriter.Close();
				using (Stream s = new FileStream(fileName, FileMode.Create))
				{
					foreach (byte item in fileContent)
					{
						s.WriteByte(Convert.ToByte(item));
					}
					s.Close();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

