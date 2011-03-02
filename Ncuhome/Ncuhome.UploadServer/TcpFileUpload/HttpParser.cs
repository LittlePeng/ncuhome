using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.TcpFileUpload
{
    public abstract class HttpParser
    {
        HttpHeaderBuffer headerBuffer;

        event EventHandler OnHeadParsed;
        event EventHandler OnParsedError;
        event EventHandler OnParsedCompleted;

        public bool TryParserHeader()
        {
            return false;
        }   
    }
}
