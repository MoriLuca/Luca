using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace L_Email
{
    public class EmailSender_LucaGmail
    {

        private MailMessage mailMessage;

        public void SendEmail()
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("wmoriluca@gmail.com", "000Benvenuto"),
                EnableSsl = true,
            };
            mailMessage = new MailMessage("lucam@gidiautomazione.it", "lucam@gidiautomazione.it","s","sd");
            mailMessage.IsBodyHtml = true;
            client.Send(mailMessage);
            client.Dispose();
            mailMessage.Dispose();
            Console.Read();
        }
    }
}
