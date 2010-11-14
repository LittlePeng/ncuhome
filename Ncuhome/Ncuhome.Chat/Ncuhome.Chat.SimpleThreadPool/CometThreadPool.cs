using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Ncuhome.Chat.Model;

namespace Ncuhome.Chat.SimpleThreadPool
{
    public static class CometThreadPool
    {
        #region Thread
        //最大工作线程
        public const int MaxThreadCount = 10;
        //默认工作线程，处理程序为CPU密集操作，默认与cpu核心数相同即可
        public const int DefaultThreadCount = 2;

        public static int ThreadCount { get; set; }

        internal static CometThread[] CometThreads;

        /// <summary>
        /// 启动线程池，注册会话处理对象
        /// </summary>
        public static void Start(IChatSessionManager sessionManager)
        {
            Start(DefaultThreadCount, sessionManager);
        }

        /// <summary>
        /// 启动线程池，注册会话处理对象
        /// </summary>
        public static void Start(int threadCount, IChatSessionManager sessionManager)
        {
            if (threadCount < MaxThreadCount && threadCount > 0)
            {
                ThreadCount = threadCount;
            }
            else
            {
                ThreadCount = DefaultThreadCount;
            }

            CometThreads = new CometThread[ThreadCount];
            for (int i = 0; i < ThreadCount; i++)
            {
                CometThreads[i] = new CometThread(sessionManager);
            }
        }
        #endregion

        #region Handler
        private static object SyncRoot = new object();

        private static int AssignRequestThreadIndex = 0;

        /// <summary>
        /// 处理消息
        /// </summary>
        public static void HandleMessage(ChatMessageModel message)
        {
            //每个线程各自一份数据
            lock (SyncRoot)
            {
                for (int i = 0; i < ThreadCount; i++)
                {
                    CometThreads[i].HandeChatMessage(message);
                }
            }
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        public static void HandleMessage(IEnumerable<ChatMessageModel> messages)
        {
            //每个线程各自一份数据
            lock (SyncRoot)
            {
                for (int i = 0; i < ThreadCount; i++)
                {
                    CometThreads[i].HandeChatMessage(messages);
                }
            }
        }

        /// <summary>
        /// 把长连接队列
        /// </summary>
        /// <param name="result"></param>
        public static void QueueCometRequest(ICometRequest result)
        {
            lock (SyncRoot)
            {
                if (AssignRequestThreadIndex == ThreadCount)
                {
                    AssignRequestThreadIndex = 0;
                }
                CometThreads[AssignRequestThreadIndex].EnQueueCometRequest(result);
                AssignRequestThreadIndex++;
            }
        }
        #endregion
    }
}
