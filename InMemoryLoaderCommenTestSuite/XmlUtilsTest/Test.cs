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

namespace InMemoryLoaderCommenTestSuite.XmlUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(InMemoryLoaderCommenTestSuite.StringUtilsTest.Test));
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The date time utils.
		/// </summary>
		private static IDynamicClassInfo xmlUtils = 
			appBase.ComponentLoader.ComponentRegistry.Where (utl => utl.Key.Class.Contains ("XmlUtils")).SingleOrDefault ().Value;

		/// <summary>
		/// The xml folder path.
		/// </summary>
		private static string xmlFolderPath = "/home/kaysta/github.com/InMemoryLoaderCommon/InMemoryLoaderCommenTestSuite/XmlUtilsTest/";
		/// <summary>
		/// The xml file to write.
		/// </summary>
		private static string xmlFileToWrite = "TestXmlFileToWrite.xml";

		/// <summary>
		/// Xml document to write.
		/// </summary>
		public class XmlDocToWrite
		{
			public string MyProperty;
			public string MyOtherProperty;
			public string AnotherProperty;
		}

		/// <summary>
		/// Xmls the utils test.
		/// </summary>
		/// <returns><c>true</c>, if utils test was xmled, <c>false</c> otherwise.</returns>
		public static bool XmlUtilsTest ()
		{
			bool xmlUtilsTest = false;

			xmlUtilsTest = SerializeToXmlDocumentTest ();
			xmlUtilsTest = WriteXmlFileTest ();

			return xmlUtilsTest;
		}

		/// <summary>
		/// Serializes to xml document test.
		/// </summary>
		/// <returns><c>true</c>, if to xml document test was serialized, <c>false</c> otherwise.</returns>
		private static bool SerializeToXmlDocumentTest ()
		{
			try {
				bool isTrue = false;

				var xmlDocToWrite = new XmlDocToWrite ();
				xmlDocToWrite.MyProperty = "MyProperty";
				xmlDocToWrite.MyOtherProperty = "MyOtherProperty";
				xmlDocToWrite.AnotherProperty = "AnotherProperty";

				object[] paramObject = { xmlDocToWrite as object };
				var getXmlDocument = (XmlDocument)appBase.ComponentLoader.InvokeMethod (xmlUtils, "SerializeToXmlDocument", paramObject);

				if (getXmlDocument.GetType() == typeof(XmlDocument)) {
					isTrue = true;
				}

				log.DebugFormat ("Is XmlDocumentType is true = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Writes the xml file test.
		/// </summary>
		/// <returns><c>true</c>, if xml file test was writed, <c>false</c> otherwise.</returns>
		private static bool WriteXmlFileTest ()
		{
			try {
				var fileToWrite = Path.Combine(xmlFolderPath, xmlFileToWrite);
				bool isTrue = false;

				var xmlDocToWrite = new XmlDocToWrite ();
				xmlDocToWrite.MyProperty = "MyProperty";
				xmlDocToWrite.MyOtherProperty = "MyOtherProperty";
				xmlDocToWrite.AnotherProperty = "AnotherProperty";

				object[] paramObject = { xmlDocToWrite as object };
				var getXmlDocument = (XmlDocument)appBase.ComponentLoader.InvokeMethod (xmlUtils, "SerializeToXmlDocument", paramObject);

				object[] paramWriteObject = { getXmlDocument, fileToWrite };
				var writeFile = (bool)appBase.ComponentLoader.InvokeMethod (xmlUtils, "WriteXmlFile", paramWriteObject);

				if (writeFile) {
					File.Delete(xmlFileToWrite);
					isTrue = true;
				}

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}