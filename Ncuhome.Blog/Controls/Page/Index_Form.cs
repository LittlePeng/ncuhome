using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls
{
   public class Index_Form:SkinnedBlogWebControl
    {
        public Index_Form()
        {
            SkinFileName = "Index_Form.ascx";
            IsThemed = true;
        }
        
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            //if (!Skin.Page.IsPostBack)
            //{
            string domain = "";
            if (HttpContext.Current.Request.QueryString["logid"] != null && HttpContext.Current.Request.QueryString["Domain"] == null)
            {
                domain = BWeblog_User.GetUserDomainByLogID(Convert.ToInt32(HttpContext.Current.Request.QueryString["logid"]));
                Weblog_Log WL = BWeblog_log.GetByID(Convert.ToInt32(HttpContext.Current.Request.QueryString["logid"]));
                if (WL != null)
                    HttpContext.Current.Response.Redirect("http://blog.ncuhome.cn/" + domain + "/Logs/" + WL.Log_CreateTime.Year + "/" + WL.Log_CreateTime.Month + "/" + WL.Log_CreateTime.Day + "/" + Convert.ToInt32(HttpContext.Current.Request.QueryString["logid"]) + ".html");
                else
                {
                    Globals.AlertMessage("该日志不存在或已经被删除！", true,"/");
                }
            }
            
            object ViewCount = new object();            //ViewCount锁
            string viewIP = Ncuhome.Blog.Core.Globals.IPAddress;    //获取来访者IP
            if (HttpContext.Current.Request.Cookies["ipInfo"]==null)
            {       //访问者第一次访问时访问量加1
                lock (ViewCount)
                {
                    BWeblog_User.AddBeViewCount(blogContext.BlogUserId);
                }
                //HttpContext.Current.Session["ip"] = viewIP;
                //HttpContext.Current.Session.Timeout = 1;
                HttpCookie Cookies = new HttpCookie("ipInfo");      //实例化一个Cookies对象
                Cookies.Values.Add("ip",viewIP);
                Cookies.Expires = DateTime.Now.AddSeconds(60);      //设置Cookies的有效时间为60s
                HttpContext.Current.Response.AppendCookie(Cookies); //确定写入Cookie
            }

            Globals.UpdateLogByRssLink(blogContext.BlogUserId);
            //}
        }
    }
}
