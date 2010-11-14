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

        public int LastId { get; set; }

        public int CometConcurrentCount { get; set; }

        public HttpListenerResponse Response{get;set;}
        public HttpListenerRequest Request { get; set; }

        public string OutPutMessage { get; set; }
        
        public HttpCometRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            this.Request = request;
            this.Response = response;
            this.BeginTime = DateTime.Now;
        }
        public void FinishCometRequest()
        {
            //if (string.IsNullOrEmpty(OutPutMessage))
            //{
            //    this.OutPutMessage = "Request time Out!";
            //}
            OutPutMessage += "Current Concurrent:"+this.CometConcurrentCount.ToString();
            byte[] byt = Encoding.UTF8.GetBytes(this.OutPutMessage);
            Response.OutputStream.Write(byt, 0, byt.Length);
  
            Response.Close();
        }
    }
}
