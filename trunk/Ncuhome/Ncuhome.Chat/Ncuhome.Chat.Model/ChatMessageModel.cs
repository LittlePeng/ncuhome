using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Chat.Model
{
     public   class ChatMessageModel
    {
         public int Id { get; set; }
         public int UserIdentity { get; set; }

         public int ToUserIdentity { get; set; }

         public string Content { get; set; }

         public DateTime CreateTime { get; set; }
    }
}
