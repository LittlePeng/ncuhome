using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Chat.Model
{
     public   class ChatMessage
    {
         public int UserIdentity { get; set; }
         public int ToUserIdentity { get; set; }
         public string Content { get; set; }
    }
}
