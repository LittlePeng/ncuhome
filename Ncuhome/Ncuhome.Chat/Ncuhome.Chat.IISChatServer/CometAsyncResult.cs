using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Ncuhome.Chat.Model;

namespace Ncuhome.Chat.IISChatServer
{
    public class CometAsyncResult : IAsyncResult
    {
        /// <summary>
        /// 开始处理时间，用于统计超时
        /// </summary>
        public DateTime BeginHandleDateTime { get; set; }

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

        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get { throw new NotImplementedException(); }
        }

        public bool CompletedSynchronously
        {
            get { return false; }
        }

        public bool IsCompleted { get; set; }

        public CometAsyncResult(ChatRequest chatRequest, HttpContext context, AsyncCallback callBack, object asyncState)
        {
            this.Request = chatRequest;
            this.Response = new ChatResponse();
            this.BeginHandleDateTime = DateTime.Now;
            this.Context = context;
            this.AsyncState = asyncState;
            this.CallBack = callBack;
        }

        /// <summary>
        /// 将长连接加入线程池处理
        /// </summary>
        public void HandleCometRequest()
        {
            CometThreadPool.QueueCometHandler(this);
        }

        /// <summary>
        /// 回调，结束长连接
        /// </summary>
        public void FinishCometRequest()
        {
            //回调结束连接
            this.IsCompleted = true;
            if (this.Response.Message == null)
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
