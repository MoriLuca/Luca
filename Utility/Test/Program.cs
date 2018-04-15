using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Test
{
    class Program
    {
        static Luca.EmailConfiguration conf = new Luca.EmailConfiguration();
        static MimeKit.MimeMessage ma = new MimeKit.MimeMessage();
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //    conf.SmtpServer = "smtp.gmail.com";
        //    conf.SmtpPort = 465;
        //    conf.SmtpUsername = "wmori.luca@gmail.com";
        //    conf.SmtpPassword = "plOK12@#@#";
        //    #region sendEmail
        //    try
        //    {
        //        Luca.EmailService s = new Luca.EmailService(conf);
        //        List<Luca.EmailAddress> l = new List<Luca.EmailAddress>()
        //        {
        //            new Luca.EmailAddress()
        //            {
        //                Name = "Robot Poliplast",
        //                Address = "Robottino@Poliplast.com"
        //            }
        //        };
        //        List<Luca.EmailAddress> lt = new List<Luca.EmailAddress>()
        //        {
        //            new Luca.EmailAddress()
        //            {
        //                Name = "Luca Mori",
        //                Address = "luca.mori@gidiautomazione.it"
        //            }
        //        };

        //        Luca.EmailMessage m = new Luca.EmailMessage()
        //        {
        //            Subject = "NuovoPezzoProdotto",
        //            Content = "<h1>Prodotto nuovo Pezzo</h1>" +
        //                $"<p>Orario : {DateTime.Now}</p>" +
        //                $"<p>Stazione : DX</p>" +
        //                $"<p>TempoLavorazione : 52</p>",
        //            FromAddresses = l,
        //            ToAddresses = lt
        //        };

        //        s.Send(m);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Errore invio email Produzione : " + ex.Message);
        //    }
        //    Console.ReadLine();
        //    #endregion
        //}
        static void Main(string[] args)
        {
            conf.SmtpServer = "smtp.gmail.com";
            conf.SmtpPort = 465;
            conf.SmtpUsername = "wmori.luca@gmail.com";
            conf.SmtpPassword = "plOK12@#@#";
            #region sendEmail
            try
            {
                Luca.EmailService s = new Luca.EmailService(conf);
                List<Luca.EmailAddress> l = new List<Luca.EmailAddress>()
                 {
                     new Luca.EmailAddress()
                     {
                         Name = "Raspberry Pi Home",
                         Address = "RaspyPi@Home.it"
                     }
                 };
                List<Luca.EmailAddress> lt = new List<Luca.EmailAddress>()
                 {
                     new Luca.EmailAddress()
                     {
                         Name = "Luca Mori",
                         Address = "luca.mori@gidiautomazione.it"
                     }
                 };

                Luca.EmailMessage m = new Luca.EmailMessage()
                {
                    Subject = "I miei indirizzi ip",
                    FromAddresses = l,
                    ToAddresses = lt
                };

                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "ipconfig",
                        Arguments = null,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    m.Content += proc.StandardOutput.ReadLine();
                }
                s.Send(m);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore invio email Produzione : " + ex.Message);
            }
            #endregion

            Console.ReadLine();

        }
    }
}
