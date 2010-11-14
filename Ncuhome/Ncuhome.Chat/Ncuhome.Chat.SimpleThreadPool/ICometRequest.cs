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

        bool IsFetchedMessage { get; set; }
    }
}
