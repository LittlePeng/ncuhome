using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ncuhome.Chat.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                IISChatServerTest();
            }

            Console.Read();
        }
        static void IISChatServerTest()
        {
            AsyncWebRequest request = new AsyncWebRequest();
            request.DoRequestAsync("http://localhost/chatclient.ashx",
                (st) =>
                {
                    StreamReader sr = new StreamReader(st);
                    Console.WriteLine(sr.ReadToEnd());
                    sr.Close();
                    st.Close();
                    //一个连接结束，立即开始下一个
                    IISChatServerTest();
                });
        }
    }
}
