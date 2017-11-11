using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Utility.DB
{
    class DBManager
    {
        //Lock per la gestione del database
        private object _lock;
        

        public DBManager()
        {

        }

        //creazione istanza database se non esistente
        public bool CreateDatabase()
        {
            lock (_lock)
            {

            }
            return false;
        }

        //lettura di una lista
        public bool lRead()
        {
            lock (_lock)
            {

            }
            return false;
        }

        //scrittura di un nuovo record
        public bool Write()
        {
            lock (_lock)
            {

            }
            return false;
        }
    }
}
