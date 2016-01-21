using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Collections;
using log4net;
using InMemoryLoaderBase;

namespace PowerUpCryptUtils
{
	public partial class CryptUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(CryptUtils));

		/// <summary>
		/// Initializes a new instance of the <see cref="PowerUpCryptUtils.CryptUtils"/> class.
		/// </summary>
		public CryptUtils ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
		}

		/// <summary>
		/// Gets the string encoding.
		/// </summary>
		/// <returns>The string encoding.</returns>
		/// <param name="paramNull">If set to <c>true</c> parameter null.</param>
		public Encoding GetStringEncoding (bool paramNull)
		{
			return StringEncoding;
		}
		/// <summary>
		/// Sets the string encoding.
		/// </summary>
		/// <returns>The string encoding.</returns>
		/// <param name="paramEncoding">Parameter encoding.</param>
		public Encoding SetStringEncoding (Encoding paramEncoding)
		{
			StringEncoding = paramEncoding;
			return StringEncoding;
		}
		/// <summary>
		/// Gets the length of the max key.
		/// </summary>
		/// <returns>The max key length.</returns>
		/// <param name="paramNull">If set to <c>true</c> parameter null.</param>
		public int GetMaxKeyLength (bool paramNull)
		{
			return MaxKeyLength;
		}
		/// <summary>
		/// Sets the length of the max key.
		/// </summary>
		/// <returns>The max key length.</returns>
		/// <param name="paramMaxKeyLength">Parameter max key length.</param>
		public int SetMaxKeyLength (int paramMaxKeyLength)
		{
			MaxKeyLength = paramMaxKeyLength;
			return MaxKeyLength;
		}
		/// <summary>
		/// Gets the supports key.
		/// </summary>
		/// <returns><c>true</c>, if supports key was gotten, <c>false</c> otherwise.</returns>
		/// <param name="paramNull">If set to <c>true</c> parameter null.</param>
		public bool GetSupportsKey (bool paramNull)
		{
			return SupportsKey;
		}
		/// <summary>
		/// Gets the algo key.
		/// </summary>
		/// <returns>The algo key.</returns>
		/// <param name="paramNull">If set to <c>true</c> parameter null.</param>
		public string GetAlgoKey (bool paramNull)
		{
			return AlgoKey;
		}
		/// <summary>
		/// Gets the kind of the supported algorithm.
		/// </summary>
		/// <returns>The supported algorithm kind.</returns>
		/// <param name="paramNull">If set to <c>true</c> parameter null.</param>
		public IEnumerable GetSupportedAlgorithmKind (bool paramNull)
		{
			var values = Enum.GetValues(typeof(HashAlgorithmKind));
			return values;
		}
		/// <summary>
		/// Sets the kind of the algorithm.
		/// </summary>
		/// <returns>The algorithm kind.</returns>
		/// <param name="paramAlgorithm">Parameter algorithm.</param>
		public string SetAlgorithmKind (string paramAlgorithm)
		{
			HashAlgorithmKind algorithm;
			string stringAlgorithm;

			if (string.IsNullOrEmpty (paramAlgorithm)) {
				stringAlgorithm = "MD5";
			} else {
				stringAlgorithm = paramAlgorithm.ToUpper ();
			}

			switch (stringAlgorithm) {

			case "MD5":
				algorithm = HashAlgorithmKind.MD5;
				break;

			case "MD5CNG":
				algorithm = HashAlgorithmKind.MD5Cng;
				break;

			case "RIPEMD160":
				algorithm = HashAlgorithmKind.RIPEMD160;
				break;

			case "SHA1":
				algorithm = HashAlgorithmKind.SHA1;
				break;

			case "SHA1CNG":
				algorithm = HashAlgorithmKind.SHA1Cng;
				break;

			case "SHA256":
				algorithm = HashAlgorithmKind.SHA256;
				break;

			case "SHA256CNG":
				algorithm = HashAlgorithmKind.SHA256Cng;
				break;

			case "SHA384":
				algorithm = HashAlgorithmKind.SHA384;
				break;

			case "SHA384CNG":
				algorithm = HashAlgorithmKind.SHA384Cng;
				break;

			case "SHA512":
				algorithm = HashAlgorithmKind.SHA512;
				break;

			case "SHA512CNG":
				algorithm = HashAlgorithmKind.SHA512Cng;
				break;

			case "HMACMD5":
				algorithm = HashAlgorithmKind.HMACMD5;
				break;

			case "HMACRIPEMD160":
				algorithm = HashAlgorithmKind.HMACRIPEMD160;
				break;

			case "HMACSHA1":
				algorithm = HashAlgorithmKind.HMACSHA1;
				break;

			case "HMACSHA256":
				algorithm = HashAlgorithmKind.HMACSHA256;
				break;

			case "HMACSHA384":
				algorithm = HashAlgorithmKind.HMACSHA384;
				break;

			case "HMACSHA512":
				algorithm = HashAlgorithmKind.HMACSHA512;
				break;

			case "MACTRIPLEDES":
				algorithm = HashAlgorithmKind.MACTripleDES;
				break;

			default:
				algorithm = HashAlgorithmKind.MD5;
				break;
			}

			SetAlgorithm (algorithm);

			return stringAlgorithm;
		}
	}
}

