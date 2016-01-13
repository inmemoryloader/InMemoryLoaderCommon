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
	public class XmlUtilsTests
	{
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;
		/// <summary>
		/// The xml utils.
		/// </summary>
		private static IDynamicClassSetup xmlUtils = appBase.CommonComponentLoader.XmlComponent;
		/// <summary>
		/// The xml folder path.
		/// </summary>
		private static string xmlFolderPath = "/home/kaysta/github.com/InMemoryLoaderCommon/InMemoryLoaderCommonUnitTest/XmlTestFolder/";
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
		/// Xmls the utils test1.
		/// </summary>
		/// <returns>The utils test1.</returns>
		public static object XmlUtilsTest1 ()
		{
			try {
				var xmlDocToWrite = new XmlDocToWrite ();
				xmlDocToWrite.MyProperty = "MyProperty";
				xmlDocToWrite.MyOtherProperty = "MyOtherProperty";
				xmlDocToWrite.AnotherProperty = "AnotherProperty";

				object[] paramObject = { xmlDocToWrite as object };
				var getXmlDocument = appBase.ComponentLoader.InvokeMethod (xmlUtils.Assembly, xmlUtils.Class, "SerializeToXmlDocument", paramObject);

				return getXmlDocument;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Xmls the utils test2.
		/// </summary>
		/// <returns>The utils test2.</returns>
		/// <param name="xmldoc">Xmldoc.</param>
		public static object XmlUtilsTest2 (XmlDocument xmldoc)
		{
			try {
				var fileToWrite = Path.Combine(xmlFolderPath, xmlFileToWrite);
				bool isOk = false;

				object[] paramObject = { xmldoc, fileToWrite };
				var writeFile = (bool)appBase.ComponentLoader.InvokeMethod (xmlUtils.Assembly, xmlUtils.Class, "WriteXmlFile", paramObject);

				if (writeFile) {
					File.Delete(xmlFileToWrite);
					isOk = true;
				}

				return isOk;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}

