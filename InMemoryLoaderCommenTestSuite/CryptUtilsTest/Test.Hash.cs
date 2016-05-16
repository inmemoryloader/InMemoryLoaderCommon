using System;
using System.Collections;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace InMemoryLoaderCommenTestSuite.CryptUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// Crypts the hash test.
		/// </summary>
		/// <returns><c>true</c>, if hash test was crypted, <c>false</c> otherwise.</returns>
		public static bool CryptHashTest ()
		{
			bool cryptHashTest = false;

			cryptHashTest = GetSupportedAlgorithmKindTest1 ();
			cryptHashTest = SetAlgorithmKindTest1 ();
			cryptHashTest = ComputeHashAsStringTest1 ();

			return cryptHashTest;
		}

		/// <summary>
		/// Gets the supported algorithm kind test1.
		/// </summary>
		/// <returns><c>true</c>, if supported algorithm kind test1 was gotten, <c>false</c> otherwise.</returns>
		private static bool GetSupportedAlgorithmKindTest1 ()
		{
			try {
				bool isTrue = false;

				object[] paramEncrypt = { true };
				var supportedAlgorithmKind = (IEnumerable)appBase.ComponentLoader.InvokeMethod (cryptUtils, "GetSupportedAlgorithmKind", paramEncrypt);

				if (supportedAlgorithmKind != null) {
					isTrue = true;
				}

				log.DebugFormat ("GetSupportedAlgorithmKind (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Sets the algorithm kind test1.
		/// </summary>
		/// <returns><c>true</c>, if algorithm kind test1 was set, <c>false</c> otherwise.</returns>
		private static bool SetAlgorithmKindTest1 ()
		{
			try {
				bool isTrue = false;
				string paramKind = "SHA1";

				object[] paramEncrypt = { paramKind };
				var setAlgorithmKind = (string)appBase.ComponentLoader.InvokeMethod (cryptUtils, "SetAlgorithmKind", paramEncrypt);

				if (setAlgorithmKind.Equals("SHA1")) {
					isTrue = true;
				}

				log.DebugFormat ("SetAlgorithmKind (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Computes the hash as string test1.
		/// </summary>
		/// <returns><c>true</c>, if hash as string test1 was computed, <c>false</c> otherwise.</returns>
		private static bool ComputeHashAsStringTest1 ()
		{
			try {
				bool isTrue = false;
				string paramAlgoKind = "SHA1";
				string paramToEncrypt = "Some splendid Text";
				string paramEncrypted = "]0\n\u00a0»Zì‰”¥mê‰\u001cQUÄï\u008fÅ";

				object[] paramKind = { paramAlgoKind };
				var setAlgorithmKind = (string)appBase.ComponentLoader.InvokeMethod (cryptUtils, "SetAlgorithmKind", paramKind);

				log.DebugFormat ("SetAlgorithmKind = {0}", setAlgorithmKind);

				object[] paramEncrypt = { paramToEncrypt };
				var hashString = (string)appBase.ComponentLoader.InvokeMethod (cryptUtils, "ComputeHashAsString", paramEncrypt);

				if (hashString.Equals(paramEncrypted)) {
					isTrue = true;
				}

				log.DebugFormat ("ComputeHashAsString (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}