using System;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Reflection;

using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;

using log4net;
using Microsoft.CSharp.RuntimeBinder;

namespace InMemoryLoaderCommenTestSuite
{
	public class General
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(AppBase));
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase;

		/// <summary>
		/// Initializes a new instance of the <see cref="InMemoryLoaderCommenTestSuite.General"/> class.
		/// </summary>
		public General ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
			appBase = AppBase.Instance;
		}

		/// <summary>
		/// Determines whether this instance is simple init.
		/// </summary>
		/// <returns><c>true</c> if this instance is simple init; otherwise, <c>false</c>.</returns>
		public bool IsSimpleInit ()
		{
			var checkUtils = appBase.CommonComponentLoader.CheckComponent;

			object[] paramArg = { "No byte value" };
			var result = (bool)appBase.ComponentLoader.InvokeMethod (checkUtils.Assembly, checkUtils.Class, "IsStringByte", paramArg);

			return result;
		}

		/// <summary>
		/// Determines whether this instance is linq init.
		/// </summary>
		/// <returns><c>true</c> if this instance is linq init; otherwise, <c>false</c>.</returns>
		public bool IsLinqInit ()
		{
			var checkUtils = appBase.ComponentLoader.ComponentRegistry.Where (utl => utl.Key.Class.Contains ("CheckUtils")).SingleOrDefault ().Value;

			object[] paramArg = { "No byte value" };
			var result = (bool)appBase.ComponentLoader.InvokeMethod (checkUtils, "IsStringByte", paramArg);

			return result;
		}

		public bool SimpleObjectHelper ()
		{
			var checkUtils = appBase.ComponentLoader.ComponentRegistry.Where (utl => utl.Key.Class.Contains ("CheckUtils")).SingleOrDefault ().Value;

			object[] paramArg = { "No byte value" };
			var result = (bool)appBase.ComponentLoader.InvokeMethod (checkUtils, "IsStringByte", paramArg);



			return result;
		}

		/// <summary>
		/// Determines whether this instance is method init.
		/// </summary>
		/// <returns><c>true</c> if this instance is method init; otherwise, <c>false</c>.</returns>
		public bool IsMethodInit ()
		{
			IDynamicClassInfo checkUtils = appBase.ComponentLoader.ComponentRegistry.Where (utl => utl.Key.Class.Contains ("CheckUtils")).SingleOrDefault ().Value;
			Type type = checkUtils.ClassType;

			string name = "IsStringByte";
			object[] parameter = { "No byte value" };

			MethodInfo info = type.GetMethods ().Where (mt => mt.Name.Equals (name) && mt.GetParameters ().Count () == 1).SingleOrDefault ();
			bool result = (bool)info.Invoke (type, parameter);

			var boolResult = Convert.ToBoolean	(result);

			return boolResult;
		}
	}
}