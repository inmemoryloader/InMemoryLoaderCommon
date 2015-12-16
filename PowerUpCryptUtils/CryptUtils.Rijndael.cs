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
		/// The crypt pass phrase.
		/// </summary>
		private static string cryptPassPhrase = "Pas5pr@se";
		/// <summary>
		/// Crypts the pass phrase.
		/// </summary>
		/// <returns>The pass phrase.</returns>
		/// <param name="paramPhrase">Parameter phrase.</param>
		public string CryptPassPhrase (string paramPhrase)
		{
			if (string.IsNullOrEmpty (paramPhrase)) {
				return cryptPassPhrase;
			} else {
				cryptPassPhrase = paramPhrase;
				return cryptPassPhrase;
			}
		}

		/// <summary>
		/// The crypt salt value.
		/// </summary>
		private static string cryptSaltValue = "s@1tValue";
		/// <summary>
		/// Crypts the salt value.
		/// </summary>
		/// <returns>The salt value.</returns>
		/// <param name="paramSalt">Parameter salt.</param>
		public string CryptSaltValue (string paramSalt)
		{
			if (string.IsNullOrEmpty (paramSalt)) {
				return cryptSaltValue;
			} else {
				cryptSaltValue = paramSalt;
				return cryptSaltValue;
			}
		}

		/// <summary>
		/// The crypt hash algorithm.
		/// </summary>
		private static string cryptHashAlgorithm = "SHA1";
		/// <summary>
		/// Crypts the hash algorithm.
		/// </summary>
		/// <returns>The hash algorithm.</returns>
		/// <param name="paramHash">Parameter hash.</param>
		public string CryptHashAlgorithm (string paramHash)
		{
			if (string.IsNullOrEmpty (paramHash)) {
				return cryptHashAlgorithm;
			} else {
				cryptHashAlgorithm = paramHash;
				return cryptHashAlgorithm;
			}
		}

		/// <summary>
		/// The crypt password iterations.
		/// </summary>
		private static int cryptPasswordIterations = 2;
		/// <summary>
		/// Crypts the password iterations.
		/// </summary>
		/// <returns>The password iterations.</returns>
		/// <param name="paramIteration">Parameter iteration.</param>
		public int CryptPasswordIterations (int paramIteration)
		{
			if (paramIteration == 0) {
				return cryptPasswordIterations;
			} else {
				cryptPasswordIterations = paramIteration;
				return cryptPasswordIterations;
			}
		}

		/// <summary>
		/// The crypt init vector.
		/// </summary>
		private static string cryptInitVector = "@1B2c3D4e5F6g7H8";
		/// <summary>
		/// Crypts the init vector.
		/// </summary>
		/// <returns>The init vector.</returns>
		/// <param name="paramVector">Parameter vector.</param>
		public string CryptInitVector (string paramVector)
		{
			if (string.IsNullOrEmpty (paramVector)) {
				return cryptInitVector;
			} else {
				cryptInitVector = paramVector;
				return cryptInitVector;
			}
		}

		/// <summary>
		/// The size of the crypt key.
		/// </summary>
		private static int cryptKeySize = 256;
		/// <summary>
		/// Crypts the size of the key.
		/// </summary>
		/// <returns>The key size.</returns>
		/// <param name="paramKeySize">Parameter key size.</param>
		public int CryptKeySize(int paramKeySize) {
			if (paramKeySize == 0) {
				return cryptKeySize;
			} else {
				cryptKeySize = paramKeySize;
				return cryptKeySize;
			}
		}

		/// <summary>
		/// Encrypts specified plaintext using Rijndael symmetric key algorithm
		/// and returns a base64-encoded result. Source: http://www.obviex.com/samples/Encryption.aspx
		/// </summary>
		/// <param name="plainText">
		/// Plaintext value to be encrypted.
		/// </param>
		/// <returns>
		/// Encrypted value formatted as a base64-encoded string.
		/// </returns>
		public string Encrypt (string paramValue)
		{
			// Convert strings into byte arrays.
			// Let us assume that strings only contain ASCII codes.
			// If strings include Unicode characters, use Unicode, UTF7, or UTF8 
			// encoding.
			byte[] initVectorBytes = Encoding.ASCII.GetBytes (cryptInitVector);
			byte[] saltValueBytes = Encoding.ASCII.GetBytes (cryptSaltValue);

			// Convert our plaintext into a byte array.
			// Let us assume that plaintext contains UTF8-encoded characters.
			byte[] plainTextBytes = Encoding.UTF8.GetBytes (paramValue);

			// First, we must create a password, from which the key will be derived.
			// This password will be generated from the specified passphrase and 
			// salt value. The password will be created using the specified hash 
			// algorithm. Password creation can be done in several iterations.
			PasswordDeriveBytes password = new PasswordDeriveBytes (cryptPassPhrase, saltValueBytes, cryptHashAlgorithm, cryptPasswordIterations);

			// Use the password to generate pseudo-random bytes for the encryption
			// key. Specify the size of the key in bytes (instead of bits).
			byte[] keyBytes = password.GetBytes (cryptKeySize / 8);

			// Create uninitialized Rijndael encryption object.
			RijndaelManaged symmetricKey = new RijndaelManaged ();

			// It is reasonable to set encryption mode to Cipher Block Chaining
			// (CBC). Use default options for other symmetric key parameters.
			symmetricKey.Mode = CipherMode.CBC;

			// Generate encryptor from the existing key bytes and initialization 
			// vector. Key size will be defined based on the number of the key 
			// bytes.
			ICryptoTransform encryptor = symmetricKey.CreateEncryptor (keyBytes, initVectorBytes);

			// Define memory stream which will be used to hold encrypted data.
			MemoryStream memoryStream = new MemoryStream ();

			// Define cryptographic stream (always use Write mode for encryption).
			CryptoStream cryptoStream = new CryptoStream (memoryStream, encryptor, CryptoStreamMode.Write);
			// Start encrypting.
			cryptoStream.Write (plainTextBytes, 0, plainTextBytes.Length);

			// Finish encrypting.
			cryptoStream.FlushFinalBlock ();

			// Convert our encrypted data from a memory stream into a byte array.
			byte[] cipherTextBytes = memoryStream.ToArray ();

			// Close both streams.
			memoryStream.Close ();
			cryptoStream.Close ();

			// Convert encrypted data into a base64-encoded string.
			string cipherText = Convert.ToBase64String (cipherTextBytes);

			// Return encrypted string.
			return cipherText;
		}

		/// <summary>
		/// Decrypts specified ciphertext using Rijndael symmetric key algorithm.
		/// </summary>
		/// <param name="cipherText">
		/// Base64-formatted ciphertext value.
		/// </param>
		/// <returns>
		/// Decrypted string value.
		/// </returns>
		/// <remarks>
		/// Most of the logic in this function is similar to the Encrypt
		/// logic. In order for decryption to work, all parameters of this function
		/// - except cipherText value - must match the corresponding parameters of
		/// the Encrypt function which was called to generate the
		/// ciphertext.
		/// </remarks>
		public string Decrypt (string paramValue)
		{
			// Convert strings defining encryption key characteristics into byte
			// arrays. Let us assume that strings only contain ASCII codes.
			// If strings include Unicode characters, use Unicode, UTF7, or UTF8
			// encoding.
			byte[] initVectorBytes = Encoding.ASCII.GetBytes (cryptInitVector);
			byte[] saltValueBytes = Encoding.ASCII.GetBytes (cryptSaltValue);

			// Convert our ciphertext into a byte array.
			byte[] cipherTextBytes = Convert.FromBase64String (paramValue);

			// First, we must create a password, from which the key will be 
			// derived. This password will be generated from the specified 
			// passphrase and salt value. The password will be created using
			// the specified hash algorithm. Password creation can be done in
			// several iterations.
			PasswordDeriveBytes password = new PasswordDeriveBytes (cryptPassPhrase, saltValueBytes, cryptHashAlgorithm, cryptPasswordIterations);

			// Use the password to generate pseudo-random bytes for the encryption
			// key. Specify the size of the key in bytes (instead of bits).
			byte[] keyBytes = password.GetBytes (cryptKeySize / 8);

			// Create uninitialized Rijndael encryption object.
			RijndaelManaged symmetricKey = new RijndaelManaged ();

			// It is reasonable to set encryption mode to Cipher Block Chaining
			// (CBC). Use default options for other symmetric key parameters.
			symmetricKey.Mode = CipherMode.CBC;

			// Generate decryptor from the existing key bytes and initialization 
			// vector. Key size will be defined based on the number of the key 
			// bytes.
			ICryptoTransform decryptor = symmetricKey.CreateDecryptor (keyBytes, initVectorBytes);

			// Define memory stream which will be used to hold encrypted data.
			MemoryStream memoryStream = new MemoryStream (cipherTextBytes);

			// Define cryptographic stream (always use Read mode for encryption).
			CryptoStream cryptoStream = new CryptoStream (memoryStream, decryptor, CryptoStreamMode.Read);

			// Since at this point we don't know what the size of decrypted data
			// will be, allocate the buffer long enough to hold ciphertext;
			// plaintext is never longer than ciphertext.
			byte[] plainTextBytes = new byte[cipherTextBytes.Length];

			// Start decrypting.
			int decryptedByteCount = cryptoStream.Read (plainTextBytes, 0, plainTextBytes.Length);

			// Close both streams.
			memoryStream.Close ();
			cryptoStream.Close ();

			// Convert decrypted data into a string. 
			// Let us assume that the original plaintext string was UTF8-encoded.
			string plainText = Encoding.UTF8.GetString (plainTextBytes, 0, decryptedByteCount);

			// Return decrypted string.   
			return plainText;
		}
	}
}

