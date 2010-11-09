using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Ncuhome.Chat.Core
{
    public class CometHandler:IHttpAsyncHandler
    {

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            //异步请求将请求放入自定义线程池内,由消息抽发或者定时轮询处理
            //Chunked很难处理浏览器未加载完问题，暂时不做，有消息即返回
            CometAsyncResult result = new CometAsyncResult(1,context, cb, extraData);
            result.HandleCometRequest();
            return result;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            //在有消息或者是超时 内部线程池调用Callback，Asp.Net将调用这里处理结束
            CometAsyncResult cometResult = result as CometAsyncResult;
            cometResult.Context.Response.Write("{\"d\":\"\",\"message\":\"time out!\"}");
        }

        #region
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
