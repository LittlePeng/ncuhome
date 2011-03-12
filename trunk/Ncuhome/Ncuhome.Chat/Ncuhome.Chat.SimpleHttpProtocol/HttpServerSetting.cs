using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Chat.SimpleHttpProtocol
{
    /// <summary>
    /// http 服务配置信息
    /// </summary>
    public class HttpServerSetting
    {
            /// <summary>
            /// 默认配置
            /// </summary>
            public static HttpServerSetting Default
            {
                get
                {
                    HttpServerSetting setting = new HttpServerSetting();
                    setting.Timeout = 30*0000;
                    setting.KeepAliveTimeout = 5*000;
                    setting.MaxRequests = 100;
                    setting.KeepAlive = true;
                    return setting;
                }
            }

            /// <summary>
            ///http连接超时时间 ms
            /// </summary>
            public int Timeout{get;set;}

            /// <summary>
            /// 当连接为keep alive时，一次请求之后等待下次请求超时时间ms
            /// </summary>
            public int KeepAliveTimeout{get;set;}
         
            /// <summary>
            /// 一次tcp会话处理最大请求数量
            /// </summary>
            public int MaxRequests{get;set;}

            /// <summary>
            /// 是否开启Keepalive，false时每次Response时立即将关闭连接
            /// </summary>
            public bool KeepAlive{get;set;}
        }
}
