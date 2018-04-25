using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PlcInterface
{
    public interface IPlc
    {

        #region Properties
        /// <summary>
        /// Return the state of the connection with the PLC
        /// </summary>
        bool Connecetd { get; }

        /// <summary>
        /// Return where the plc is available for comunication
        /// </summary>
        bool Available { get; }

        /// <summary>
        /// return the plc name
        /// </summary>
        string PlcName { get; }

        /// <summary>
        /// Ip address of the plc
        /// </summary>
        IPAddress iPAddress { get; }

        /// <summary>
        /// Port for plc comunication, if necessary
        /// </summary>
        int Port { get; }

        int Slot { get; }

        /// <summary>
        /// Plc Node, if necessary, for example for Fins Networks
        /// </summary>
        int Node { get; }
        #endregion

        #region Connect/Disconnect
        /// <summary>
        /// Open the connection
        /// </summary>
        /// <returns>True if plc is now connected</returns>
        bool OpenConnetion();

        /// <summary>
        /// Close the comunication
        /// </summary>
        /// <returns>True if the comunication is now closed</returns>
        bool CloseConnection();
        #endregion

        #region Comunication With PLC
        bool? ReadBool(int Area, int MemoryAddress, int offset);
        char? ReadChar(int Area, int MemoryAddress, int offset);
        Int16? ReadInt16(int Area, int MemoryAddress, int offset);
        UInt16? ReadU_Int16(int Area, int MemoryAddress, int offset);

        Int32? ReadInt32(int Area, int MemoryAddress, int offset);
        UInt32? ReadU_Int32(int Area, int MemoryAddress, int offset);

        Int64? ReadInt64(int Area, int MemoryAddress, int offset);
        UInt64? ReadU_Int64(int Area, int MemoryAddress, int offset);

        byte ReadByte(int Area, int MemoryAddress, int offset);
        byte[] ReadWord(int Area, int MemoryAddress, int offset);
        byte[] ReadDoubleWord(int Area, int MemoryAddress, int offset);
        byte[] ReadByteArray(int Area, int MemoryAddress, int offset, int Count);

        string ReadString(int Area, int MemoryAddress, int offset);
        #endregion

        #region Recive Command From Queue
        bool OnCommandRecived();
        #endregion

        #region Send Answer To Queue
        bool AnswerBack();
        #endregion
    }
}
