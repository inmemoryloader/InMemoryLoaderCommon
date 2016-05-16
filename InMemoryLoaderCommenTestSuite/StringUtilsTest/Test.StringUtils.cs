using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderCommon;
using log4net;
using System.Globalization;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace InMemoryLoaderCommenTestSuite.StringUtilsTest
{
	public partial class Test
	{
		/// <summary>
		/// The lorem text.
		/// </summary>
		private static string loremText = "Lorem ipsum dolor sit amet, Lorem ipsum dolor sit amet, Lorem ipsum dolor sit amet, Lorem ipsum dolor sit amet";
		/// <summary>
		/// The extract numbers.
		/// </summary>
		private static string extractNumbers = "ExtractNumbers 14, 2, 4, ExtractNumbers 98, 2";

		/// <summary>
		/// Strings the utils test.
		/// </summary>
		/// <returns><c>true</c>, if utils test was strung, <c>false</c> otherwise.</returns>
		public static bool StringUtilsTest ()
		{
			bool stringUtilsTest = false;

			stringUtilsTest = AbbreviateTest ();
			stringUtilsTest = CountOccurenceOfStringTest ();
			stringUtilsTest = CutStringTest ();
			stringUtilsTest = ExtractNumbersTest ();
			stringUtilsTest = GetWordsTest ();

			return stringUtilsTest;
		}

		/// <summary>
		/// Abbreviates the test.
		/// </summary>
		/// <returns><c>true</c>, if test was abbreviated, <c>false</c> otherwise.</returns>
		private static bool AbbreviateTest ()
		{
			try {
				bool isTrue = false;

				int length = 64;
				int result = 59;

				object[] paramObject = { loremText, length };
				var getString = (string)appBase.ComponentLoader.InvokeMethod (stringUtils, "Abbreviate", paramObject);

				if (getString.Length == result) {
					isTrue = true;
				}

				log.DebugFormat ("Abbreviate (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Counts the occurence of string test.
		/// </summary>
		/// <returns><c>true</c>, if occurence of string test was counted, <c>false</c> otherwise.</returns>
		private static bool CountOccurenceOfStringTest ()
		{
			try {
				bool isTrue = false;

				int length = 4;
				string search = "sit";

				object[] paramObject = { loremText, search };
				var getString = (long)appBase.ComponentLoader.InvokeMethod (stringUtils, "CountOccurenceOfString", paramObject);

				if (getString == length) {
					isTrue = true;
				}

				log.DebugFormat ("CountOccurenceOfString (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Cuts the string test.
		/// </summary>
		/// <returns><c>true</c>, if string test was cut, <c>false</c> otherwise.</returns>
		private static bool CutStringTest ()
		{
			try {
				bool isTrue = false;

				int length = 15;
				var direction = StringDirection.Left;

				object[] paramObject = { loremText, length, direction };
				var getString = (string)appBase.ComponentLoader.InvokeMethod (stringUtils, "Cut", paramObject);

				if (getString.Length == length) {
					isTrue = true;
				}

				log.DebugFormat ("Cut (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Extracts the numbers test.
		/// </summary>
		/// <returns><c>true</c>, if numbers test was extracted, <c>false</c> otherwise.</returns>
		private static bool ExtractNumbersTest ()
		{
			try {
				bool isTrue = false;
				var extractOnlyIntegers = true;
				int length = 5;

				object[] paramObject = { extractNumbers, extractOnlyIntegers };
				var getString = (double[])appBase.ComponentLoader.InvokeMethod (stringUtils, "ExtractNumbers", paramObject);

				if (getString.Length == length) {
					isTrue = true;
				}

				log.DebugFormat ("ExtractNumbers (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}

		/// <summary>
		/// Gets the words test.
		/// </summary>
		/// <returns><c>true</c>, if words test was gotten, <c>false</c> otherwise.</returns>
		private static bool GetWordsTest ()
		{
			try {
				bool isTrue = false;
				int length = 4;

				object[] paramObject = { loremText, length };
				var getString = (string[])appBase.ComponentLoader.InvokeMethod (stringUtils, "GetWords", paramObject);

				if (getString.Length > 0) {
					isTrue = true;
				}

				log.DebugFormat ("GetWords (true) = {0}", isTrue);

				return isTrue;
			} catch (Exception ex) {
				throw ex;
			}		
		}
	}
}