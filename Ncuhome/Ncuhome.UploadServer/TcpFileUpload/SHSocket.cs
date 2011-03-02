using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Ncuhome.TcpFileUpload
{
    class SHSocket:ISHConnection
    {
        public event EventHandler OnDisConnection;

        public event EventHandler OnReceived;

        private Socket _socket;

        public SHSocket(Socket socket)
        {
            this._socket = socket;
            this.CatchEvent();
        }

        private void CatchEvent()
        { 
        
        }

        public void Close()
        {

        }

        public void SendResponse(string resp)
        {

        }
    }
}
