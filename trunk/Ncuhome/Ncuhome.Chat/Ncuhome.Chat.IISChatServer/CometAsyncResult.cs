using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Ncuhome.Chat.IISChatServer
{
    public class CometAsyncResult : IAsyncResult
    {

  
        /// <summary>
        /// 开始处理时间，用于统计超时
        /// </summary>
        public DateTime BeginHandleDateTime { get; set; }

        /// <summary>
        /// 处理返回数据
        /// </summary>
        public CometMessageDTO ResponseMessage { get; set; }

         public HttpContext Context { get; set; }

        /// <summary>
        /// 连接标识
        /// </summary>
        public int Identity { get; set; }

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

        public CometAsyncResult(int identity, HttpContext context, AsyncCallback callBack, object asyncState)
        {
            this.BeginHandleDateTime = DateTime.Now;
            this.Identity = Identity;
            this.Context = context;
            this.AsyncState = asyncState;
            this.CallBack = CallBack;
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
            if (CallBack != null)
            {
                CallBack(this);
            }
        }
    }
}
