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
    public class EmailSender_Client
    {
        private object locker = new object();
        private MailMessage mailMessage;
        private string smtpServer;
        private int smtpPort;
        private bool sslEnabled;
        private string smtpAccountEmail;
        private string smtpAccountPassword;

        public EmailSender_Client(string _smtpServer, int _smtpPort, bool _sslEnabled, string _smtpAccountEmail, string _smtpAccountPassword)
        {
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
        }

        public void SendEmail(string _emailFrom, string _emailTo, string _object, string _body, bool _isHtml)
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
            lock (locker)
            {
                var client = new SmtpClient("authsmtp.register.it", 587)
                {
                    Credentials = new NetworkCredential("luca.mori@gidiautomazione.it", "000BenvenutoWork"),
                    EnableSsl = false,
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
