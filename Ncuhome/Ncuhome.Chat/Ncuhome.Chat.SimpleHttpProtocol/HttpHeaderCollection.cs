using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace Ncuhome.Chat.SimpleHttpProtocol
{
    public class HttpHeaderCollection: List<HttpHeader>
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(512);
            foreach (HttpHeader h in this)
            {
                sb.Append(h.Name);
                sb.Append(':');
                sb.Append(h.Value);
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
