using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMRON.Compolet;
using OMRON.Compolet.Variable;


namespace Utility.NJ
{
    class Plc
    {
        private OMRON.Compolet.CIP.NJCompolet plc = new OMRON.Compolet.CIP.NJCompolet();

        public void x()
        {
            try
            {
                plc.PeerAddress = "192.168.250.1";
                plc.LocalPort = 2;
                plc.Active = true;
                string[] nomi = plc.VariableNames;
                
                foreach (string item in nomi)
                {
                    Console.WriteLine(item + "\t" + plc.GetVariableInfo(item));
                }
                plc.Active = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
