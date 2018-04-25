using System;
using System.Net;
using PlcInterface;

namespace Siemens
{
    public class PLC : PlcInterface.IPlc
    {
        #region Properties
        private S7.Net.Plc _plc;

        /// <summary>
        /// Variable that should be contisuosly checked to see if the plc is socket is connected and available
        /// </summary>
        public bool Connecetd => _plc.IsConnected;
        /// <summary>
        /// Return True If a connection To the Plc Can be Established
        /// </summary>
        public bool Available => _plc.IsAvailable;


        public string PlcName => _plc.ToString();
        public string iPAddress => _plc.IP;
        public int Port { get; }
        public int Node { get; }

        IPAddress IPlc.iPAddress => throw new NotImplementedException();

        public int Slot => _plc.Slot;
        #endregion

        #region Constructor
        public PLC(S7.Net.CpuType cpuType, IPAddress iPAddress, short rack, short slot)
        {
            string ip = iPAddress.ToString();
            _plc = new S7.Net.Plc(cpuType, ip, rack, slot);
        }
        #endregion

        public bool AnswerBack()
        {
            throw new NotImplementedException();
        }

        public bool CloseConnection()
        {
            throw new NotImplementedException();
        }

        public bool OnCommandRecived()
        {
            throw new NotImplementedException();
        }

        public bool OpenConnetion()
        {
            if (_plc.co)
        }

        public bool? ReadBool(int Area, int MemoryAddress, int offset)
        {
            throw new NotImplementedException();
        }

        public byte ReadByte(int Area, int MemoryAddress, int offset)
        {
            throw new NotImplementedException();
        }

        public byte[] ReadByteArray(int Area, int MemoryAddress, int offset, int Count)
        {
            throw new NotImplementedException();
        }

        public char? ReadChar(int Area, int MemoryAddress, int offset)
        {
            throw new NotImplementedException();
        }

        public byte[] ReadDoubleWord(int Area, int MemoryAddress, int offset)
        {
            throw new NotImplementedException();
        }

        public short? ReadInt16(int Area, int MemoryAddress, int offset)
        {
            throw new NotImplementedException();
        }

        public int? ReadInt32(int Area, int MemoryAddress, int offset)
        {
            throw new NotImplementedException();
        }

        public long? ReadInt64(int Area, int MemoryAddress, int offset)
        {
            throw new NotImplementedException();
        }

        public string ReadString(int Area, int MemoryAddress, int offset)
        {
            throw new NotImplementedException();
        }

        public ushort? ReadU_Int16(int Area, int MemoryAddress, int offset)
        {
            throw new NotImplementedException();
        }

        public uint? ReadU_Int32(int Area, int MemoryAddress, int offset)
        {
            throw new NotImplementedException();
        }

        public ulong? ReadU_Int64(int Area, int MemoryAddress, int offset)
        {
            throw new NotImplementedException();
        }

        public byte[] ReadWord(int Area, int MemoryAddress, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
