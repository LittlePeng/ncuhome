using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Ncuhome.Chat.Model;
using Ncuhome.Chat.SimpleThreadPool;

namespace Ncuhome.Chat.IISChatServer
{
    public class CometAsyncResult : IAsyncResult,ICometRequest
    {
        /// <summary>
        /// 开始处理时间，用于统计超时
        /// </summary>
        public DateTime BeginTime { get; set; }

        public int CometConcurrentCount { get; set; }

        /// <summary>
        ///请求数据
        /// </summary>
        public ChatRequest Request { get; set; }

        /// <summary>
        /// 相应数据
        /// </summary>
        public ChatResponse Response { get; set; }

         public HttpContext Context { get; set; }

        public AsyncCallback CallBack { get; set; }

        public object AsyncState { get; set; }
           
        bool ICometRequest.IsCompeled{get;set;}

        bool IAsyncResult.IsCompleted { get{return false;} }

        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get { throw new NotImplementedException(); }
        }

        public bool CompletedSynchronously
        {
            get { return false; }
        }

        public CometAsyncResult(ChatRequest chatRequest, HttpContext context, AsyncCallback callBack, object asyncState)
        {
            this.Request = chatRequest;
            this.Response = new ChatResponse();
            this.BeginTime = DateTime.Now;
            this.Context = context;
            this.AsyncState = asyncState;
            this.CallBack = callBack;
        }

        /// <summary>
        /// 将长连接加入线程池处理
        /// </summary>
        public void HandleCometRequest()
        {
            CometThreadPool.QueueCometRequest(this);
        }

        /// <summary>
        /// 回调，结束长连接
        /// </summary>
        public void FinishCometRequest()
        {
            //回调结束连接
            if (this.Response.Message.Count() == 0)
            {
                this.Response.IsTimeOut = true;
            }

            if (CallBack != null)
            {
                CallBack(this);
            }
        }

        
    }
}
