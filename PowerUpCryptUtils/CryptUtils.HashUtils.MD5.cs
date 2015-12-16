using System;
using log4net;
using PowerUpBase;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PowerUpCryptUtils
{
	public partial class CryptUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// Encrypts the string to a byte array using the MD5 Encryption Algorithm.
		/// <see cref="System.Security.Cryptography.MD5CryptoServiceProvider"/>
		/// </summary>
		/// <param name="ToEncrypt">System.String.  Usually a password.</param>
		/// <returns>System.Byte[]</returns>
		public byte[] MD5Encryption(string paramValue)
		{
			// Create instance of the crypto provider.
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			// Create a Byte array to store the encryption to return.
			byte[] hashedbytes;
			// Required UTF8 Encoding used to encode the input value to a usable state.
			UTF8Encoding textencoder = new UTF8Encoding();

			// let the show begin.
			hashedbytes = md5.ComputeHash(textencoder.GetBytes(paramValue));

			// Destroy objects that aren't needed.
			md5.Clear();
			md5 = null;

			// return the hased bytes to the calling method.
			return hashedbytes;
		}

		/// <summary>
		/// Encrypts the string to a byte array using the MD5 Encryption 
		/// Algorithm with an additional Salted Hash.
		/// <see cref="System.Security.Cryptography.MD5CryptoServiceProvider"/>
		/// </summary>
		/// <param name="ToEncrypt">System.String.  Usually a password.</param>
		/// <returns>System.Byte[]</returns>
		public byte[] MD5SaltedHashEncryption(string paramValue)
		{
			// Create instance of the crypto provider.
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			// Create a Byte array to store the encryption to return.
			byte[] hashedbytes;
			// Create a Byte array to store the salted hash.
			byte[] saltedhash;

			// Required UTF8 Encoding used to encode the input value to a usable state.
			UTF8Encoding textencoder = new UTF8Encoding();

			// let the show begin.
			hashedbytes = md5.ComputeHash(textencoder.GetBytes(paramValue));

			// Let's add the salt.
			paramValue += textencoder.GetString(hashedbytes);
			// Get the new byte array after adding the salt.
			saltedhash = md5.ComputeHash(textencoder.GetBytes(paramValue));

			// Destroy objects that aren't needed.
			md5.Clear();
			md5 = null;

			// return the hased bytes to the calling method.
			return saltedhash;
		}
		/// <summary>
		/// Gets the M d5 hash as string.
		/// </summary>
		/// <returns>The M d5 hash as string.</returns>
		/// <param name="text">Text.</param>
		public string GetMD5HashAsString(string text)
		{
			System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
			byte[] hash = md5.ComputeHash(bytes);
			string result = BitConverter.ToString(hash);
			return result;
		}
	}
}

