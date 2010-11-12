using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Chat.Model
{
    public class ChatResponse
    {
        public IEnumerable<ChatMessageModel> Message { get; set; }

        public bool IsTimeOut { get; set; }
    }
}
