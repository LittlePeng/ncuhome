using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.IO;

namespace Ncuhome.Chat.SimpleHttpProtocol
{
    public class CometHttpRequest
    {
        private Encoding _ContentEncoding;
        public Encoding ContentEncoding { get { return _ContentEncoding; } }

        private int _ContentLength;
        public int ContentLength { get { return _ContentLength; } }

        private CookieCollection _Cookies;
        public CookieCollection Cookies { get { return _Cookies; } }

        private NameValueCollection _Form;
        public NameValueCollection Form { get { return _Form; } }

        private bool _KeepLive;
        public bool KeepLive { get { return _KeepLive; } }

        private NameValueCollection _Header;
        public NameValueCollection Header { get { return _Header; } }

        private string _HttpMethod;
        public string HttpMethod { get { return _HttpMethod; } }

        private Stream _InputStream;
        public Stream InputStream { get { return _InputStream; } }

        private Version _ProtocolVersion;
        public Version ProtocolVersion { get { return _ProtocolVersion; } }

        private Uri _Url;
        public Uri Url { get { return _Url; } }
    }
}
