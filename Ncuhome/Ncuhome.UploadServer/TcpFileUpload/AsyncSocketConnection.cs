using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Ncuhome.TcpFileUpload
{
    class AsyncSocketConnection
    {
        private Socket _socket;
        public AsyncSocketConnection(Socket socket)
        {
            this._socket = socket;
        }

    }
}
