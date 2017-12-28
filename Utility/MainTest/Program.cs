using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //********************************************************************************
            // Esempio Email utilizzando il server di google con account wmoriluca
            //********************************************************************************
            L_Email.EmailSender emailSender1 = new L_Email.EmailSender(L_Email.EmailSender.eEmailAccount.LucaGoogleMail);
            emailSender1.SendEmail(_emailTo: "luca.mori@gidiautomazione.it",
                                   _object: "soggetto email",
                                   _body: "corpo dell email",
                                   _isHtml: false);

            //--------------------------------------------------------------------------------




            //********************************************************************************
            // Esempio Email utilizzando il server register con account luca.mori
            //********************************************************************************
            L_Email.EmailSender emailSender2 = new L_Email.EmailSender(L_Email.EmailSender.eEmailAccount.LucaGiDiAutomazione);
            emailSender2.SendEmail(_emailTo: "luca.mori@gidiautomazione.it",
                                   _object: "soggetto email",
                                   _body: "corpo dell email",
                                   _isHtml: false);

            //--------------------------------------------------------------------------------




            //********************************************************************************
            // Esempio Email utilizzando un server deciso dall' utente
            //********************************************************************************
            L_Email.EmailSender emailSender3 = new L_Email.EmailSender(
                L_Email.EmailSender.eEmailAccount.Anonimo,
                _smtpServer: "authsmtp.register.it",
                _smtpAccountEmail: "luca.mori@gidiautomazione.it",
                _smtpPort: 587,
                _sslEnabled: false,
                _smtpAccountPassword: "000BenvenutoWork"
                );

            emailSender3.SendEmail(
                _emailFrom: "mazzetta@amedeo.com",
                _emailTo: "luca.mori@gidiautomazione.it",
                _object: "soggetto email",
                _body: "corpo dell email",
                _isHtml: false
                );

            //--------------------------------------------------------------------------------
        }
    }
}
