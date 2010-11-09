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
            CometList = new LinkedList<CometAsyncResult>();
            ChatThread = new Thread(new ThreadStart(CometThreadStart));
            ChatThread.IsBackground = false;
            ChatThread.Start();
        }

        // 事件抽发模式
        public HandleFiredMode FiredMode=HandleFiredMode.NewPostEvent;

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


        void HandleNewPostEventMode(CometAsyncResult[] results)
        { 
        
        }

        /// <summary>
        /// 单轮询模式处理，定时检查消息队列
        /// </summary>
        /// <param name="results"></param>
        void HandlePollingEventMode(CometAsyncResult[] results)
        { 
        
        }

        private object SyncRoot = new object();

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
