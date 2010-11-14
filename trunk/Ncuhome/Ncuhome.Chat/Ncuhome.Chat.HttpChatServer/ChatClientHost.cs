using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;


namespace Ncuhome.Chat.HttpChatServer
{
    public class ChatClientHost
    {
        static void Main()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:88/");
            listener.Start();
        HttpListenerContext lc= listener.GetContext();
           
             Console.WriteLine(lc.Request.Url);
             Console.ReadLine();
        }
    }
}
