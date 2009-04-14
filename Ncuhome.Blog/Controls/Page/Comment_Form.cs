using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;


namespace Ncuhome.Blog.Controls
{
    public class Comment_Form:SkinnedBlogWebControl
    {
        private Panel EnReply;
        private Literal ReplyAlert;
        public Comment_Form()
        {
            SkinFileName = "Comment_Form.ascx";
            IsThemed = true;
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
          //if(Context.Session["PassWord"]==null||Convert.ToString(Context.Session["PassWord"])=="")
          //{
              
          //    Context.Response.Redirect("Index.aspx?mfiid="+BlogContext.Current.MFiiD+"&afiid="+BlogContext.Current.AFiiD);

          //}
            //if (Convert.ToString(Context.Session["PassWord"]) != BWeblog_log.GetPW(Convert.ToInt32( Context.Request["logid"])))
            //{
            //    Context.Response.Redirect("Index.aspx?mfiid=" + BlogContext.Current.MFiiD + "&afiid=" + BlogContext.Current.AFiiD);
            //}
            EnReply = (Panel)Skin.FindControl("EnReply");
            ReplyAlert = (Literal)Skin.FindControl("ReplyAlert");
            View_WeblogUserLog WL = BWeblog_log.GetByIDAndFiid(blogContext.LogId,blogContext.MFiiD);
            if (WL == null)
            {
                Context.Response.Write("<script>alert('该文章不存在或已经删除！');top.window.location='/" + blogContext.Context.Request.QueryString["Domain"] + "';</script>");
                Context.Response.End();
            }
            if (Convert.ToBoolean(WL.Log_IsEnRePly))
            {
                EnReply.Visible = true;
                ReplyAlert.Visible = false;
            }
            else
            {
                EnReply.Visible = false;
                ReplyAlert.Visible = true;
            }

            Globals.UpdateLogByRssLink(blogContext.BlogUserId);
        }
    }
}
