using NUnit.Framework;
using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace InMemoryLoaderCommonUnitTest
{
	[TestFixture ()]
	public class XmlUtilsTest
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(XmlUtilsTest));

		/// <summary>
		/// Xmls the utils test case1.
		/// </summary>
		[Test ()]
		public void XmlUtilsTestCase1 ()
		{
			try {
				log.InfoFormat ("{0}", "XmlUtilsTestCase1");

				// Step 1 - create a XmlDocument and the Type
				var xmlDocument = (XmlDocument)XmlUtilsTests.XmlUtilsTest1 ();
				var xmlDocumentType = xmlDocument.GetType ();
				bool isXmlDocumentType = false;
				if (xmlDocumentType == typeof(XmlDocument)) {
					isXmlDocumentType = true;
				}
				Assert.IsTrue (isXmlDocumentType);
				log.InfoFormat ("isXmlDocumentType is true = {0}", isXmlDocumentType);

				// Step 2 - Write XmlDocument to file
				var writeFile = (bool)XmlUtilsTests.XmlUtilsTest2 (xmlDocument);
				Assert.IsTrue (writeFile);
				log.InfoFormat ("isXmlDocumentType write and delete true = {0}", isXmlDocumentType);

			} catch (Exception ex) {
				log.FatalFormat (ex.ToString ());
			}
		}



	}
}

