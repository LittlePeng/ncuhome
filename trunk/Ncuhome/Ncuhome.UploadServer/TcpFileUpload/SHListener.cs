using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Ncuhome.TcpFileUpload
{
    class SHListener:ISHListener
    {

        public event SHConnectionCreatedHandler ConnectionCreated;

        private AsyncSocketListener asyncListener;
        public IPEndPoint localEp { get; set; }

        public SHListener(IPEndPoint EP)
        {
            if (EP == null) { throw new NullReferenceException("localEp is null!"); }
            asyncListener = new AsyncSocketListener();
            this.localEp = EP;

            asyncListener.SocketConnectioned += new SocketConnectionedHandle(asyncListener_SocketConnectioned);
        }

        void asyncListener_SocketConnectioned(object sender, SocketConnectionEventArgs e)
        {
            if (this.ConnectionCreated != null)
            {
                SHSocket sh = new SHSocket(e.Socket);
                SHConnectionCreatedEventArgs evenArgs=new SHConnectionCreatedEventArgs();
                evenArgs.Bind(sh);

                this.ConnectionCreated(sender, evenArgs);
            }
        }

        public void Listen()
        {
            this.asyncListener.Listen(localEp);
        }

        public void Stop()
        {
            this.asyncListener.Stop();
        }
    }
}
