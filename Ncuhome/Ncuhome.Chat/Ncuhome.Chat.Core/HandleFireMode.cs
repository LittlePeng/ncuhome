using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Chat.Core
{
    /// <summary>
    /// 连接抽发模式
    /// </summary>
    public  enum HandleFiredMode
    {
        NewPostEvent //新的数据时触发，在数据量小的时候好，可批量处理
            ,polling //定时轮询，在聊天数量大的时候好
    }
}
