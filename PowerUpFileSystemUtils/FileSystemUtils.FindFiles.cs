//
// FileSystemUtils.FindFiles.cs
//
// Author: responsive kaysta <me@responsive-kaysta.ch>
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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;

namespace PowerUpFileSystemUtils
{
    public partial class FileSystemUtils : AbstractComponent
    {
        /// <summary>
        /// Sucht alle Dateien, die dem angegebenen Muster entsprechen
        /// </summary>
        /// <param name="startDirectory">Pfad zu dem Verzeichnis, dem gesucht werden soll</param>
        /// <param name="filePattern">Das Such-Muster (z. B. *.txt)</param>
        /// <param name="recursive">Gibt an, ob auch in den Unterordnern gesucht werden soll</param>
        /// <returns>Gibt ein ReadOnlyCollection vom Typ FileInfo zurück, die die 
        /// gefundenen Dateien repräsentiert</returns>
        public ReadOnlyCollection<FileInfo> FindFiles(string startDirectory, string filePattern, bool recursive)
        {
            // Basis-Auflistung erzeugen
            List<FileInfo> fileList = new List<FileInfo>();

            // Die rekursive private Methode aufrufen
            findFiles(new DirectoryInfo(startDirectory), filePattern, recursive, fileList);

            // Ergebnis-Collection zurückgeben
            return new ReadOnlyCollection<FileInfo>(fileList);
        }

        /// <summary>
        /// Sucht alle Dateien, die dem angegebenen Muster entsprechen
        /// </summary>
        /// <param name="directory">Das Verzeichnis, in dem gesucht werden soll</param>
        /// <param name="filePattern">Das Such-Muster (z. B. *.txt)</param>
        /// <param name="recursive">Gibt an, ob auch in den Unterordnern gesucht werden soll</param>
        /// <param name="fileList">Referenz auf eine List-Auflistung, die die 
        /// Pfade zu den gefundenen Dateien aufnimmt</param>
        void findFiles(DirectoryInfo directory, string filePattern, bool recursive, List<FileInfo> fileList)
        {
            if (!string.IsNullOrEmpty(filePattern))
            {
                // Das Dateimuster splitten
                string[] filePatterns = filePattern.Split(';');

                // Alle Dateimuster durchgehen und in dem übergebenen Verzeichnis suchen
                foreach (string partPattern in filePatterns)
                {
                    foreach (FileInfo fileInfo in directory.GetFiles(partPattern))
                    {
                        fileList.Add(fileInfo);
                    }
                }
            }
            else
            {
                // Kein Suchmuster angegeben: Alle Dateien durchgehen 
                foreach (FileInfo fileInfo in directory.GetFiles())
                {
                    fileList.Add(fileInfo);
                }
            }

            if (recursive)
            {
                // Wenn rekursiv gesucht werden soll:
                // Die Methode für alle Unterordner aufrufen
                foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                {
                    findFiles(subDirectory, filePattern, recursive, fileList);
                }
            }
        }

    }

}