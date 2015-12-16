using System;
using log4net;
using InMemoryLoaderBase;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace PowerUpXmlUtils
{
	public partial class XmlUtils : AbstractPowerUpComponent
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(XmlUtils));

		/// <summary>
		/// Initializes a new instance of the <see cref="PowerUpXmlUtils.XmlUtils"/> class.
		/// </summary>
		public XmlUtils ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
		}

		/// <summary>
		/// Writes the xml file.
		/// </summary>
		/// <param name="xmldoc">Xmldoc.</param>
		/// <param name="file">File.</param>
		public void WriteXmlFile (XmlDocument xmldoc, string file)
		{
			XmlTextWriter writer = new XmlTextWriter (file, null);
			writer.Formatting = Formatting.Indented;
			xmldoc.Save (writer);
			writer.Close ();
		}

		/// <summary>
		/// Serializes to xml document.
		/// </summary>
		/// <returns>The to xml document.</returns>
		/// <param name="xmldata">Xmldata.</param>
		public XmlDocument SerializeToXmlDocument (string xmldata)
		{
			XmlDocument xml = new XmlDocument ();
			xml.Load (xmldata);
			return xml;
		}

		/// <summary>
		/// Serializes to xml document.
		/// </summary>
		/// <returns>The to xml document.</returns>
		/// <param name="xmldata">Xmldata.</param>
		/// <param name="removeReserved">If set to <c>true</c> remove reserved.</param>
		public XmlDocument SerializeToXmlDocument (string xmldata, bool removeReserved)
		{
			XmlDocument xml = new XmlDocument ();
			if (removeReserved) {
				string data = string.Empty;
				data = CleanXMLData (xmldata);
				// LIBBase lIBBase = LIBBase.Instance;
				// var var = lIBBase.FireUtilityModule("stuckenschmidt.com.LIB.XXX", "XXX", param);
				xml.LoadXml (data);
			} else {
				xml.LoadXml (xmldata);
			}
			return xml;
		}

		/// <summary>
		/// Serializes to xml document.
		/// </summary>
		/// <returns>The to xml document.</returns>
		/// <param name="xmldata">Xmldata.</param>
		public XmlDocument SerializeToXmlDocument (object xmldata)
		{
			Type type = xmldata.GetType ();
			XmlDocument xmlDocument = new XmlDocument ();
			XmlSerializer serializer = new XmlSerializer (type);
			using (var stream = new MemoryStream ()) {
				serializer.Serialize (stream, xmldata);
				stream.Flush ();
				stream.Seek (0, SeekOrigin.Begin);
				xmlDocument.Load (stream);
			}
			return xmlDocument;
		}

		/// <summary>
		/// Serializes to xml document.
		/// </summary>
		/// <returns>The to xml document.</returns>
		/// <param name="xmldata">Xmldata.</param>
		/// <param name="removeReserved">If set to <c>true</c> remove reserved.</param>
		public XmlDocument SerializeToXmlDocument (object xmldata, bool removeReserved)
		{
			string data = string.Empty;
			data = CleanXMLData (xmldata as string);
			return SerializeToXmlDocument (data as object);
		}

		/// <summary>
		/// Gets the value from xml document.
		/// </summary>
		/// <returns>The value from xml document.</returns>
		/// <param name="xmldoc">Xmldoc.</param>
		/// <param name="parmQuery">Parm query.</param>
		/// <param name="parmSetNull">Parm set null.</param>
		public string GetValueFromXmlDocument (XmlDocument xmldoc, string parmQuery, string parmSetNull)
		{
			string value = parmSetNull;
			value = xmldoc.SelectSingleNode (parmQuery).InnerText ?? parmSetNull;
			return value;
		}

		/// <summary>
		/// Gets the xml node list from xml document.
		/// </summary>
		/// <returns>The xml node list from xml document.</returns>
		/// <param name="xmldoc">Xmldoc.</param>
		/// <param name="parmQuery">Parm query.</param>
		public XmlNodeList GetXmlNodeListFromXmlDocument (XmlDocument xmldoc, string parmQuery)
		{
			XmlNodeList nodes = null;
			nodes = xmldoc.SelectNodes (parmQuery) ?? null;
			return nodes;
		}

		/// <summary>
		/// Gets the value from xml node.
		/// </summary>
		/// <returns>The value from xml node.</returns>
		/// <param name="xmlnode">Xmlnode.</param>
		/// <param name="parmQuery">Parm query.</param>
		public string GetValueFromXmlNode (XmlNode xmlnode, string parmQuery)
		{
			string value = null;
			value = xmlnode [parmQuery].InnerText ?? null;
			return value;
		}

		/// <summary>
		/// Cleans the XML data.
		/// </summary>
		/// <returns>The XML data.</returns>
		/// <param name="paramXmlData">Parameter xml data.</param>
		public string CleanXMLData (string paramXmlData)
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append (paramXmlData);
			sb.Replace ("  ", " ");
			sb.Replace ("\r", string.Empty);
			sb.Replace ("\n", string.Empty);
			sb.Replace ("\t", string.Empty);
			sb.Replace ("&", "&amp;");

			return sb.ToString ();
		}

		/// <summary>
		/// Cleans the XML file.
		/// </summary>
		/// <returns><c>true</c>, if XML file was cleaned, <c>false</c> otherwise.</returns>
		/// <param name="paramXmlFile">Parameter xml file.</param>
		public bool CleanXMLFile (string paramXmlFile)
		{
			StreamReader sr = new StreamReader (paramXmlFile);
			string strFileContent = sr.ReadToEnd ();
			sr.Close ();

			StringBuilder sb = new StringBuilder ();
			sb.Append (strFileContent);
			sb.Replace ("  ", " ");
			sb.Replace ("\r", string.Empty);
			sb.Replace ("\n", string.Empty);
			sb.Replace ("\t", string.Empty);
			sb.Replace ("&", "&amp;");

			string strCleanFileContent = sb.ToString ();
			StreamWriter sw = new StreamWriter (paramXmlFile);
			sw.WriteLine (strCleanFileContent);
			sw.Close ();

			sr = null;
			sw = null;
			return true;
		}
	}
}

