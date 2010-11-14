using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Chat.SimpleThreadPool;

namespace Ncuhome.Chat.HttpChatServer
{
    public class ChatSessionManager:IChatSessionManager
    {
        public void DoChatSession(ICometRequest cometRequest,IEnumerable< Ncuhome.Chat.Model.ChatMessageModel> messages, FinishCallback cb)
        {
            HttpCometRequest request = cometRequest as HttpCometRequest;
            string str="asdfasdf";
            byte[] byt=Encoding.UTF8.GetBytes(str);
            request.Response.OutputStream.Write(byt, 0, byt.Length);
            
            request.IsCompeled = true;
            if (cb != null)
                cb(cometRequest);
        }
    }
}
