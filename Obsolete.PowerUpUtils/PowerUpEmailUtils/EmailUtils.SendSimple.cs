//
// EmailUtils.SendSimple.cs
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
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;

namespace PowerUpEmailUtils
{
    public partial class EmailUtils : AbstractComponent
    {
        // private string returnValue = null;

        /// <summary>
        /// Abfragen des ErrorTextes im Falle einer Exception.
        /// </summary>
        public string SmtpErrorString
        {
            get;
            set;
        }

        /// <summary>
        /// Hauptfunktion zum Versenden einer Email. Falls keine Attachments versendet werden sollen, muss einfach ein Leerstring 
        /// beim Parameter AttachmentPfad mitgegeben werden. Das Ueberladen von Funktionen wird für COM Schnittstellen nicht 
        /// unterstützt.
        /// </summary>
        /// <param name="smtp">Mailserver Adresse</param>
        /// <param name="sender">Emailadresse des Senders</param>
        /// <param name="empfaenger">gültige Emailadressen</param>
        /// <param name="blindEmpfaenger">gültige Emailadresse BCC</param>
        /// <param name="subject">Titel</param>
        /// <param name="body">EmailText</param>
        /// <param name="attachmentPfad">Pfadangaben der zu versendenden Attachments</param>
        public bool SendSimple(string smtp, string sender, string[] empfaenger, string[] blindEmpfaenger, string subject, string body, string[] attachmentPfad)
        {
            int zaehler = 0;
            Attachment data = null;
            var mailMsg = new MailMessage();

            try
            {
                mailMsg.From = new MailAddress(sender);

                //
                // Parameter Check Attachment
                //
                if (attachmentPfad != null)
                {					
				
                    zaehler = attachmentPfad.Length;
                    for (int i = 0; i < zaehler; i++)
                    {
                        if (attachmentPfad[i] != "")
                        {
                            var filecheck = new FileInfo(attachmentPfad[i]);
                            if (!filecheck.Exists)
                            {
                                throw new ArgumentException("Attachment File nicht gefunden: " + attachmentPfad[i]);
                            }
                            else
                            {
                                data = new Attachment(attachmentPfad[i]);
                                mailMsg.Attachments.Add(data);
                            }
                        }
                    }
                }

                //
                // Parameter Check Empfänger
                //
                const string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

                zaehler = empfaenger.Length;
                for (int i = 0; i < zaehler; i++)
                {
                    var match = Regex.Match(empfaenger[i], pattern);
                    if (!match.Success)
                    {
                        throw new ArgumentException("Empfänger Emailadr. falsch " + empfaenger[i]);
                    }
                    else
                    {
                        mailMsg.To.Add(new MailAddress(empfaenger[i]));
                    }
                }


                //
                // Parameter Check Blind Empfänger (BCC)
                //
                if (blindEmpfaenger != null)
                {					
                    zaehler = blindEmpfaenger.Length;
                    for (int i = 0; (i < zaehler) && (blindEmpfaenger[i].Length > 0); i++)
                    {
                        Match match = Regex.Match(blindEmpfaenger[i], pattern);
                        if (!match.Success)
                        {
                            throw new ArgumentException("BCC-Empfänger Emailadr. falsch " + blindEmpfaenger[i]);
                        }
                        else
                        {
                            mailMsg.Bcc.Add(new MailAddress(blindEmpfaenger[i]));
                        }
                    }
                }

                //
                // Email zusammen stellen und senden
                //
                mailMsg.Subject = subject;
                mailMsg.Body = body;

                var client = new SmtpClient(smtp);
                client.Send(mailMsg);
            }
            catch (Exception ex)
            {
                SmtpErrorString = ex.Message.ToString();
                throw ex;
            }
            finally
            {
                // Sehr wichtig! Ansonsten werden die Attachment Files nicht freigegeben.
                mailMsg.Dispose();
            }
            return true;
        }

    }
}

