using System;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoaderCommon.Strings
{
	public partial class Strings : AbstractComponent
	{

		/// <summary>
		/// Kürzt einen Sting unter Berücksichtigung der Wörter
		/// </summary>
		/// <param name="source">Der String</param>
		/// <param name="maxCharCount">Die maximale Anzahl an Zeichen im resultierenden String</param>
		/// <returns>Gibt den gekürzten String, gegebenenfalls mit drei Punkten am Ende zurück</returns>
		public string Abbreviate(string paramValue, int maxCharCount)
		{
			var result = String.Empty;
			// String an Leerzeichen splitten
			string[] words = paramValue.Split(' ');
			// Die Sonderfälle abhandeln, dass der gesamte String 
			// kürzer oder das erste Wort schon zu lang ist
			if (paramValue.Length <= maxCharCount)
			{
				return paramValue;
			}
			if (words.Length > 0 && words[0].Length > maxCharCount)
			{
				return words[0].Substring(0, maxCharCount - 3) + "...";
			}
			// Die Wörter durchgehen und in das Ergebnis schreiben bis die Maximallänge erreicht ist
			for (int i = 0; i < words.Length; i++)
			{
				if (result.Length + words[i].Length + 4 > maxCharCount)
				{
					return result + "...";
				}
				else
				{
					result += ' ' + words[i];
				}
			}
			return paramValue;
		}




	}

}

