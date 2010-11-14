using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Chat.Model;
using Ncuhome.Chat.SimpleThreadPool;

namespace Ncuhome.Chat.IISChatServer
{
    public class ChatSessionManager : IChatSessionManager
    {
        /// <summary>
        /// 先只实现群聊,返回是否请求到了消息
        /// </summary>
        public bool DoChatSession(ICometRequest cometRequest, ChatMessageModel[] messages, FinishCallback cb)
        {
            CometAsyncResult request = cometRequest as CometAsyncResult;
            var newMessages = messages.Where(p => p.Id > request.Request.lastId);
            if (newMessages.Count() > 0)
            {
                request.Response.Message = newMessages;
                request.IsFetchedMessage = true;
            }
            else
            {
                request.Response.Message =new  List<ChatMessageModel>();
            }

            if(cb!=null)
            cb(cometRequest);

            return request.IsFetchedMessage;
        }
    }
}
