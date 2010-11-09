using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Ncuhome.Chat.Model;

namespace Ncuhome.Chat.Core
{
    public static class CometThreadPool
    {
        //最大工作线程
        public const int MaxThreadCount = 10;
        //默认工作线程，处理程序为全CPU操作，默认与cpu核心数相同
        public const int DefaultThreadCount = 2;

        public static CometThread[] CometThreads;

        public static void Start()
        {
            Start(DefaultThreadCount);
        }

        public static void Start(int ThreadCount)
        {
            ThreadsCount = ThreadCount;
            CometThreads = new CometThread[ThreadCount];
            for (int i = 0; i < ThreadCount; i++)
            {
                CometThreads[i] = new CometThread();
            }
        }

        private static object SyncRoot = new object();

        private static int AssignThreadIndex = 0;
        
        public static int ThreadsCount { get; set; }

        public static void HandleMessage(ChatMessage message)
        {
            lock (SyncRoot)
            {
                for (int i = 0; i < ThreadsCount; i++)
                {
                    CometThreads[i].HandeNewMessage(message);
                }
            }
        }

        /// <summary>
        /// 把长连接队列
        /// </summary>
        /// <param name="result"></param>
        public static void QueueCometHandler(CometAsyncResult result)
        {
            lock (SyncRoot)
            {
                if (AssignThreadIndex == ThreadsCount)
                {
                    AssignThreadIndex = 0;
                }
                CometThreads[AssignThreadIndex].EnQueueCometHandler(result);
                AssignThreadIndex++;
            }
        }
    }
}
