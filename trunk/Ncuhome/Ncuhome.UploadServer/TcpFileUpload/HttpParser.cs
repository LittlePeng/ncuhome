using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.TcpFileUpload
{
    public abstract class HttpParser
    {
        HttpHeaderBuffer headerBuffer;

        const int headerMaxLength = 8 * 1024;

        event EventHandler OnHeaderParsed;
        event EventHandler OnParsedError;
        event EventHandler OnParsedCompleted;

        public bool TryParserHeader()
        {
            return false;
        }   
    }
}
