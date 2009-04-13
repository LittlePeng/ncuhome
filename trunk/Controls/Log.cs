using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls
{
    public class Log:SkinnedBlogWebControl
    {
        private Repeater repeater1;
        private Panel ContentPanel;
        private Panel PDPanel;
        private TextBox PDText;
        private Button OK;
        public Log()
        {
            SkinFileName = "Log.ascx";
            IsThemed = true;
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {

            //object logView = new object();      //logView锁
            if (HttpContext.Current.Request.Cookies["logView"] != null)
            {

                if (HttpContext.Current.Request.Cookies["logView"].Values["logView"] != blogContext.LogId.ToString())
                {
                    BWeblog_log.AddViewCount(blogContext.LogId);
                    BWeblog_User.AddBeViewCount(blogContext.BlogUserId);
                    HttpCookie cookiesForLogView = new HttpCookie("logView");
                    cookiesForLogView.Values.Add("logView", blogContext.LogId.ToString());       //随便给cookie赋一个值，不为null不行
                    cookiesForLogView.Expires = DateTime.Now.AddSeconds(60);
                    HttpContext.Current.Response.AppendCookie(cookiesForLogView);
                }
            }
            else
            {
                BWeblog_log.AddViewCount(blogContext.LogId);
                BWeblog_User.AddBeViewCount(blogContext.BlogUserId);
                HttpCookie cookiesForLogView = new HttpCookie("logView");
                cookiesForLogView.Values.Add("logView", blogContext.LogId.ToString());       //随便给cookie赋一个值，不为null不行
                cookiesForLogView.Expires = DateTime.Now.AddSeconds(60);
                HttpContext.Current.Response.AppendCookie(cookiesForLogView);
            }

            repeater1 =(Repeater) Skin.FindControl("repeater1");
            ContentPanel = (Panel)Skin.FindControl("content");
            PDPanel = (Panel)Skin.FindControl("password");
            PDText = (TextBox)Skin.FindControl("PD");
            OK = (Button)Skin.FindControl("check");
            //加密
            View_WeblogLogCategory log = BView_WeblogLogCategory.GetByLogID(blogContext.LogId);
            if (log == null)  //文章不存在
            {
                Context.Response.Write("<script>alert('该文章不存在或已经删除！');top.window.location='/default.aspx';</script>");
                Context.Response.End();
            }
           //添加title
            string Title=log.Log_Title +"-"+blogContext.Owner.User_NickName+"-家园博客";
            Page.Title = Title;
            //关键字添加
            HtmlMeta KeyWords = new HtmlMeta();
            KeyWords.Name = "keywords";
            KeyWords.Content = Title +Globals.MateKeyWords+log.Log_KeyWords;
            Page.Header.Controls.Add(KeyWords);

            if (log.Log_IsPasssword == true)
            {
                ContentPanel.Visible = false;
                PDPanel.Visible = true;
            }
            else
            {
                ContentPanel.Visible = true;
                PDPanel.Visible = false;

                //加密的内容不需要
                string description =Globals.CutStringWithoutHtml(log.Log_Content,100);
                HtmlMeta desc = new HtmlMeta();
                desc.Name="description";
                desc.Content=description;
                Page.Header.Controls.Add(desc);

                List<View_WeblogLogCategory> LogList = new List<View_WeblogLogCategory>();
                LogList.Add(log);
                repeater1.DataSource = LogList;
                repeater1.DataBind();
            }
            OK.Click += new EventHandler(OK_Click);



          
            DataBind();
        }

        void OK_Click(object sender, EventArgs e)
        {
            if (PDText.Text ==BView_WeblogLogCategory.GetByLogID(blogContext.LogId).Log_PassWord)
            {
                ContentPanel.Visible = true;
                PDPanel.Visible = false;
            }
            else
            {
                Context.Response.Write("<script>alert('密码错误！')</script>");
            }
        }
        public override void DataBind()
        {
            base.DataBind();
        }
    }
}
