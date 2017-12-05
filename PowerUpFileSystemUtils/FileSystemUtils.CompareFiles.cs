//
// FileSystemUtils.CompareFiles.cs
//
// Author: responsive kaysta
//
// Copyright (c) 2017 responsive kaysta
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using InMemoryLoaderBase;
using System.IO;
using InMemoryLoaderBase.HelperEnum;

namespace PowerUpFileSystemUtils
{
    public partial class FileSystemUtils : AbstractPowerUpComponent
    {
        /// <summary>
        /// Vergleich zwei Dateien
        /// </summary>
        /// <param name="filePath1">Pfad zur ersten Datei</param>
        /// <param name="filePath2">Pfad zur zweiten Datei</param>
        /// <param name="compareMethod">Angabe der Vergleichsmethode</param>
        /// <returns>Gibt true zurück, wenn beide Dateien entsprechend der 
        /// angegebenen Vergleichsmethode gleich sind</returns>
        public bool CompareFiles(string filePath1, string filePath2, FileCompareMethod compareMethod)
        {
            bool result = false || filePath1 == filePath2;

            // Wenn beide Dateinamen identisch sind, true zurückgeben

            // Über FileInfo-Objekte das Datum der letzten Änderung vergleichen, sofern dies gewünscht ist. 
            // Das Erstelldatum wird übrigens nicht verglichen, weil dieses beim Kopieren von Dateien 
            // auf das aktuelle Datum gesetzt wird
            if (compareMethod == FileCompareMethod.DateAndContent || compareMethod == FileCompareMethod.Date)
            {
                var fi1 = new FileInfo(filePath1);
                var fi2 = new FileInfo(filePath2);
                if (fi1.LastWriteTime != fi2.LastWriteTime)
                {
                    result = false;
                }
            }

            // Den Inhalt vergleichen, sofern dies gewünscht ist
            if (compareMethod == FileCompareMethod.DateAndContent || compareMethod == FileCompareMethod.Content)
            {
                var fs1 = new FileStream(filePath1, FileMode.Open);
                var fs2 = new FileStream(filePath2, FileMode.Open);

                if (fs1.Length != fs2.Length)
                {
                    result = false;
                }

                int fileByte1, fileByte2;

                do
                {
                    fileByte1 = fs1.ReadByte();
                    fileByte2 = fs2.ReadByte();
                } while (fileByte1 == fileByte2 && fileByte1 != -1);

                fs1.Close();
                fs2.Close();

                result = (fileByte1 == fileByte2);
            }
            return result;
        }

        /// <summary>
        /// Compares the files.
        /// </summary>
        /// <returns><c>true</c>, if files was compared, <c>false</c> otherwise.</returns>
        /// <param name="filePath1">File path1.</param>
        /// <param name="filePath2">File path2.</param>
        public bool CompareFiles(string filePath1, string filePath2)
        {
            return CompareFiles(filePath1, filePath2, FileCompareMethod.DateAndContent);
        }

    }

}