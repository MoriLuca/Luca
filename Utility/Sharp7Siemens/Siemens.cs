using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Sharp7
{
    public class Siemens
    {
        private object locker = new object();
        private byte[] buffer = new byte[66000];
        S7.Net.Plc plc;

        public Siemens(string _ip, short _rack, short _slot)
        {
            plc = new S7.Net.Plc(S7.Net.CpuType.S71200, _ip, _rack, _slot);
            L_PLCOverallStatus();
        }

        public bool? L_ReadSingleBitFromDB(int _dbNumber, int _startByteAddress, int _bitOffsetToRead)
        {
            try
            {
                lock (locker)
                {
                    plc.Open();
                    buffer = plc.ReadBytes(S7.Net.DataType.DataBlock, _dbNumber, _startByteAddress, 1);
                    plc.Close();
                    if ((_bitOffsetToRead < 0) || (_bitOffsetToRead > 7))
                    {
                        throw new ArgumentOutOfRangeException("_bitOffsetToRead ", _bitOffsetToRead, " bitNumber must be 0..7");
                    }

                    return ((buffer[0] & (1 << _bitOffsetToRead)) != 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public byte? L_ReadSingleByteFromDB(int _dbNumber, int _startByteAddress)
        {
            try
            {
                lock (locker)
                {
                    plc.Open();
                    buffer = plc.ReadBytes(S7.Net.DataType.DataBlock, _dbNumber, _startByteAddress, 1);
                    plc.Close();
                    return buffer[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public void L_WriteSingleBitIntoDB(int _dbNumber, int _startByteAddress, int _bitOffsetToWrite, bool _valueToWrite)
        {
            try
            {
                lock (locker)
                {
                    plc.Open();
                    plc.WriteBit(S7.Net.DataType.DataBlock, _dbNumber, _startByteAddress, _bitOffsetToWrite, _valueToWrite);
                    plc.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public string L_PLCOverallStatus(bool _showResponseDialog = true)
        {
            try
            {
                bool available;
                bool connected;
                string cpuInfo;
                string ip;
                string returnMessage = "Operation failed";

                lock (locker)
                {
                    plc.Open();
                    available = plc.IsAvailable;
                    connected = plc.IsConnected;
                    cpuInfo = plc.CPU.ToString();
                    ip = plc.IP;
                    plc.Close();
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("**--------------------------------------------------------------------------------**");
                Console.ForegroundColor = ConsoleColor.Green;
                if (_showResponseDialog)
                {
                    if (available && connected)
                    {
                        returnMessage = $"The PLC {cpuInfo} is Connected and is available at the IP address : {ip}";
                    }
                    else if (connected && !available)
                    {
                        returnMessage = $"The PLC {cpuInfo} is Connected BUT is NOT available at the IP address : {ip}";
                    }
                    else
                    {
                        returnMessage = "Error, NO PLC Comunication";
                    }
                    Console.WriteLine("  " + returnMessage);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("**--------------------------------------------------------------------------------**");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                return returnMessage;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
