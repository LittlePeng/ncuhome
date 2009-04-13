using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Text.RegularExpressions;
using Ncuhome.Blog.Entity;
using Rss;


namespace Ncuhome.Blog.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Globals
    {
        public Globals()
        {

        }
        /// <summary>
        /// 获取网站实际路径
        /// </summary>
        /// <returns></returns>
        public static string GetWebRootPath()
        {
            return HttpContext.Current.Server.MapPath("\\");
        }
        /// <summary>
        /// 获取IP地址
        /// </summary>
        public static string IPAddress
        {
            get
            {
                string userIP;
                // HttpRequest Request = HttpContext.Current.Request;
                HttpRequest Request = HttpContext.Current.Request; // ForumContext.Current.Context.Request;
                // 如果使用代理，获取真实IP
                if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                    userIP = Request.ServerVariables["REMOTE_ADDR"];
                else
                    userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (userIP == null || userIP == "")
                    userIP = Request.UserHostAddress;
                return userIP;
                #region
                //参考方法 http://flowerbin.cnblogs.com/archive/2005/07/07/188030.html
                //				string result = String.Empty; 
                // 
                //				result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]; 
                //				if(result!=null&&result!= String.Empty) 
                //				{ 
                //					//可能有代理 
                //					if(result.IndexOf(".")==-1)    //没有“.”肯定是非IPv4格式 
                //						result = null; 
                //					else 
                //					{ 
                //						if(result.IndexOf(",")!=-1) 
                //						{ 
                //							//有“,”，估计多个代理。取第一个不是内网的IP。 
                //							result = result.Replace(" ","").Replace("'",""); 
                //							string[] temparyip = result.Split(",;".ToCharArray()); 
                //							for(int i=0;i<temparyip.Length;i++) 
                //							{ 
                //								if( Text.IsIPAddress(temparyip[i]) 
                //									&& temparyip[i].Substring(0,3)!="10." 
                //									&& temparyip[i].Substring(0,7)!="192.168" 
                //									&& temparyip[i].Substring(0,7)!="172.16.") 
                //								{ 
                //									return temparyip[i];    //找到不是内网的地址 
                //								} 
                //							} 
                //						} 
                //						else if(Text.IsIPAddress(result)) //代理即是IP格式 
                //							return result; 
                //						else 
                //							result = null;    //代理中的内容 非IP，取IP 
                //					} 
                // 
                //				} 
                // 
                //				string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]!=null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] !=String.Empty)?HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]:HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; 
                //         
                // 
                // 
                //				if (null == result || result == String.Empty) 
                //					result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; 
                //     
                //				if (result == null || result == String.Empty) 
                //					result = HttpContext.Current.Request.UserHostAddress; 
                // 
                //				return result; 
                #endregion

            }
        }
        //博客关键字
        public static string MateKeyWords
        {
            get { return "家园网，blog,博客，南昌大学，南昌大学家园网，ncuhome,家园，网络，生活"; }
        }
       /// <summary>
       /// 判断是否是Ip地址
       /// </summary>
       /// <param name="str1"></param>
       /// <returns></returns>
        public static bool IsIPAddress(string str1)
        {
            if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15) return false;

            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str1);
        }
        /// <summary>
        /// html 反编码
        /// </summary>
        /// <param name="FormattedMessageSubject"></param>
        /// <returns></returns>
        public static String HtmlDecode(String FormattedMessageSubject)
        {
            if (IsNullorEmpty(FormattedMessageSubject))
                return FormattedMessageSubject;
            // strip the HTML - i.e., turn < into &lt;, > into &gt;
            return HttpContext.Current.Server.HtmlDecode(FormattedMessageSubject);
        }

      /// <summary>
      /// html 编码 
      /// </summary>
      /// <param name="FormattedMessageSubject"></param>
      /// <returns></returns>
        public static String HtmlEncode(String FormattedMessageSubject)
        {
            if ( IsNullorEmpty(FormattedMessageSubject))
                return FormattedMessageSubject;
            // strip the HTML - i.e., turn < into &lt;, > into &gt;
            return HttpContext.Current.Server.HtmlEncode(FormattedMessageSubject);
        }
         public static bool IsNullorEmpty(string text)
        {
            return text == null || text.Trim() == string.Empty;
        }
        // 弹出对话框
        /// <summary>
        /// 弹出消息对话框
        /// </summary>
        /// <param name="message">消息字符串</param>
        /// <param name="end">是否结束本页</param>
        /// <param name="url">重定向URL</param>
        public static void AlertMessage(string message, bool end, string url)
        {
            HttpContext.Current.Response.Write("<script>");
            HttpContext.Current.Response.Write("alert(\"" + message + "\");");


            if (url != null)
            {
                HttpContext.Current.Response.Write("document.location.href=\"" + url + "\";");
            }
            HttpContext.Current.Response.Write("</script>");

            if (end)
                HttpContext.Current.Response.End();
        }
        public static void AlertMessage(string message, string url)
        {
            AlertMessage(message, true, url);
        }
        public static void AlertMessage(string message, bool end)
        {
            AlertMessage(message, end, null);
        }
        public static void AlertMessage(string message)
        {
            AlertMessage(message, false, null);
        }
        public static string CutString(string Str, int len, bool ShowEnd)
        { 
            string s=string.Empty;
            if (Str.Length > len)
            {
                s = Str.Substring(0, len);
                if (ShowEnd)
                s += "...";
           
            }
            else
                s = Str;
                 return s;
        }
        /// <summary>
        /// 更改时间的形式
        /// Type=1：2008-1-1
        /// Type=2：2008-1-1 12：22
        /// Type=3：2008年1月1日
        /// type=4：2008年1月1日 12时22分
        /// </summary>
        /// <param name="Time">时间，string型</param>
        /// <param name="Type">类型</param>
        /// <returns></returns>
        public static string FormatTime(string Time,int Type)
        {
            DateTime time = Convert.ToDateTime(Time);
            string t="";
            string y= time.Year.ToString();
            string m=time.Month.ToString();
            string d=time.Day.ToString();
            string s=time.Hour.ToString();
            string f=time.Minute.ToString();
            if (Type == 1)
                t = y + "-" + m +"-"+ d;
            else if(Type==2)
                t = y + "-" + m + "-"+d+"&nbsp;"+s.ToString()+":"+f.ToString();
            if (Type == 3)
                t = y + "年" + m +"月"+ d+"日";
            else if (Type == 4)
                t = y + "年" + m + "月" + d + "日&nbsp;" + s.ToString() + "时" + f.ToString() + "分";
            else if(Type==5)
                t = y + "-" + m + "-" + d + "&nbsp;" + s.ToString() + ":" + f.ToString()+"&nbsp"+s.ToString()+":"+m.ToString();
            else
            { }
            return t;
            }
        /// <summary>
        /// 判断日记是否已经发布
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string LogState(object a)
        {
            if (Convert.ToDateTime(a)>DateTime.Now)
            {
                return "未发布";
            }
            else
            {
                return "发布";
            }

        }
        /// <summary>
        /// 判断用户头像，有就显示数据库中的图像，没有就显示/images/defaulthead.gif
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string MakeUserHead(object a)
        {
            if (a == null)
            {
                return "/images/defaulthead.gif";
            }
            else
            {
                return "http://resource.ncuhome.cn/Blog/ThumbnailImage/UserHead/" + Convert.ToString(a);
            }
        }
        /// <summary>
        /// 取传进参数a的前长度为len的字符串,如果长度小于len就返回a
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string ContentSubString(object a,int len)
        {
            string temp = a.ToString().Trim();
            temp = System.Text.RegularExpressions.Regex.Replace(temp, "\\s", "");
            if (temp.Length<=len)
            {
                return temp;
            }
            else
            {
                return temp.Substring(0,len)+"...";
            }
        }
        public static string GetUserName(int a)
        {
            if (a==0)
            {
                return "游客";
            }
            else
            {
                return BWeblog_User.GetByID(a).User_NickName;
            }
        }
        /// <summary>
        /// 过滤html和空格 截取字符串
        /// </summary>
        /// <param name="Html"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string CutStringWithoutHtml(string Html,int Length)
        {
            string str = System.Text.RegularExpressions.Regex.Replace(Html, "<[^>]*?>", "");
            string str2 = str.Replace("  ", "");
            if (str2.Length > Length)
                return str2.Substring(0, Length);
            else
                return str2;
        }
        /// <summary>
        /// RSS镜像更新用户blog,一天更新一次，目前只能通过标题来判断日记是否存在
        /// </summary>
        /// <param name="UserId">UID</param>


        public static void UpdateLogByRssLink(int UserId)
        {
            System.Threading.ParameterizedThreadStart strat = new System.Threading.ParameterizedThreadStart(UpdateCss);
            System.Threading.Thread th = new System.Threading.Thread(strat);
            th.Start(UserId);
       }
        private static void UpdateCss(object User_Id)
        {
            int UserId = Convert.ToInt32(User_Id);
            DateTime CurrentTime = DateTime.Now;
            Weblog_User WU = BWeblog_User.GetByID(UserId);

            DateTime BeViewLastTime = Convert.ToDateTime(WU.User_BeViewLastTime);
            TimeSpan TS = CurrentTime - BeViewLastTime;     //当前时间与最后访问的时间差
            if (TS.TotalDays > 1)
            {
                int Count = BWeblog_UserRssLink.GetRssLinkCountByUID(UserId);
                if (Count > 0)
                {
                    WU.User_BeViewLastTime = CurrentTime;
                    BWeblog_User.Update(WU);


                    foreach (Weblog_UserRssLink WURL in BWeblog_UserRssLink.GetRssLinkByUID(UserId))
                    {
                        Weblog_Log WL = new Weblog_Log();
                        try
                        {
                            RssFeed feed = RssFeed.Read(WURL.Weblog_UserRssLinkUrl);
                            foreach (RssChannel channel in feed.Channels)
                            {
                                foreach (RssItem temp in channel.Items)
                                {
                                    WL.Log_CreateTime = temp.PubDate;
                                    WL.Log_Title = temp.Title;
                                    if (!BWeblog_log.HasLogByUIDAndTitle(UserId, WL.Log_Title, WL.Log_CreateTime))
                                    {//通过标题和日记的创建时间来判断日记是否已经存在
                                        WL.Log_Title = temp.Title;
                                        WL.Log_Content = temp.Description+ "<br/>(原文出处:<a target='_blank' href='" + temp.Link+ "'>" + temp.Link+ "</a>)";
                                        WL.Log_CateId = 1;
                                        WL.Log_CommentCount = 0;
                                        WL.Log_IsEnRePly = true;
                                        WL.Log_IsIndexShow = true;
                                        WL.Log_IsDraft = false;
                                        WL.Log_IsPasssword = false;
                                        WL.Log_IsVisible = true;
                                        WL.Log_LastModiTime = temp.PubDate;
                                        WL.Log_ViewCount = 0;
                                        WL.Log_UserId = UserId;
                                        BWeblog_log.Insert(WL);
                                    }
                                }
                            }
                            //XDocument RssFeed = XDocument.Load(WURL.Weblog_UserRssLinkUrl);

                            ////XDocument RssFeed = XDocument.Load("http://blog.ncuhome.cn/RssFiles/46.xml");
                            //foreach (var item in RssFeed.Descendants("item"))
                            //{
                            //    WL.Log_CreateTime = DateTime.Parse(item.Element("pubDate").Value);
                            //    WL.Log_Title = item.Element("title").Value;
                            //    if (!BWeblog_log.HasLogByUIDAndTitle(UserId, WL.Log_Title, WL.Log_CreateTime))
                            //    {//通过标题和日记的创建时间来判断日记是否已经存在
                            //        WL.Log_Title = item.Element("title").Value;
                            //        WL.Log_Content = item.Element("description").Value + "<br/>(原文出处:<a target='_blank' href='" + item.Element("link").Value + "'>" + item.Element("link").Value + "</a>)";
                            //        WL.Log_CateId = 1;
                            //        WL.Log_CommentCount = 0;
                            //        WL.Log_IsDraft = false;
                            //        WL.Log_IsPasssword = false;
                            //        WL.Log_IsVisible = true;
                            //        WL.Log_LastModiTime = DateTime.Parse(item.Element("pubDate").Value);
                            //        WL.Log_ViewCount = 0;
                            //        WL.Log_UserId = UserId;
                            //        BWeblog_log.Insert(WL);
                            //    }
                            //}
                            BWeblog_log.SetLogCountByUID(BlogContext.Current.BlogUserId);
                        }
                        catch (Exception)
                        {
                            MailServices.MailServices ma = new Ncuhome.Blog.Core.MailServices.MailServices();
                            ma.WriteMail("系统消息更新rss：" + WURL.Weblog_UserRssLinkUrl + "失败!!时间：" + DateTime.Now.ToString(), "系统消息", WU.User_TxzId.ToString(), false, 46811, 1);

                        }
                    }
                }
            }
        }
        /// <summary>
        /// 产生随机数
        /// </summary>
        /// <param name="length">随机数的长度</param>
        /// <returns></returns>
        public static string GetRandomString(int length)
        {
            char[] allChars =
            {'0','1','2','3','4','5','6','7','8','9',  
              'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
            Random rn = new Random();
            StringBuilder sb = new StringBuilder(62);
            for (int i = 0; i < length; i++)
            {
                sb.Append(allChars[rn.Next(62)]);
            }
            return sb.ToString();
        }
    }
}