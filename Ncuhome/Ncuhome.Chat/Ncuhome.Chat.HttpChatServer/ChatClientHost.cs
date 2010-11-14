﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Ncuhome.Chat.SimpleThreadPool;


namespace Ncuhome.Chat.HttpChatServer
{
    public class ChatClientHost
    {
        static void Main()
        {   
            //初始化线程池
            ChatSessionManager sessionManager = new ChatSessionManager();
            CometThreadPool.Start(sessionManager);
            StartHttpListener(88);
            Console.ReadLine();
        }

        static void StartHttpListener(int port)
        {

            //启动http监听
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(string.Format("http://+:{0}/", port.ToString()));
            listener.Start();

            listener.BeginGetContext(EndGetContext, listener);
        }

        static void EndGetContext(IAsyncResult result)
        {
            HttpListener listener = result.AsyncState as HttpListener;
            HttpListenerContext lc= listener.EndGetContext(result);
            //继续监听下一个
            listener.BeginGetContext(EndGetContext, listener);

            //将请求放置于线程池处理
            HttpCometRequest request=new HttpCometRequest(lc.Request,lc.Response);
            CometThreadPool.QueueCometRequest(request);
        }
    }
}
