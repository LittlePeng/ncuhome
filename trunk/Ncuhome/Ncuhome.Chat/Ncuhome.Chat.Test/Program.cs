using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace Ncuhome.Chat.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.MaxServicePoints = 10000;
            #region IISTest
            for (int i = 0; i < 1000; i++)
            {
                IISChatServerTest("http://localhost/chatclient.ashx?lastid=");
            }
            #endregion

            Console.Read();
        }

        static int LastId = 0;
        static void IISChatServerTest(string url)
        {
            AsyncWebRequest request = new AsyncWebRequest();
            request.DoRequestAsync(url+LastId.ToString(),
                (st) =>
                {
                    StreamReader sr = new StreamReader(st);
                    Console.WriteLine(sr.ReadToEnd());
                    sr.Close();
                    st.Close();
                    //一个连接结束，立即开始下一个
                    LastId++;
                    IISChatServerTest(url+LastId.ToString());
                });
        }
    }
}
