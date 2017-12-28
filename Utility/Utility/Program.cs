using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    class Program
    {
        ///Per la gestione del database
        //private static DB.DBManager _manager = new DB.DBManager(debugMode:true);
        //private static List<DBTest.nomi> _listaNomi = new List<DBTest.nomi>();

        //static void Main(string[] args)
        //{
        //    Console.WriteLine(_manager.DatabaseState);

        //    //_manager.WriteOneName("farro");
        //    if (_manager.ReadNomi(out _listaNomi))
        //    {
        //        foreach (var item in _listaNomi)
        //        {
        //            Console.WriteLine(item.nome);
        //        }
        //        Console.Read();
        //    }
        //}


        ///Gestione plc omron con compolet
        static void Main(string[] args)
        {
            NJ.Plc plc = new NJ.Plc();
            plc.x();
            Console.Read();
        }
    }
}
