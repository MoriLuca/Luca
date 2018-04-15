using System;
using System.Collections.Generic;
using System.Text;

namespace Luca.Logs
{
    public interface ILogger
    {
        string LogFolder { get; set; }
        bool WriteLog(string txt);
    }
}
