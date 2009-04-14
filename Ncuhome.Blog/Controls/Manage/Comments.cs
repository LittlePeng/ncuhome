using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Text;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls.Manage
{
    public class Comments : SkinnedBlogWebControl
    {
        private RepeaterPaged repeater1;
        public Comments()
        {
            SkinFileName = "Comments.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            if (Context.Request["DeleteCommentId"] != null)
            {
                if (BWeblog_Comment.DeleteByID(Convert.ToInt32(Context.Request["DeleteCommentId"])))
                {
                    BWeblog_User.SetUserCommentCount(blogContext.BlogUserId);
                    BWeblog_log.SetLogCountByUID(blogContext.BlogUserId);
                    Context.Response.Write("<script>alert('删除成功!');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/Comments-" + blogContext.LogId + ".aspx';</script>");
                }
                else
                {
                    Context.Response.Write("<script>alert('删除失败!');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/Comments-" + blogContext.LogId + ".aspx';</script>");
                }
            }
            repeater1 = (RepeaterPaged)Skin.FindControl("Repeater1");
            if (Context.Request["logid"] != null)
            {
                DataBind();
            }
            else
            {
                System.Web.HttpContext.Current.Response.Redirect("/" + blogContext.Owner.User_DomainName + "/Manage/logs.aspx");
            }
            //else
            //{
            //    Context.Response.Write("<script>alert('你没有权限！');</script>");
            //    Context.Response.End();
            //}
        }
        public override void DataBind()
        {
            //repeater1.DataSource = BView_WeblogUserComment.GetByLogUID(1774);
            //repeater1.DataSource = BView_WeblogUserComment.GetByLogId(14511);
            repeater1.Count = BWeblog_Comment.GetCountByLogID(Convert.ToInt32(Context.Request["logid"]));
            repeater1.Length = 15;
            repeater1.UrlFormat = "/Manage/Comments.aspx?mfiid=" + blogContext.MFiiD.ToString()+"&logid="+Convert.ToInt32(Context.Request["logid"]) + "&";
            if (blogContext.PageIndex!=-1)
            {
                repeater1.DataSource = BWeblog_Comment.GetByLogIDPaged(blogContext.PageIndex, 15, Convert.ToInt32(Context.Request["logid"]));
            }
            else
            {
                repeater1.DataSource = BWeblog_Comment.GetByLogIDPaged(1, 15, Convert.ToInt32(Context.Request["logid"]));
            }
            repeater1.DataBind();
            base.DataBind();
        }
        
    }
}
