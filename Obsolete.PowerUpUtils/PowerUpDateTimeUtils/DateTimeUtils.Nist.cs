//
// DateTimeUtils.Nist.cs
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

using System;
using InMemoryLoaderBase;
using System.Text;
using System.Net.Sockets;

namespace PowerUpDateTimeUtils
{
    public partial class DateTimeUtils : AbstractComponent
    {
        /// <summary>
        /// Fragt das aktuelle Datum (inklusive Zeit) bei einem NIST-Server ab
        /// </summary>
        /// <returns>Gibt das abgefragte Datum zurück</returns>
        public DateTime GetNistTime ()
        {
            // Variable für Fehlermeldungen
            string errors = null;

            // Array für die abzufragenden Server
            string[] servers = {
                "time-a.nist.gov",
                "time-b.nist.gov",
                "time.nist.gov",
                "utcnist.colorado.edu",
                "nist1.datum.com"
            };

            // Schleife, in der die Server abgefragt werden, bis das Ergebnis 
            // in Ordnung ist
            for (int i = 0; i < servers.Length; i++) {
                TcpClient tcpClient = null;
                try {
                    // TcpClient erzeugen und den Empfangs-Timeout auf eine Sekunde
                    // setzen
                    tcpClient = new TcpClient ();
                    tcpClient.ReceiveTimeout = 1000;

                    // Versuch zum aktuellen Server eine Verbindung aufzubauen
                    tcpClient.Connect (servers [i], 13);

                    // Den NetworkStream referenzieren
                    NetworkStream networkStream = tcpClient.GetStream ();

                    string result = null;
                    if (networkStream.CanWrite && networkStream.CanRead) {
                        // Das Ergebnis empfangen und in ASCII konvertieren
                        byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
                        try {
                            networkStream.Read (bytes, 0,
                                (int)tcpClient.ReceiveBufferSize);
                            result = Encoding.ASCII.GetString (bytes);
                        } catch (Exception ex) {
                            // Fehler dokumentieren
                            if (errors != null)
                                errors += "\r\n";
                            errors += "Fehler bei der Abfrage von '" + servers [i] + ": " + ex.Message;
                        }
                    }

                    if (result != null) {
                        // Das Ergebnis, das die Form JJJJJ YR-MO-DA HH:MM:SS TT L H msADV 
                        // UTC(NIST) OTM besitzt, in einzelne Token aufsplitten
                        string[] token = result.Split (' ');

                        // Anzahl der Token überprüfen
                        if (token.Length >= 6) {
                            // Den Health-Status auslesen und überprüfen
                            string health = token [5];
                            if (health == "0") {
                                // Alles ok:  Datums- und Zeitangaben auslesen
                                string[] dates = token [1].Split ('-');
                                string[] times = token [2].Split (':');

                                // DateTime-Instanz mit diesen Daten erzeugen
                                DateTime utcDate =
                                    new DateTime (Int32.Parse (dates [0]) + 2000,
                                        Int32.Parse (dates [1]), Int32.Parse (dates [2]),
                                        Int32.Parse (times [0]), Int32.Parse (times [1]),
                                        Int32.Parse (times [2]));

                                // Lokale Zeit berechnen und zurückgeben
                                return TimeZone.CurrentTimeZone.ToLocalTime (utcDate);
                            } else {
                                // Fehler dokumentieren
                                if (errors != null)
                                    errors += "\r\n";
                                errors += "Fehler bei der Abfrage von '" + servers [i] + ": Der Health-Status ist " + health;
                            }
                        } else {
                            // Fehler dokumentieren
                            if (errors != null)
                                errors += "\r\n";
                            errors += "Fehler bei der Abfrage von '" + servers [i] +
                            ": Die Anzahl der Token ist kleiner als 6";
                        }
                    }
                } catch (Exception ex) {
                    // Fehler dokumentieren
                    if (errors != null)
                        errors += "\r\n";
                    errors += "Fehler bei der Abfrage von '" + servers [i] + ": " + ex.Message;
                } finally {
                    try {
                        // TcpClient schließen
                        tcpClient.Close ();
                    } catch {
                    }
                }
            }

            // Wenn die Methode hier ankommt, sind bei allen Abfragen
            // Fehler aufgetreten, also eine Ausnahme werfen
            throw new Exception (errors);
        }

    }

}