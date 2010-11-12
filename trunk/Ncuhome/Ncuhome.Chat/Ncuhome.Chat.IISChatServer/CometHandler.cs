using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Ncuhome.Chat.Model;


namespace Ncuhome.Chat.IISChatServer
{
    public class CometHandler:IHttpAsyncHandler
    {

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            ChatRequest request = new ChatRequest();
            request.Identity = 1;
            int lastId =0;
            if (!string.IsNullOrEmpty(context.Request.QueryString["lastid"]))
            {
                int.TryParse(context.Request.QueryString["lastid"],out lastId);
            }
            request.lastId = lastId;
            //异步请求将请求放入自定义线程池内,由消息抽发或者定时轮询处理
            //Chunked很难处理浏览器未加载完问题，暂时不做，有消息即返回
            CometAsyncResult result = new CometAsyncResult(request,context, cb, extraData);
            result.HandleCometRequest();
            return result;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            //在有消息或者是超时 内部线程池调用Callback，Asp.Net将调用这里处理结束
            CometAsyncResult cometResult = result as CometAsyncResult;
            if (cometResult.Response.IsTimeOut)
            {
                cometResult.Context.Response.Write("{\"d\":\"failure\",\"message\":\"time out!\"}");
            }
            else
            {
                cometResult.Context.Response.Write("{\"d\":\"success!\",\"message\":\receive:"+cometResult.Response.Message.Count().ToString()+"messages;\"}");
            }
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
