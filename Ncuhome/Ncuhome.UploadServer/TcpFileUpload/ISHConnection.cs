using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.TcpFileUpload
{
    public interface ISHConnection
    {
        event EventHandler OnDisConnection;
        event EventHandler OnReceived;
        void Close();
        void SendResponse(string resp);
    }
}
