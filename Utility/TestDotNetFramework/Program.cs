using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDotNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(Reading).Start();
        }

        public static void Reading()
        {
            Mex mex = new Mex();

            if (!MessageQueue.Exists(@".\Private$\Luca"))
                MessageQueue.Create(@".\Private$\Luca");

            MessageQueue m = new MessageQueue(@".\Private$\Luca");
            m.Formatter = new XmlMessageFormatter(new Type[] {typeof(Mex)});

            while (true)
            {
                mex = (Mex)m.Receive().Body;
                Console.WriteLine($"Nuovo Messaggio : {mex.intero} - {mex.nome}");
            }
        }
    }


    public class Mex
    {
        public int intero { get; set; } = 0;
        public string nome { get; set; } = "Luca";
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Mex mex = new Mex();

    //        if (!MessageQueue.Exists(@".\Private$\Luca"))
    //            MessageQueue.Create(@".\Private$\Luca");

    //        MessageQueue m = new MessageQueue(@".\Private$\Luca");
    //        while (true)
    //        {
    //            Console.Write("Inserire il nome da scrivere : ");
    //            mex.nome = Console.ReadLine();
    //            Console.Write("Inserire il numero intero : ");
    //            mex.intero = Convert.ToInt16(Console.ReadLine());

    //            m.Send(mex, "Mex");
    //        }

    //    }
    //}
}
