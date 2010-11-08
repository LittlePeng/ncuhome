using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Ncuhome.Chat.Core
{
   public   class CometAsyncResult : IAsyncResult
    {
       public CometAsyncResult(int userId,HttpContext  context,AsyncCallback callBack,object asyncState)
       {
           this.UserId = userId;
           this.Context = context;
           this.AsyncState = asyncState;
           this.CallBack = CallBack;
       }

       public void HandlerCometRequest()
       {
           //加入处理队列
           CometThreadPool.QueueCometHandler(this);
       }

       public HttpContext Context { get; set; }

       /// <summary>
       /// 用户Id
       /// </summary>
       public int UserId { get; set; }

       public AsyncCallback CallBack { get; set; }

       public object AsyncState { get; set; }

        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get { throw new NotImplementedException(); }
        }

        public bool CompletedSynchronously
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsCompleted
        {
            get { throw new NotImplementedException(); }
        }
    }
}
