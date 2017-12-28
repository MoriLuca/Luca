using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MainTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            L_Sharp7.Siemens plc = new L_Sharp7.Siemens("192.168.1.200", (short)0, (short)0);
            while (true)
            {
                Console.SetCursorPosition(0, 3);
                //Console.WriteLine(plc.L_ReadSingleBitFromDB(1, 0, 0));
                plc.L_WriteSingleBitIntoDB(1, 0, 5, (bool)!plc.L_ReadSingleBitFromDB(1, 0, 5));
                Console.WriteLine(Convert.ToString((byte)plc.L_ReadSingleByteFromDB(1, 0), 2).PadLeft(8, '0'));

                if (Console.KeyAvailable)
                    if (Console.ReadKey().Key == ConsoleKey.Q) break;
                Thread.Sleep(300);
            }

        }
    }
}
