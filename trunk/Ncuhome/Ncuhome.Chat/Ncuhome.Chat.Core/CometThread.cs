using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ncuhome.Chat.Core
{
    public class CometThread
    {
        public CometThread()
        {
            CometResult = new LinkedList<CometAsyncResult>();
            ChatThread = new Thread(new ThreadStart(CometThreadStart));
        }

        public void CometThreadStart()
        {
            while (true)
            {
                foreach (CometAsyncResult c in CometResult)
                {
                    c.CallBack(c);
                }
            }
        }

        private Thread ChatThread;
        public LinkedList<CometAsyncResult> CometResult;
    }
}
