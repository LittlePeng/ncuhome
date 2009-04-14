using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Ncuhome.Blog.Core;

namespace Ncuhome.Blog.Controls
{
   public class Log_Form :SkinnedBlogWebControl
    {
        public Log_Form()
        {
            SkinFileName = "Log_Form.ascx";
            IsThemed = true;
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {

            //object ViewCount = new object();            //ViewCount锁

            if (HttpContext.Current.Request.Cookies["ipInfo"] != null)
            {       //访问者第一次访问时访问量加1
                if (HttpContext.Current.Request.Cookies["ipInfo"].Value != blogContext.MFiiD.ToString())
                {
                    BWeblog_User.AddBeViewCount(blogContext.BlogUserId);

                    HttpCookie Cookies = new HttpCookie("ipInfo");      //实例化一个Cookies对象
                    Cookies.Values.Add("ipInfo", blogContext.MFiiD.ToString());
                    Cookies.Expires = DateTime.Now.AddSeconds(60);      //设置Cookies的有效时间为60s
                    HttpContext.Current.Response.AppendCookie(Cookies); //确定写入Cookie
                }
            }
            else
            {
                BWeblog_User.AddBeViewCount(blogContext.BlogUserId);

                HttpCookie Cookies = new HttpCookie("ipInfo");      //实例化一个Cookies对象
                Cookies.Values.Add("ipInfo", blogContext.MFiiD.ToString());
                Cookies.Expires = DateTime.Now.AddSeconds(60);      //设置Cookies的有效时间为60s
                HttpContext.Current.Response.AppendCookie(Cookies); //确定写入Cookie
            }

            Globals.UpdateLogByRssLink(blogContext.BlogUserId);

        }
    }
}
