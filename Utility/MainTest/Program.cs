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
            L_Email.EmailSender_LucaGmail emailSender = new L_Email.EmailSender_LucaGmail();
            emailSender.SendEmail();
        }
    }
}
