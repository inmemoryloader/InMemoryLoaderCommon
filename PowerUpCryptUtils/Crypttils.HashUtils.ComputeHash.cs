using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using log4net;
using InMemoryLoaderBase;

namespace PowerUpCryptUtils
{
	public partial class CryptUtils : AbstractPowerUpComponent, IDisposable
	{
		/// <summary>
		/// Verwaltet das Hash-Objekt
		/// </summary>
		internal static HashAlgorithm hashAlgorithm;

		internal static Encoding stringEncoding;
		/// <summary>
		/// Die Codierung für das Konvertieren von Strings in Byte-Arrays 
		/// und umgekehrt.
		/// </summary>
		/// <remarks>
		/// Es muss sich dabei zwingend um eine 8-Bit-Codierung 
		/// handeln.
		/// </remarks>
		internal static Encoding StringEncoding
		{
			get
			{
				if (stringEncoding == null)
				{
					stringEncoding = Encoding.Default;
				}
				return stringEncoding;
			}
		}

		/// <summary>
		/// Verwaltet die maximale Schlüssel-Länge. Wird im Konstruktor gesetzt.
		/// </summary>
		public int MaxKeyLength
		{
			private set;
			get;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="algorithm"></param>
		private void SetAlgorithm(HashAlgorithmKind algorithm)
		{
			// Algorithmus definieren
			switch (algorithm)
			{
			case HashAlgorithmKind.MD5:
				hashAlgorithm = new MD5CryptoServiceProvider();
				break;

			case HashAlgorithmKind.MD5Cng:
				hashAlgorithm = new MD5Cng();
				break;

			case HashAlgorithmKind.RIPEMD160:
				hashAlgorithm = new RIPEMD160Managed();
				break;

			case HashAlgorithmKind.SHA1:
				hashAlgorithm = new SHA1Managed();
				break;

			case HashAlgorithmKind.SHA1Cng:
				hashAlgorithm = new SHA1Cng();
				break;

			case HashAlgorithmKind.SHA256:
				hashAlgorithm = new SHA256Managed();
				break;

			case HashAlgorithmKind.SHA256Cng:
				hashAlgorithm = new SHA256Cng();
				break;

			case HashAlgorithmKind.SHA384:
				hashAlgorithm = new SHA384Managed();
				break;

			case HashAlgorithmKind.SHA384Cng:
				hashAlgorithm = new SHA384Cng();
				break;

			case HashAlgorithmKind.SHA512:
				hashAlgorithm = new SHA512Managed();
				break;

			case HashAlgorithmKind.SHA512Cng:
				hashAlgorithm = new SHA512Cng();
				break;

			case HashAlgorithmKind.HMACMD5:
				hashAlgorithm = new HMACMD5();
				break;

			case HashAlgorithmKind.HMACRIPEMD160:
				hashAlgorithm = new HMACRIPEMD160();
				break;

			case HashAlgorithmKind.HMACSHA1:
				hashAlgorithm = new HMACSHA1();
				break;

			case HashAlgorithmKind.HMACSHA256:
				hashAlgorithm = new HMACSHA256();
				break;

			case HashAlgorithmKind.HMACSHA384:
				hashAlgorithm = new HMACSHA384();
				break;

			case HashAlgorithmKind.HMACSHA512:
				hashAlgorithm = new HMACSHA512();
				break;

			case HashAlgorithmKind.MACTripleDES:
				hashAlgorithm = new MACTripleDES();
				break;
			}

			// Die Maximallänge des Schlüssels ermitteln
			if (hashAlgorithm is KeyedHashAlgorithm)
			{
				this.MaxKeyLength = ((KeyedHashAlgorithm)hashAlgorithm).Key.Length;
			}
			else
			{
				this.MaxKeyLength = 0;
			}
		}

		/// <summary>
		/// Gibt zurück, ob der aktuell verwendete Algorithmus einen Schlüssel erlaubt
		/// </summary>
		public bool SupportsKey
		{
			get
			{
				return (this.MaxKeyLength > 0);
			}
		}

		/// <summary>
		/// Verwaltet den Schlüssel für Algorithmen, die einen solchen benötigen
		/// </summary>
		public string AlgoKey
		{
			get
			{
				// Überprüfen, ob der Algorithmus einen Schlüssel erlaubt
				if (this.SupportsKey)
				{
					// Schlüssel in einen String umwandeln und zurückgeben
					return StringEncoding.GetString(((KeyedHashAlgorithm)hashAlgorithm).Key);
				}
				else
				{
					throw new NotSupportedException("Der aktuell verwendete " + "Hash-Algorithmus unterstützt keine Schlüssel");
				}
			}
			set
			{
				// Auf Unicode-Zeichen größer 0x00FF überprüfen
				for (int i = 0; i < value.Length; i++)
				{
					if ((int)value[i] > 255)
					{
						throw new CryptographicException("Der übergebene " + "Schlüssel enthält mindestens ein Unicode-Zeichen, " + "das größer ist als 0x00FF (255): " + value[i] + " (" + (int)value[i] + "). Unterstützt werden lediglich " + "8-Bit-Unicode-Zeichen");
					}
				}

				// Überprüfen, ob der Algorithmus einen Schlüssel erlaubt
				if (this.SupportsKey)
				{
					// Schlüssel in ein Byte-Array überführen
					byte[] key = StringEncoding.GetBytes(value);

					// Überprüfen, ob die Schlüssellänge zum Algorithmus passt.
					if (key.Length <= this.MaxKeyLength)
					{
						// Schlüssel setzen
						((KeyedHashAlgorithm)hashAlgorithm).Key = key;
					}
					else
					{
						throw new NotSupportedException("Der übergebene Schlüssel " + "ist mit " + key.Length + " Byte zu groß für den " + "gesetzten Hash-Algorithmus. Dieser unterstützt nur " + "maximal " + this.MaxKeyLength + " Byte große Schlüssel");
					}
				}
				else
				{
					throw new NotSupportedException("Der aktuell verwendete " + "Hash-Algorithmus unterstützt keine Schlüssel");
				}
			}
		}

		/// <summary>
		/// Erzeugt einen Hash aus einem Byte-Array
		/// </summary>
		/// <param name="data">Das Array mit den Daten</param>
		/// <returns>Gibt einen String zurück, der den Hash repräsentiert</returns>
		public string ComputeHashAsString(byte[] data)
		{
			return StringEncoding.GetString(hashAlgorithm.ComputeHash(data));
		}

		/// <summary>
		/// Erzeugt einen Hash aus einem Byte-Array
		/// </summary>
		/// <param name="data">Das Array mit den Daten</param>
		/// <param name="offset">Offset, ab dem das Array gelesen werden soll</param>
		/// <param name="count">Anzahl der zu lesenden Bytes</param>
		/// <returns>Gibt einen String zurück, der den Hash repräsentiert</returns>
		public string ComputeHashAsString(byte[] data, int offset, int count)
		{
			return StringEncoding.GetString(hashAlgorithm.ComputeHash(data, offset, count));
		}

		/// <summary>
		/// Erzeugt einen Hash aus den Daten eines Stream
		/// </summary>
		/// <param name="inputStream">Der Stream mit den Daten</param>
		/// <returns>Gibt einen String zurück, der den Hash repräsentiert</returns>
		public string ComputeHashAsString(Stream inputStream)
		{
			return StringEncoding.GetString(hashAlgorithm.ComputeHash(inputStream));
		}

		/// <summary>
		/// Erzeugt einen Hash für einen String
		/// </summary>
		/// <param name="inputString">Der String</param>
		/// <returns>Gibt einen String zurück, der den Hash repräsentiert</returns>
		public string ComputeHashAsString(string inputString)
		{
			// Byte-Array aus dem String erzeugen und damit den Hashcode erzeugen
			byte[] buffer = Encoding.Default.GetBytes(inputString);

			return StringEncoding.GetString(hashAlgorithm.ComputeHash(buffer));
		}

		public void Dispose()
		{
			try
			{
				this.Dispose();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

