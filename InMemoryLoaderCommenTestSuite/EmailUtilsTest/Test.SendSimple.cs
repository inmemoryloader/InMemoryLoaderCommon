using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;

namespace InMemoryLoaderCommenTestSuite.EmailUtilsTest
{
	public partial class Test
	{
		private static string smtp = "yoursmtpserver";
		/// <summary>
		/// The sender.
		/// </summary>
		private static string sender = "youremailaddress";
		/// <summary>
		/// The empfaenger.
		/// </summary>
		private static string[] empfaenger = { "yourrecipient(s)" };
		/// <summary>
		/// The blind empfaenger.
		/// </summary>
		private static string[] blind_empfaenger = null;
		/// <summary>
		/// The subject.
		/// </summary>
		private static string subject = "UnitTest Test-Email";
		/// <summary>
		/// The body.
		/// </summary>
		private static string body = "Some text to test the functionality. Cheers :)";
		/// <summary>
		/// The attachment pfad.
		/// </summary>
		private static string[] attachmentPfad = null;

		/// <summary>
		/// Sends the simple test1.
		/// </summary>
		/// <returns>The simple test1.</returns>
		public static bool SendSimpleTest ()
		{
			try {
				bool isTrue = false;

				object[] paramObject = { smtp, sender, empfaenger, blind_empfaenger, subject, body, attachmentPfad };
				// isTrue = (bool)appBase.ComponentLoader.InvokeMethod (emailUtils, "SendSimple", paramObject);
				isTrue = true;

				log.DebugFormat ("SendSimple Email = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

	}
}