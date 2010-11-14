using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Chat.SimpleThreadPool
{
    public interface ICometRequest
    {
        DateTime BeginTime { get; set; }
        
        void FinishCometRequest();

        /// <summary>
        /// 需要维护此状态，否则请求无法正常释放
        /// </summary>
        bool IsCompeled { get; set; }

        int CometConcurrentCount { get; set; }
    }
}
