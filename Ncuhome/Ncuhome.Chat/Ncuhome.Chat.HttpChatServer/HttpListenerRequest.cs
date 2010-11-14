using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Ncuhome.Chat.SimpleThreadPool;

namespace Ncuhome.Chat.HttpChatServer
{
    public class HttpCometRequest : ICometRequest
    {
        public DateTime BeginTime { get; set; }

        public bool IsCompeled { get; set; }

        public HttpListenerResponse Response{get;set;}
        public HttpListenerRequest Request { get; set; }
        
        public HttpCometRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            this.Request = request;
            this.Response = response;
        }
        public void FinishCometRequest()
        {
            Response.Close();
        }
    }
}
