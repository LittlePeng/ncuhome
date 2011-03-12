using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Ncuhome.Chat.SimpleHttpProtocol
{
    /// <summary>
    /// 代表依次http连接会话
    /// </summary>
    internal class CometHttpSession :IDisposable
    {
        public Socket SessionSocket;

        public CometHttpSession(Socket socket,HttpServerSetting setting)
        {
            SessionSocket = socket;
        }

        public void Dispose()
        {
            SessionSocket.Close();
        }
    }
}
