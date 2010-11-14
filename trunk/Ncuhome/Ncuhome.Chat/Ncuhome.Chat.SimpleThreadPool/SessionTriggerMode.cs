using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Chat.SimpleThreadPool
{
    /// <summary>
    /// 会话触发模式
    /// </summary>
    public enum SessionTriggerMode
    {
        // 事件驱动触发，在数据量小的时候效率高，可批量处理(可考虑将一定时间内一定数量数据一起处理)
        EventTrigger
            // 定时轮询，在聊天数量大的时候效率高
       , Polling
    }
}
