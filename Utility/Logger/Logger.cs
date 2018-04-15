using System;
using System.IO;

namespace Luca
{
    public class Logger
    {
        // Set a variable to the My Documents path.
        // Questa path punta alla cartella roaming dell user corrente
        private string logPath { get; } =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        #region Contructor
        /// <summary>
        /// Insert the path to store your log.
        /// </summary>
        /// <param name="dirPath">Name of the path to Log from Roaming\</param>
        public Logger(string dirPath)
        {
            this.logPath += dirPath;
            CreateFolderIfDoesentExists();
        }
        #endregion

        #region Methods
        //Create the log folder if it doesent already exist
        private void CreateFolderIfDoesentExists()
        {
            if(!Directory.Exists(logPath))
            {
                Console.WriteLine("The Logs Folder doesent exist. It will be created.");
            }
            Directory.CreateDirectory(logPath);
        }

        /// <summary>
        /// Log an error adding the current data by default
        /// </summary>
        /// <param name="txt"></param>
        public void WriteLog(string txt)
        {
            try
            {
                // Tested, it can write on an already opened file.
                // Write the string array to a new file.
                using (StreamWriter outputFile = 
                    new StreamWriter(this.logPath + $@"\{DateTime.Today.ToString("dd_MM_yy) ")}Logs.txt", true))
                {
                    outputFile.WriteLine(DateTime.Now + ": " + txt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on Log Writing : " + ex.Message);
            }

        }
        #endregion

    }
}
