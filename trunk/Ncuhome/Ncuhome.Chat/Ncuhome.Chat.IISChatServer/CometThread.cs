using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Ncuhome.Chat.Model;


namespace Ncuhome.Chat.IISChatServer
{
    public class CometThread
    {
        //CurrentThread
        private Thread ChatThread;
        //Request Queue
        public LinkedList<CometAsyncResult> CometList;

        //并发锁
        private object RequestSyncRoot = new object();
        private object MessageSyncRoot = new object();

        // 事件触发模式
        public HandleFiredMode FiredMode=HandleFiredMode.NewPostEvent;
        //聊天记录，每个线程保存一份记录，数据量不大，避免并发性能问题
        public List<ChatMessageModel> CometChatMessage = new List<ChatMessageModel>();

        //WaitHanlder，新消息是自动重置，新消息导到是处理线程中所有连接
        public AutoResetEvent CometWaitHandle = new AutoResetEvent(false);

        public AutoResetEvent ThreadWaitHandle = new AutoResetEvent(false);

        public CometThread()
        {
            CometList = new LinkedList<CometAsyncResult>();
            ChatThread = new Thread(new ThreadStart(CometThreadStart));
            ChatThread.IsBackground = false;
            ChatThread.Start();
        }

        public void CometThreadStart()
        {
            while (true)
            {
              
                //转成数组再处理，避免长时间lock
                CometAsyncResult[] processHandler;
                lock (RequestSyncRoot)
                {
                    processHandler = CometList.ToArray();
                }
                //
                if (processHandler.Count() == 0)
                {
                    ThreadWaitHandle.WaitOne();
                }
                //处理工作
                if (FiredMode == HandleFiredMode.NewPostEvent)
                {
                    HandleNewPostEventMode(processHandler);
                }
                else
                {
                    HandlePollingEventMode(processHandler);
                }
            }
        }

        /// <summary>
        /// 添加新消息
        /// </summary>
        /// <param name="message"></param>
        public void HandeNewMessage(ChatMessageModel message)
        {
            lock (MessageSyncRoot)
            {
                CometChatMessage.Add(message);
            }
            //新消息信号
            CometWaitHandle.Set();
        }

        //以新消息触发 队列请求处理
        void HandleNewPostEventMode(CometAsyncResult[] results)
        {
            //500ms超时进入轮询
            CometWaitHandle.WaitOne(1000);
            ChatMessageModel[] chatMessages;
            lock (MessageSyncRoot)
            {
                chatMessages=CometChatMessage.ToArray();
                //内存中值保留前20条记录，避免查询耗时
                CometChatMessage=CometChatMessage.Take(20).ToList();
            }
            ChatSessionManager sessionManager = new ChatSessionManager();
            foreach (var result in results)
            {
                sessionManager.HandleSession(result, chatMessages, new FinishHandler(FinishCometHandler),new FinishHandler(FinishTimeOutCometHandler));
            }
        }

        /// <summary>
        /// 单轮询模式处理，定时检查消息队列
        /// </summary>
        /// <param name="results"></param>
        void HandlePollingEventMode(CometAsyncResult[] results)
        {
            ChatMessageModel[] chatMessages;
            lock (MessageSyncRoot)
            {
                chatMessages = CometChatMessage.ToArray();
                //内存中值保留前20条记录，避免查询耗时
                CometChatMessage = CometChatMessage.Take(20).ToList();
            }
            ChatSessionManager sessionManager = new ChatSessionManager();
            foreach (var result in results)
            {
                sessionManager.HandleSession(result, chatMessages, new FinishHandler(FinishCometHandler), new FinishHandler(FinishTimeOutCometHandler));
            }
            //定时扫描
            Thread.Sleep(200);
        }

        private void FinishTimeOutCometHandler(CometAsyncResult result)
        {
            if ((DateTime.Now - result.BeginHandleDateTime).TotalSeconds>=5)
            {
                FinishCometHandler(result);
            }
        }
  
        /// <summary>
        /// 完成长连接处理
        /// </summary>
        /// <param name="result"></param>
        private void FinishCometHandler(CometAsyncResult result)
        { 
            result.FinishCometRequest();
            DeQueueCometHandler(result);
        }

        public void EnQueueCometHandler(CometAsyncResult result)
        {
            //需要立即处理请求，如果有数据及立即返回
            //TODO , 

            //无数据加入队列处理
            lock (RequestSyncRoot)
            {
                CometList.AddFirst(result);
                //通知线程开始工作
                ThreadWaitHandle.Set();
            }
        }

        /// <summary>
        /// 在Request完成之后需要调用此处删除节点，避免再次处理已经完成的请求
        /// </summary>
        public void DeQueueCometHandler(CometAsyncResult result)
        {
            lock (RequestSyncRoot)
            {
                CometList.Remove(result);
            }
        }


    }
}
