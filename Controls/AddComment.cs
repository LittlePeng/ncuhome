using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using System.Web.UI.WebControls;
using System.Web;

namespace Ncuhome.Blog.Controls
{
    public  class AddComment:SkinnedBlogWebControl
    {
        private TextBox CommentContent;
        private TextBox CommentName;
        private TextBox YanZhen;
        private Button Add;
        private Button Cansel;
       
        public AddComment()
        {
            SkinFileName = "AddComment.ascx";
            IsThemed = true;
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
           
            CommentName = (TextBox)Skin.FindControl("CommenterName");
            CommentContent = (TextBox)Skin.FindControl("CommentContext");
            YanZhen = (TextBox)Skin.FindControl("YanZhen");
            Add = (Button)Skin.FindControl("Add");
            Cansel = (Button)Skin.FindControl("Cansel");
           
            DataBind();
        }
        public override void DataBind()
        {
            Add.Click += new EventHandler(Add_Click);
            Cansel.Click += new EventHandler(Cansel_Click);
            if (blogContext.User.IsLogin)
            {
                CommentName.Text = blogContext.User.UserInfo.User_NickName;
            }
            base.DataBind();
        }

        void Cansel_Click(object sender, EventArgs e)
        {
            CommentContent.Text = "";
        }

        void Add_Click(object sender, EventArgs e)
        {
            if (Context.Request.Cookies["CheckCode"] == null)
            {
                Context.Response.Write("<script>alert('您的浏览器设置已被禁用 Cookies，您必须设置浏览器允许使用 Cookies 选项后才能使用本系统。');history.go(-1);</script>");
                return;
            }

            if (String.Compare(Context.Request.Cookies["CheckCode"].Value,YanZhen.Text.ToString().Trim(), true) != 0)
            {
                Context.Response.Write("<script>alert('验证码错误，请输入正确的验证码。');history.go(-1);</script>");
                return;
            }
            else
            {
                string commentCnt = CommentContent.Text;
                Weblog_Comment WC = new Weblog_Comment();
                if (blogContext.User.IsLogin)
                {
                    WC.Comment_GuestName = CommentName.Text;
                    WC.Comment_UserId = blogContext.User.UserInfo.User_Id;
                }
                else
                {
                    WC.Comment_UserId = 47;
                    if (CommentName.Text != "" && CommentName.Text != null)
                    {

                        WC.Comment_GuestName = CommentName.Text;
                    }
                    else
                    {
                        WC.Comment_GuestName = "游客";
                    }

                }
                WC.Comment_LogId = blogContext.LogId;
                commentCnt = commentCnt.Replace("\r\n", "<br/>");
                commentCnt = commentCnt.Replace(" ", "&nbsp;");
                WC.Comment_Content = commentCnt;
                WC.Comment_CreateTime = DateTime.Now;
                WC.Comment_LastModiTime = DateTime.Now;

                BWeblog_Comment.Insert(WC);
                if (WC.Comment_UserId != blogContext.Owner.User_Id)
                {
                    BWeblog_User.AddCommentCount(blogContext.BlogUserId);
                }
                Weblog_Log WL = BWeblog_log.GetByID(blogContext.LogId);
                Context.Response.Redirect("/" + blogContext.Owner.User_DomainName + "/Logs/" + WL.Log_CreateTime.Year + "/" + WL.Log_CreateTime.Month + "/" + WL.Log_CreateTime.Day + "/" + blogContext.LogId + ".html");
            }
        }
    }
}
