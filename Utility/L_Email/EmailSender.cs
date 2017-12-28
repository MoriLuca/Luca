using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace L_Email
{
    public class EmailSender
    {
        private object locker = new object();
        private MailMessage mailMessage;

        private string smtpServer;
        private int smtpPort;
        private bool sslEnabled;
        private string smtpAccountEmail;
        private string smtpAccountPassword;

        public enum eEmailAccount
        {
            LucaGiDiAutomazione,
            LucaGoogleMail,
            Anonimo
        }

        public EmailSender(eEmailAccount emailAccount,
            //dati superflui, da utilizzare solo per account diversi da quelli di default
            string _smtpServer = null,
            int _smtpPort = 0,
            bool _sslEnabled = false,
            string _smtpAccountEmail =null,
            string _smtpAccountPassword = null)
        {
            switch (emailAccount)
            {
                case eEmailAccount.LucaGiDiAutomazione:
                    try
                    {
                        smtpServer = "authsmtp.register.it";
                        smtpPort = 587;
                        sslEnabled = false;
                        smtpAccountEmail = "luca.mori@gidiautomazione.it";
                        smtpAccountPassword = "000BenvenutoWork";
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(" - Creazione oggetto Email Register completo");
                        Console.WriteLine(" - Dispositivo pronto all'invio di posta elettronica con account : " + smtpAccountEmail);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Errore creazione oggetto Email Client, per invio di email con server Register");
                        Console.WriteLine("Codice errore: ");
                        Console.WriteLine(ex.Message);
                    }
                    break;


                case eEmailAccount.LucaGoogleMail:
                    try
                    {
                        smtpServer = "smtp.gmail.com";
                        smtpPort = 587;
                        sslEnabled = true;
                        smtpAccountEmail = "wmoriluca@gmail.com";
                        smtpAccountPassword = "000Benvenuto";
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(" - Creazione oggetto Email Google completo");
                        Console.WriteLine(" - Dispositivo pronto all'invio di posta elettronica con account : " + smtpAccountEmail);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Errore creazione oggetto Email Client, per invio di email con server Google");
                        Console.WriteLine("Codice errore: ");
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case eEmailAccount.Anonimo:
                    try
                    {
                        smtpServer = _smtpServer;
                        smtpPort = _smtpPort;
                        sslEnabled = _sslEnabled;
                        smtpAccountEmail = _smtpAccountEmail;
                        smtpAccountPassword = _smtpAccountPassword;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(" - Creazione oggetto Email Anonime Completato.");
                        Console.WriteLine(" - Dispositivo pronto all'invio di posta elettronica con account : " + smtpAccountEmail);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Errore creazione oggetto Email Client, per invio di email da un server non standard.");
                        Console.WriteLine("Codice errore: ");
                        Console.WriteLine(ex.Message);
                    }
                    break;

                default:
                    throw new NotImplementedException("Account Di posta Non valido");
                    break;
            } 
        }

        public void SendEmail(string _emailTo, string _object, string _body, bool _isHtml, string _emailFrom = "luca.mori@gidiautomazione.it")
        {
            new Thread(() => EmailWriter
                (
                    _emailTo: _emailTo,
                    _object: _object,
                    _body: _body,
                    _isHtml: _isHtml,
                    _emailFrom: _emailFrom
                ))
                .Start();
        }

        private void EmailWriter(string _emailTo, string _object, string _body, bool _isHtml, string _emailFrom = "luca.mori@gidiautomazione.it")
        {
            //gestire l email di invio
            lock (locker)
            {
                var client = new SmtpClient(smtpServer, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpAccountEmail, smtpAccountPassword),
                    EnableSsl = sslEnabled,
                };
                mailMessage = new MailMessage(_emailFrom, _emailTo, _object, _body);
                mailMessage.IsBodyHtml = _isHtml;
                client.Send(mailMessage);
                client.Dispose();
                mailMessage.Dispose();
            }
        }
    }
}
