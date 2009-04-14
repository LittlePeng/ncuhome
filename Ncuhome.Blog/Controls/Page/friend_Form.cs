using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Ncuhome.Blog.Core;

namespace Ncuhome.Blog.Controls
{
    public class friend_Form:SkinnedBlogWebControl
    {
        public friend_Form()
        {
            IsThemed = true;
            SkinFileName = "friend_Form.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            //throw new NotImplementedException();

            object ViewCount = new object();            //ViewCount锁
            string viewIP = Ncuhome.Blog.Core.Globals.IPAddress;    //获取来访者IP
            if (HttpContext.Current.Request.Cookies["ipInfo"] == null)
            {       //访问者第一次访问时访问量加1
                lock (ViewCount)
                {
                    BWeblog_User.AddBeViewCount(blogContext.BlogUserId);
                }
                //HttpContext.Current.Session["ip"] = viewIP;
                //HttpContext.Current.Session.Timeout = 1;
                HttpCookie Cookies = new HttpCookie("ipInfo");      //实例化一个Cookies对象
                Cookies.Values.Add("ip", viewIP);
                Cookies.Expires = DateTime.Now.AddSeconds(60);      //设置Cookies的有效时间为60s
                HttpContext.Current.Response.AppendCookie(Cookies); //确定写入Cookie
            }

            Globals.UpdateLogByRssLink(blogContext.BlogUserId);
        }
    }
}
