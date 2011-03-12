using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Ncuhome.Chat.SimpleHttpProtocol
{
    /// <summary>
    /// 简单用户长连接Http Host
    /// </summary>
    public class CometHttpListener
    {
        private Socket CometSocket;
        private HttpServerSetting Setting;

        public CometHttpListener(int port)
            :this(port,HttpServerSetting.Default){  }

        public CometHttpListener(int port,HttpServerSetting setting)
        {
            this.Setting = setting;
            this.CometSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.CometSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        public void Start()
        {
            CometSocket.Listen(1000 * 1000);
        }

        /// <summary>
        /// 开始接受请求
        /// </summary>
        public void BeginGetContext()
        {
            CometSocket.BeginAccept(new AsyncCallback(EndAccept), null);
        }

        private void EndAccept(IAsyncResult result)
        {
          Socket request=  CometSocket.EndAccept(result);
          using (CometHttpSession session = new CometHttpSession(request,Setting))
          { 
          
          }
           // request.BeginReceive(
        }
        /// <summary>
        /// 结束接受请求
        /// </summary>
        public CometHttpContent EndGetContext(IAsyncResult result)
        {
            return new CometHttpContent();
        }

        public CometHttpContent GetContext()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        public void Stop()
        {
            CometSocket.Close();
        }
    }
}
