using System;
using log4net;
using InMemoryLoaderBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;

namespace PowerUpEmailUtils
{
	public partial class EmailUtils : AbstractPowerUpComponent
	{
		// private string returnValue = null;
		private static string smtpErrorString;

		/// <summary>
		/// Abfragen des ErrorTextes im Falle einer Exception.
		/// </summary>
		public string SmtpErrorString {
			get { return smtpErrorString; }
			set { smtpErrorString = value; }
		}

		/// <summary>
		/// Hauptfunktion zum Versenden einer Email. Falls keine Attachments versendet werden sollen, muss einfach ein Leerstring 
		/// beim Parameter AttachmentPfad mitgegeben werden. Das Ueberladen von Funktionen wird für COM Schnittstellen nicht 
		/// unterstützt.
		/// </summary>
		/// <param name="smtp">Mailserver Adresse</param>
		/// <param name="sender">Emailadresse des Senders</param>
		/// <param name="empfaenger">gültige Emailadressen</param>
		/// <param name="blind_empfaenger">gültige Emailadresse BCC</param>
		/// <param name="subject">Titel</param>
		/// <param name="body">EmailText</param>
		/// <param name="attachmentPfad">Pfadangaben der zu versendenden Attachments</param>
		public bool SendSimple (string smtp, string sender, string[] empfaenger, string[] blind_empfaenger, string subject, string body, string[] attachmentPfad)
		{
			int zaehler = 0;
			Attachment data = null;
			MailMessage mailMsg = new MailMessage ();

			try {
				mailMsg.From = new MailAddress (sender);

				//
				// Parameter Check Attachment
				//
				if (attachmentPfad != null) {					
				
					zaehler = attachmentPfad.Length;
					for (int i = 0; i < zaehler; i++) {
						if (attachmentPfad [i] != "") {
							FileInfo filecheck = new FileInfo (attachmentPfad [i]);
							if (!filecheck.Exists) {
								throw new ArgumentException ("Attachment File nicht gefunden: " + attachmentPfad [i]);
							} else {
								data = new Attachment (attachmentPfad [i]);
								mailMsg.Attachments.Add (data);
							}
						}
					}
				}

				//
				// Parameter Check Empfänger
				//
				string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

				zaehler = empfaenger.Length;
				for (int i = 0; i < zaehler; i++) {
					Match match = Regex.Match (empfaenger [i], pattern);
					if (!match.Success) {
						throw new ArgumentException ("Empfänger Emailadr. falsch " + empfaenger [i]);
					} else {
						mailMsg.To.Add (new MailAddress (empfaenger [i]));
					}
				}


				//
				// Parameter Check Blind Empfänger (BCC)
				//
				if (blind_empfaenger != null) {					
					zaehler = blind_empfaenger.Length;
					for (int i = 0; (i < zaehler) && (blind_empfaenger [i].Length > 0); i++) {
						Match match = Regex.Match (blind_empfaenger [i], pattern);
						if (!match.Success) {
							throw new ArgumentException ("BCC-Empfänger Emailadr. falsch " + blind_empfaenger [i]);
						} else {
							mailMsg.Bcc.Add (new MailAddress (blind_empfaenger [i]));
						}
					}
				}

				//
				// Email zusammen stellen und senden
				//
				mailMsg.Subject = subject;
				mailMsg.Body = body;

				SmtpClient client = new SmtpClient (smtp);
				client.Send (mailMsg);
			} catch (Exception ex) {
				SmtpErrorString = ex.Message.ToString ();
				throw ex;
			} finally {
				// Sehr wichtig! Ansonsten werden die Attachment Files nicht freigegeben.
				mailMsg.Dispose ();
			}
			return true;
		}

	}
}

