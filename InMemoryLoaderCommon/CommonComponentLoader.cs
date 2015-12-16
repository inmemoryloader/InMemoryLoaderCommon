using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using log4net;
using InMemoryLoader;
using InMemoryLoaderBase;

namespace InMemoryLoaderCommon
{
	/// <summary>
	/// Component loader.
	/// </summary>
	public sealed partial class CommonComponentLoader
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static ILog log = LogManager.GetLogger (typeof(CommonComponentLoader));

		/// <summary>
		/// The components.
		/// </summary>
		public IList<IDynamicClassSetup> Components;
		/// <summary>
		/// The string component.
		/// </summary>
		public IDynamicClassSetup StringComponent;
		/// <summary>
		/// The check component.
		/// </summary>
		public IDynamicClassSetup CheckComponent;
		/// <summary>
		/// The convert component.
		/// </summary>
		public IDynamicClassSetup ConvertComponent;
		/// <summary>
		/// The crypt component.
		/// </summary>
		public IDynamicClassSetup CryptComponent;
		/// <summary>
		/// The xml component.
		/// </summary>
		public IDynamicClassSetup XmlComponent;
		/// <summary>
		/// The date time component.
		/// </summary>
		public IDynamicClassSetup DateTimeComponent;
		/// <summary>
		/// The email component.
		/// </summary>
		public IDynamicClassSetup EmailComponent;
		/// <summary>
		/// The file system component.
		/// </summary>
		public IDynamicClassSetup FileSystemComponent;
		/// <summary>
		/// The get component.
		/// </summary>
		public IDynamicClassSetup GetComponent;

		/// <summary>
		/// Initializes a new instance of the <see cref="PowerUpCommon.CommonComponentLoader"/> class.
		/// </summary>
		public CommonComponentLoader()
		{
			if (Components == null) {
				Components = new List<IDynamicClassSetup> ();
			}
		}

		/// <summary>
		/// Inits the common components.
		/// </summary>
		/// <returns><c>true</c>, if common components was inited, <c>false</c> otherwise.</returns>
		/// <param name="paramPath">Parameter path.</param>
		public bool InitCommonComponents (string paramPath)
		{
			SetupCommonComponents (paramPath);

			log.Debug ("Init Common Components");

			var compLoader = ComponentLoader.Instance;

			foreach (var component in Components) {
				object[] paramArgument = { AbstractPowerUpComponent.Key };
				var init = compLoader.InvokeMethod (component.Assembly, component.Class, component.InitMethod, paramArgument);
				log.DebugFormat ("Assembly: {0}, Class: {1}, Is init: {2}", component.Assembly, component.Class, init);
			}

			compLoader.InitClassRegistry ();

			return true;
		}
		/// <summary>
		/// Setups the common components.
		/// </summary>
		/// <returns><c>true</c>, if common components was setuped, <c>false</c> otherwise.</returns>
		/// <param name="paramPath">Parameter path.</param>
		private bool SetupCommonComponents (string paramPath)
		{
			if (StringComponent == null) {
				StringComponent = new DynamicClassSetup ();
				StringComponent.Assembly = Path.Combine (paramPath, "PowerUpStringUtils.dll");
				StringComponent.Class = "StringUtils";
			}
			if (!Components.Contains (StringComponent)) {
				Components.Add (StringComponent);
			}

			if (CheckComponent == null) {
				CheckComponent = new DynamicClassSetup ();
				CheckComponent.Assembly = Path.Combine (paramPath, "PowerUpCheckUtils.dll");
				CheckComponent.Class = "CheckUtils";
			}
			if (!Components.Contains (CheckComponent)) {
				Components.Add (CheckComponent);
			}

			if (ConvertComponent == null) {
				ConvertComponent = new DynamicClassSetup ();
				ConvertComponent.Assembly = Path.Combine (paramPath, "PowerUpConvertUtils.dll");
				ConvertComponent.Class = "ConvertUtils";
			}
			if (!Components.Contains (ConvertComponent)) {
				Components.Add (ConvertComponent);
			}

			if (CryptComponent == null) {
				CryptComponent = new DynamicClassSetup ();
				CryptComponent.Assembly = Path.Combine (paramPath, "PowerUpCryptUtils.dll");
				CryptComponent.Class = "CryptUtils";
			}
			if (!Components.Contains (CryptComponent)) {
				Components.Add (CryptComponent);
			}

			if (XmlComponent == null) {
				XmlComponent = new DynamicClassSetup ();
				XmlComponent.Assembly = Path.Combine (paramPath, "PowerUpXmlUtils.dll");
				XmlComponent.Class = "XmlUtils";
			}
			if (!Components.Contains (XmlComponent)) {
				Components.Add (XmlComponent);
			}

			if (DateTimeComponent == null) {
				DateTimeComponent = new DynamicClassSetup ();
				DateTimeComponent.Assembly = Path.Combine (paramPath, "PowerUpDateTimeUtils.dll");
				DateTimeComponent.Class = "DateTimeUtils";
			}
			if (!Components.Contains (DateTimeComponent)) {
				Components.Add (DateTimeComponent);
			}

			if (EmailComponent == null) {
				EmailComponent = new DynamicClassSetup ();
				EmailComponent.Assembly = Path.Combine (paramPath, "PowerUpEmailUtils.dll");
				EmailComponent.Class = "EmailUtils";
			}
			if (!Components.Contains (EmailComponent)) {
				Components.Add (EmailComponent);
			}

			if (FileSystemComponent == null) {
				FileSystemComponent = new DynamicClassSetup ();
				FileSystemComponent.Assembly = Path.Combine (paramPath, "PowerUpFileSystemUtils.dll");
				FileSystemComponent.Class = "FileSystemUtils";
			}
			if (!Components.Contains (FileSystemComponent)) {
				Components.Add (FileSystemComponent);
			}

			if (GetComponent == null) {
				GetComponent = new DynamicClassSetup ();
				GetComponent.Assembly = Path.Combine (paramPath, "PowerUpGetUtils.dll");
				GetComponent.Class = "GetUtils";
			}
			if (!Components.Contains (GetComponent)) {
				Components.Add (GetComponent);
			}

			return true;
		}
	}
}

