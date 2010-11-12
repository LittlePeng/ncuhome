using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Chat.Model;

namespace Ncuhome.Chat.IISChatServer
{
    public class ChatSessionManager
    {
        /// <summary>
        /// 先只实现群聊
        /// </summary>
        /// <param name="result"></param>
        /// <param name="messages"></param>
        /// <param name="finishCallback"></param>
        /// <param name="timeOutFinishCallback"></param>
        public void HandleSession(CometAsyncResult result, IEnumerable<ChatMessageModel> messages, FinishHandler finishCallback, FinishHandler timeOutFinishCallback)
        {
            var newMessages = messages.Where(p => p.Id > result.Request.lastId);
            if (newMessages.Count() > 0)
            {
                result.Response.Message = newMessages;
                finishCallback(result);
                return;
            }

            //如果超时即刻返回
            timeOutFinishCallback(result);
        }
    }
}
