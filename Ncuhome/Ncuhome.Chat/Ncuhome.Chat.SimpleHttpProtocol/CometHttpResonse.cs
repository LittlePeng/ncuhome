using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.IO;

namespace Ncuhome.Chat.SimpleHttpProtocol
{
    public  class CometHttpResonse
    {
        #region Http Description
        public const string HTTP_REASON_CONTINUE = "Continue";
        public const string HTTP_REASON_SWITCHING_PROTOCOLS = "Switching Protocols";
        public const string HTTP_REASON_OK = "OK";
        public const string HTTP_REASON_CREATED = "Created";
        public const string HTTP_REASON_ACCEPTED = "Accepted";
        public const string HTTP_REASON_NONAUTHORITATIVE = "Non-Authoritative Information";
        public const string HTTP_REASON_NO_CONTENT = "No Content";
        public const string HTTP_REASON_RESET_CONTENT = "Reset Content";
        public const string HTTP_REASON_PARTIAL_CONTENT = "Partial Content";
        public const string HTTP_REASON_MULTIPLE_CHOICES = "Multiple Choices";
        public const string HTTP_REASON_MOVED_PERMANENTLY = "Moved Permanently";
        public const string HTTP_REASON_FOUND = "Found";
        public const string HTTP_REASON_SEE_OTHER = "See Other";
        public const string HTTP_REASON_NOT_MODIFIED = "Not Modified";
        public const string HTTP_REASON_USEPROXY = "Use Proxy";
        public const string HTTP_REASON_TEMPORARY_REDIRECT = "Temporary Redirect";
        public const string HTTP_REASON_BAD_REQUEST = "Bad Request";
        public const string HTTP_REASON_UNAUTHORIZED = "Unauthorized";
        public const string HTTP_REASON_PAYMENT_REQUIRED = "Payment Required";
        public const string HTTP_REASON_FORBIDDEN = "Forbidden";
        public const string HTTP_REASON_NOT_FOUND = "Not Found";
        public const string HTTP_REASON_METHOD_NOT_ALLOWED = "Method Not Allowed";
        public const string HTTP_REASON_NOT_ACCEPTABLE = "Not Acceptable";
        public const string HTTP_REASON_PROXY_AUTHENTICATION_REQUIRED = "Proxy Authentication Required";
        public const string HTTP_REASON_REQUEST_TIMEOUT = "Request Time-out";
        public const string HTTP_REASON_CONFLICT = "Conflict";
        public const string HTTP_REASON_GONE = "Gone";
        public const string HTTP_REASON_LENGTH_REQUIRED = "Length Required";
        public const string HTTP_REASON_PRECONDITION_FAILED = "Precondition Failed";
        public const string HTTP_REASON_REQUESTENTITYTOOLARGE = "Request Entity Too Large";
        public const string HTTP_REASON_REQUESTURITOOLONG = "Request-URI Too Large";
        public const string HTTP_REASON_UNSUPPORTEDMEDIATYPE = "Unsupported Media Type";
        public const string HTTP_REASON_REQUESTED_RANGE_NOT_SATISFIABLE = "Requested Range Not Satisfiable";
        public const string HTTP_REASON_EXPECTATION_FAILED = "Expectation Failed";
        public const string HTTP_REASON_INTERNAL_SERVER_ERROR = "Internal Net.HTTP Error";
        public const string HTTP_REASON_NOT_IMPLEMENTED = "Not Implemented";
        public const string HTTP_REASON_BAD_GATEWAY = "Bad Gateway";
        public const string HTTP_REASON_SERVICE_UNAVAILABLE = "Service Unavailable";
        public const string HTTP_REASON_GATEWAY_TIMEOUT = "Gateway Time-out";
        public const string HTTP_REASON_VERSION_NOT_SUPPORTED = "HTTP Version not supported";
        public const string HTTP_REASON_UNKNOWN = "???";
        public const string DATE = "Date";
        public const string SET_COOKIE = "Set-Cookie";
        #endregion

        public Encoding ContentEncoding { get; set; }

        public int ContentLength { get; set; }

        public CookieCollection Cookies { get; set; }

        public NameValueCollection Header { get; set; }

        public bool KeepAlive { get; set; }
        public Stream OutputStream { get; set; }
   
        public string RedirectLocation { get; set; }
     
        public bool SendChunked { get; set; }
  
        public int StatusCode { get; set; }
      
        public string StatusDescription { get; set; }

        public string HttpMethod { get; set; }

        public Stream OutStream { get; set; }

        public Version ProtocolVersion { get; set; }

        public void AddHeader(string name, string value)
        {
            this.Header.Add(name, value);
        }

        public void AddCookie(string name, string value)
        { 
        
        }

        public void Close()
        { 
        
        }

        public void Write(Byte[] bt)
        { 
        
        }
    }
}
