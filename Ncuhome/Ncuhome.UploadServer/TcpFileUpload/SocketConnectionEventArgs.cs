using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Ncuhome.TcpFileUpload
{
    class SocketConnectionEventArgs : EventArgs
    {
        private Socket _socket;
        public Socket Socket { get { return _socket; } }

        public void Bind(Socket socket)
        {
            this._socket = socket;
        }
    }
}
