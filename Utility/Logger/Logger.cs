using System;
using System.IO;

namespace Luca.Logs
{
    public class Logger : ILogger
    {
        #region Properties
        // Set a variable to the My Documents path.
        // Questa path punta alla cartella roaming dell user corrente
        private string _logPath { get; } =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        //Proprietà che puà essere modificata per poter scrivere logs in cartelle diverse
        public string LogFolder
        {
            get
            {
                return LogFolder;
            }
            set
            {
                LogFolder = _logPath + value.Trim();
            }
        }
        #endregion

        #region Methods
        //Create the log folder if it doesent already exist
        private void CreateFolderIfDoesentExists()
        {
            if (!Directory.Exists(LogFolder))
            {
                Console.WriteLine("The Logs Folder doesent exist. It will be created.");
            }
            Directory.CreateDirectory(LogFolder);
        }

        /// <summary>
        /// Log an error adding the current data by default
        /// </summary>
        /// <param name="txt"></param>
        public bool WriteLog(string txt)
        {
            //creazione cartella log, se non esiste
            try
            {
                CreateFolderIfDoesentExists();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossibile creare la cartella per log. "+ex.Message);
                return false;
            }
            
            //Scrittura log
            try
            {
                // Tested, it can write on an already opened file.
                // Write the string array to a new file.
                using (StreamWriter outputFile =
                    new StreamWriter(LogFolder + $@"\{DateTime.Today.ToString("dd_MM_yy) ")}Logs.txt", true))
                {
                    outputFile.WriteLine(DateTime.Now + ": " + txt);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on Log Writing : " + ex.Message);
                return false;
            }

        }
        #endregion

    }
}
