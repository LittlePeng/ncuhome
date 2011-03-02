using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.TcpFileUpload
{
    public interface ISHListener
    {
        event SHConnectionCreatedHandler ConnectionCreated;

        void Listen();
        void Stop();
    }
}
