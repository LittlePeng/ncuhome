using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Chat.Model;
using System.Threading;

namespace Ncuhome.Chat.SimpleThreadPool
{
    /// <summary>
    /// 聊天会话
    /// </summary>
    public interface IChatSessionManager
    {
        /// <summary>
        /// 公聊
        /// </summary>
        bool DoChatSession(ICometRequest cometRequest, ChatMessageModel[] messages, FinishCallback cb);
    }
}
