using System;
using InMemoryLoaderBase;
using log4net;
using System.Text.RegularExpressions;
using System.Text;

namespace PowerUpStringUtils
{
    public partial class StringUtils : AbstractComponent
    {
        /// <summary>
        /// Ersetzt Teilstrings in einem String
        /// </summary>
        /// <param name="source">Der String, in dem ersetzt werden soll</param>
        /// <param name="find">Der zu suchende Teilstring</param>
        /// <param name="replacement">Der String, der die gefundenen Teilstrings ersetzt</param>
        /// <param name="ignoreCase">Gibt an, ob die Groß-/Kleinschreibung nicht berücksichtigt werden soll</param>
        /// <param name="start">Gibt an, ab welchem gefundenen Teilstring ersetzt werden soll. Dieses Argument ist, wie in C# üblich, 0-basiert.</param>
        /// <param name="count">Gibt an, wie viele gefundene Teilstrings maximal ersetzt werden sollen. -1 steht für alle gefundenen ab <paramref name="start"/></param>
        /// <returns>Gibt einen String zurück, in dem die gefundenen Teilstrings ersetzt wurden</returns>
        public string Replace(string source, string find, string replacement, bool ignoreCase, int start, int count)
        {
            int pos1 = 0, pos2 = 0;
            int findStringLen = find.Length;
            string baseString;
            string result = null;
            // Den Sonderfall abhandeln, dass count mit 0 angegeben ist
            if (count == 0)
            {
                return source;
            }
            // Wenn der Vergleich ohne Berücksichtigung der Groß-/Kleinschreibung
            // erfolgen soll, werden der zu durchsuchende und der Suchstring einfach in
            // Kleinschreibung umgewandelt
            if (ignoreCase)
            {
                baseString = source.ToLower();
                find = find.ToLower();
            }
            else
            {
                baseString = source;
            }
            // Erstes Vorkommen des Suchstrings suchen
            pos2 = baseString.IndexOf(find, StringComparison.Ordinal);
            // Den String durchgehen, solange der Suchstring noch gefunden wurde
            int findIndex = -1;
            int replaceCount = 0;
            while (pos2 != -1)
            {
                findIndex++;
                if (findIndex >= start)
                {
                    // Wenn der Index des gefundenen Teilstrings größer/gleich start ist:
                    // Das Ergebnis zusammensetzen und die Such-Indizes auf die neuen
                    // Positionen setzen
                    result += source.Substring(pos1, pos2 - pos1) + replacement;
                    pos1 = pos2 + findStringLen;
                    pos2 = baseString.IndexOf(find, pos1, StringComparison.Ordinal);
                    // Wenn count größer -1 definiert ist: Überprüfen, ob die Anzahl
                    // erreicht ist
                    replaceCount++;
                    if (count > -1 && replaceCount >= count)
                    {
                        break;
                    }
                }
                else
                {
                    // Index des gefundenen Teilstrings ist noch kleiner start:
                    // Teilstring ohne zu ersetzen an das Ergebnis anhängen
                    result += source.Substring(pos1, pos2 - pos1 + findStringLen);
                    // Such-Positionen aktualisieren
                    pos1 = pos2 + findStringLen;
                    pos2 = baseString.IndexOf(find, pos1, StringComparison.Ordinal);
                }
            }
            if (pos1 < source.Length)
            {
                // Wenn nach dem letzten Suchstring noch ein Teilstring gespeichert ist,
                // diesen hinten anhängen
                result += source.Substring(pos1, source.Length - pos1);
            }
            // Ergebnis zurückgeben
            return result;
        }

        /// <summary>
        /// Ersetzt Teilstrings in einem String
        /// </summary>
        /// <param name="source">Der String, in dem ersetzt werden soll</param>
        /// <param name="find">Der zu suchende Teilstring</param>
        /// <param name="replacement">Der String, der die gefundenen Teilstrings ersetzt</param>
        /// <param name="ignoreCase">Gibt an, ob die Groß-/Kleinschreibung nicht berücksichtigt werden soll</param>
        /// <returns>Gibt einen String zurück, in dem die gefundenen Teilstrings ersetzt wurden</returns>
        public string Replace(string source, string find, string replacement, bool ignoreCase)
        {
            return Replace(source, find, replacement, ignoreCase, 0, -1);
        }

        /// <summary>
        /// Replace chars in a given text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ToReplace"></param>
        /// <param name="ReplaceWith"></param>
        /// <returns>string, </returns>
        public string Replace(string text, char ToReplace, char ReplaceWith)
        {
            StringBuilder sb = new StringBuilder(text);
            sb.Replace(ToReplace, ReplaceWith);
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parmString"></param>
        /// <param name="parmPos"></param>
        /// <param name="parmChar"></param>
        /// <returns></returns>
        public string ReplaceCharAt(string parmString, int parmPos, char parmChar)
        {
            return parmString.Substring(0, parmPos) + parmChar + parmString.Substring(parmPos + 1);
        }
    }
}

