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
        private bool _debugMode;

        //public properies
        private string _databaseState;
        public string DatabaseState { get => _databaseState; }


        public DBManager(bool debugMode = false)
        {
            _lock = new object();
            _debugMode = debugMode;
            CheckDBState();
        }

        //Verifica stato del DB
        public bool CheckDBState()
        {
            lock (_lock)
            {
                try
                {
                    using (var context = new DBTest.lucaEntities())
                    {
                        if (context.Database.Exists())
                        {
                            context.Database.Connection.Open();
                            context.Database.Connection.Close();
                            int? timeOut = context.Database.CommandTimeout;
                            _databaseState = "Database Found.\nConnection is availabe.\n";
                            _databaseState += $"Server Name\t: {context.Database.Connection.DataSource}\n";
                            _databaseState += $"Database Name\t: {context.Database.Connection.Database}\n";
                            
                            return true;
                        }
                        else
                        {
                            _databaseState = "Database Not Found!";
                            return false;
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    //Reading from the table wasnt possible
                    //Display a message if debug mode is on
                    if (_debugMode) Console.WriteLine(ex.Message);
                    return false;
                }
            }

        }

        //lettura di una lista di nomi
        public bool ReadNomi(out List<DBTest.nomi> list)
        {

            lock (_lock)
            {
                try
                {
                    using (var context = new DBTest.lucaEntities())
                    {
                        list = context.nome.ToList();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    //Reading from the table wasnt possible
                    //Display a message if debug mode is on
                    if (_debugMode) Console.WriteLine(ex.Message);
                    list = null;
                    return false;
                }

            }
        }

        //scrittura di un nuovo record 
        public bool WriteOneName(string name)
        {
            lock (_lock)
            {
                try
                {
                    using (var context = new DBTest.lucaEntities())
                    {
                        context.nome.Add(new DBTest.nomi { nome = name });
                        context.SaveChanges();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    //Reading from the table wasnt possible
                    //Display a message if debug mode is on
                    if (_debugMode) Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
