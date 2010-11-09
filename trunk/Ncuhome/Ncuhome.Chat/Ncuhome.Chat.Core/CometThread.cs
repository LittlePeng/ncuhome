using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Ncuhome.Chat.Model;


namespace Ncuhome.Chat.Core
{
    public class CometThread
    {
        public CometThread()
        {
            CometList = new LinkedList<CometAsyncResult>();
            ChatThread = new Thread(new ThreadStart(CometThreadStart));
            ChatThread.IsBackground = false;
            ChatThread.Start();
        }

        // 事件抽发模式
        public HandleFiredMode FiredMode=HandleFiredMode.NewPostEvent;
        //聊天记录，每个线程保存一份记录，数据量不大，避免并发性能问题
        public List<ChatMessage> CometChatMessage = new List<ChatMessage>();

        //新消息导到是处理线程中所有连接
        public AutoResetEvent CometWaitHandle = new AutoResetEvent(false);

        public void CometThreadStart()
        {
            while (true)
            {
                //转成数组再处理，避免长时间lock
                CometAsyncResult[] processHandler;
                lock (SyncRoot)
                {
                    processHandler = CometList.ToArray();
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

        public void HandeNewMessage(ChatMessage message)
        {
            lock (SyncRoot2)
            {
                CometChatMessage.Add(message);
            }
            CometWaitHandle.Set();
        }

        void HandleNewPostEventMode(CometAsyncResult[] results)
        {
            //500ms超时进入轮询
            CometWaitHandle.WaitOne(500);
        }

        /// <summary>
        /// 单轮询模式处理，定时检查消息队列
        /// </summary>
        /// <param name="results"></param>
        void HandlePollingEventMode(CometAsyncResult[] results)
        { 
        
        }

        private object SyncRoot = new object();
        private object SyncRoot2 = new object();

        private void FinishTimeOutHandler(CometAsyncResult result)
        {
            if ((DateTime.Now - result.BeginHandleDateTime).Seconds >= 20)
            {
                FinishCometHandler(result,null);
            }
        }

        /// <summary>
        /// 完成长连接处理
        /// </summary>
        /// <param name="result"></param>
        private void FinishCometHandler(CometAsyncResult result, CometMessageDTO message)
        { 
            result.ResponseMessage = message;
            result.FinishCometRequest();
            DeQueueCometHandler(result);
        }

        public void EnQueueCometHandler(CometAsyncResult result)
        {
            //需要立即处理请求，如果有数据及立即返回
            //TODO

            //无数据加入队列处理
            lock (SyncRoot)
            {
                CometList.AddFirst(result);
            }
        }

        /// <summary>
        /// 在Request完成之后需要调用此处删除节点，避免再次处理已经完成的请求
        /// </summary>
        public void DeQueueCometHandler(CometAsyncResult result)
        {
            lock (SyncRoot)
            {
                CometList.Remove(result);
            }
        }

        private Thread ChatThread;
        public LinkedList<CometAsyncResult> CometList;
    }
}
