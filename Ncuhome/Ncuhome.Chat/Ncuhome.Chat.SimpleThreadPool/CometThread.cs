using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Ncuhome.Chat.Model;

namespace Ncuhome.Chat.SimpleThreadPool
{
    internal class CometThread
    {
        #region property
        //兼容浏览器，超时应为20s
        private const int RequestTimeOut = 5;
        //CurrentThread
        private Thread ChatThread;
        //Request Queue
        private LinkedList<ICometRequest> CometRequestList;

        private IChatSessionManager SessionManager;

        // 事件触发模式
        private SessionTriggerMode SessionRaisedMode;

        //聊天记录，每个线程保存一份记录，数据量不大，避免并发性能问题
        private List<ChatMessageModel> CometChatMessage;
        //并发锁
        private object RequestSyncRoot = new object();
        private object MessageSyncRoot = new object();

        //会话，事件驱动触发
        private AutoResetEvent SessionWaitHandle = new AutoResetEvent(false);

        //线程无请求是，等待信号
        private AutoResetEvent ThreadWaitHandle = new AutoResetEvent(false);
        #endregion

        /// <summary>
        /// 线程初始化
        /// </summary>
        public CometThread(IChatSessionManager sessionManager)
        {
            CometRequestList = new LinkedList<ICometRequest>();
            //使用事件驱动
            SessionRaisedMode = SessionTriggerMode.EventTrigger;
            CometChatMessage = new List<ChatMessageModel>();

            SessionManager = sessionManager;
            ChatThread = new Thread(new ThreadStart(CometThreadStart));
            ChatThread.IsBackground = false;
            ChatThread.Start();
        }

        public int RequestCount
        {
            get
            {
                return CometRequestList.Count*CometThreadPool.ThreadCount;
            }
        }

        #region 处理
        private void CometThreadStart()
        {
            while (true)
            {
                //转成数组再处理，避免长时间对CometRequestList对象 lock
                ICometRequest[] processRequest;
                lock (RequestSyncRoot)
                {
                    processRequest = CometRequestList.ToArray();
                }

                if (processRequest.Count() == 0)
                {
                    ThreadWaitHandle.WaitOne();
                }

                //处理请求
                if (SessionRaisedMode == SessionTriggerMode.EventTrigger)
                {
                    HandleEventTriggerMode(processRequest);
                }
                else
                {
                    HandlePollingMode(processRequest);
                }
            }
        }

        /// <summary>
        /// 以新消息触发 队列请求处理
        /// </summary>
        void HandleEventTriggerMode(ICometRequest[] requests)
        {
            //1s超时进入轮询
            SessionWaitHandle.WaitOne(1000);
            ChatMessageModel[] chatMessages;
            lock (MessageSyncRoot)
            {
                chatMessages = CometChatMessage.ToArray();
                //内存中值保留前20条记录，避免查询耗时
                CometChatMessage = CometChatMessage.Take(20).ToList();
            }

            foreach (var request in requests)
            {
                
                SessionManager.DoChatSession(request, chatMessages, FinishCometRequest);
            }
        }

        /// <summary>
        /// 单轮询模式处理，定时检查消息队列
        /// </summary>
        void HandlePollingMode(ICometRequest[] requests)
        {
            ChatMessageModel[] chatMessages;
            lock (MessageSyncRoot)
            {
                chatMessages = CometChatMessage.ToArray();
                //内存中值保留前20条记录，避免查询耗时
                CometChatMessage = CometChatMessage.Take(20).ToList();
            }
            foreach (var request in requests)
            {
                SessionManager.DoChatSession(request, chatMessages, FinishCometRequest);
            }

            //定时扫描
            Thread.Sleep(200);
        }

        /// <summary>
        /// 立即处理请求(返回时候得到处理)
        /// </summary>
        void HandleCurrentRequest(ICometRequest request)
        {
            lock (MessageSyncRoot)
            {
                //处理一个请求，不对MessageList copy了
                SessionManager.DoChatSession(request,CometChatMessage ,null );
              if(request.IsCompeled)
              {
                    request.FinishCometRequest();
                }
            }
        }
        #endregion

        #region Messages
        /// <summary>
        /// 添加新消息
        /// </summary>
        public void HandeChatMessage(ChatMessageModel message)
        {
            lock (MessageSyncRoot)
            {
                CometChatMessage.Add(message);
            }
            //新消息信号
            SessionWaitHandle.Set();
        }

        /// <summary>
        /// 添加新消息
        /// </summary>
        public void HandeChatMessage(IEnumerable<ChatMessageModel> messages)
        {
            lock (MessageSyncRoot)
            {
                CometChatMessage.AddRange(messages);
            }
            //新消息信号
            SessionWaitHandle.Set();
        }
        #endregion

        /// <summary>
        /// 完成长连接处理
        /// </summary>
        public void FinishCometRequest(ICometRequest request)
        {
            if (request.IsCompeled||(DateTime.Now - request.BeginTime).TotalSeconds >= RequestTimeOut)
            {
                DeQueueCometRequest(request);

                request.FinishCometRequest();
            }
        }

        /// <summary>
        /// 将请求加入线程处理队列
        /// </summary>
        public void EnQueueCometRequest(ICometRequest request)
        {
            request.CometConcurrentCount = RequestCount;

            //需要立即处理请求，如果有数据及立即返回,无数据才加入队列
            HandleCurrentRequest(request);

            if (request.IsCompeled)
            {
                return;
            }

            //将请求加入队列处理
            lock (RequestSyncRoot)
            {
                CometRequestList.AddFirst(request);
                //通知线程开始工作
                ThreadWaitHandle.Set();
            }
        }

        /// <summary>
        /// 完成请求删除节点
        /// </summary>
        public void DeQueueCometRequest(ICometRequest request)
        {
            lock (RequestSyncRoot)
            {
                CometRequestList.Remove(request);
            }
        }
    }
}
