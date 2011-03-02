using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace Ncuhome.TcpFileUpload
{
    public class AsyncSocketListener
    {
        public event SocketConnectionedHandle SocketConnectioned;
        private Socket listenSocket;
        //TCP bufferSize (K)
        private int bufferSize=8;
        private object syncRoot = new object();

        public AsyncSocketListener() { }
        public AsyncSocketListener(int socketBufferSize) { this.bufferSize = socketBufferSize; }

        protected void BeginAccept()
        {
            if (this.listenSocket == null) { throw new NullReferenceException("socket is null"); }

            this.listenSocket.BeginAccept((result) =>
            {
                Socket s = result.AsyncState as Socket;
                try
                {
                    Socket sb= s.EndAccept(result);

                    if (sb == null)
                    {
                        Trace.WriteLine("sb is null");
                        return;
                    }

                    sb.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, bufferSize * 1024);
                    sb.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, bufferSize * 1024);
                    
                    SocketConnectionEventArgs scArgs = new SocketConnectionEventArgs();
                    scArgs.Bind(this.listenSocket);

                    if (this.SocketConnectioned != null)
                    {
                        this.SocketConnectioned(this.listenSocket, scArgs);
                    }
                }
                catch(Exception e)
                {
                    Trace.WriteLine(e.ToString());
                }

                try
                {
                    lock (syncRoot)
                    {
                        if (this.listenSocket != null)
                        {
                            this.BeginAccept();
                        }
                    }
                }
                catch
                {
                    this.Stop();
                    throw;
                }

            }, this.listenSocket);
        }

        public void Listen(IPEndPoint localEP)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(localEP);
            try
            {
                s.Listen(10);
            }
            catch
            {
                s.Close();
                throw;
            }

            this.listenSocket = s;
        }

        public void Stop()
        {
            Socket s = this.listenSocket;
            if (s != null)
            {
                lock (syncRoot)
                {
                    this.listenSocket = null;
                }

                s.Close();
            }
        }
    }
}
