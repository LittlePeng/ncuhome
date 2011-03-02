using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.TcpFileUpload
{
   public class SHConnectionCreatedEventArgs:EventArgs
    {
        private ISHConnection _connection;
        public ISHConnection Connection { get; }

        public void Bind(ISHConnection connection)
        {
            this._connection = connection;
        }
    }
}
