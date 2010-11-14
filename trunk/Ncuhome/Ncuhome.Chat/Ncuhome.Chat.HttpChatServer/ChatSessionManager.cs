using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Chat.SimpleThreadPool;
using Ncuhome.Chat.Model;

namespace Ncuhome.Chat.HttpChatServer
{
    public class ChatSessionManager:IChatSessionManager
    {
        public void DoChatSession(ICometRequest cometRequest,IEnumerable<ChatMessageModel> messages, FinishCallback cb)
        {
            HttpCometRequest request = cometRequest as HttpCometRequest;
            string outStr=string.Empty;


            var newMessages = messages.Where(p => p.Id > request.LastId);
            if (newMessages.Count() > 0)
            {
                outStr = newMessages.Count().ToString() + "new message";
                cometRequest.IsCompeled = true;
            }

            request.OutPutMessage = outStr;
          
            if (cb != null)
                cb(cometRequest);
        }
    }
}
