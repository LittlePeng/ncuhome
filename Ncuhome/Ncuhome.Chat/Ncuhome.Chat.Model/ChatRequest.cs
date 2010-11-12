using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Chat.Model
{
    public class ChatRequest
    {
        /// <summary>
        /// 连接标识
        /// </summary>
        public int Identity { get; set; }

        /// <summary>
        /// 最后消息Id
        /// </summary>
        public int lastId { get; set; }
    }
}
