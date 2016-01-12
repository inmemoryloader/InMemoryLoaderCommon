using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;

namespace InMemoryLoaderCommonUnitTest
{
	public class EmailUtilsTests
	{
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The crypt utils.
		/// </summary>
		private static IDynamicClassSetup emailUtils = appBase.CommonComponentLoader.EmailComponent;
		/// <summary>
		/// The smtp.
		/// </summary>
		private static string smtp = "yoursmtpserver";
		/// <summary>
		/// The sender.
		/// </summary>
		private static string sender = "youremailddress";
		/// <summary>
		/// The empfaenger.
		/// </summary>
		private static string[] empfaenger = { "recipient" };
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
		public static object SendSimpleTest1 ()
		{
			try {
				object[] paramObject = { smtp, sender, empfaenger, blind_empfaenger, subject, body, attachmentPfad };

				var emailSent = appBase.ComponentLoader.InvokeMethod (emailUtils.Assembly, emailUtils.Class, "SendSimple", paramObject);

				return emailSent;
			} catch (Exception ex) {
				throw ex;
			}		
		}

	}
}

