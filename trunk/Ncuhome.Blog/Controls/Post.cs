using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Ncuhome.Blog.Controls
{
    public class Post: SkinnedBlogWebControl
    {
        private Repeater repeater;
        public Post()
        {
            SkinFileName = "post.ascx";
        }



        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            repeater = (Repeater)(Skin.FindControl("repteater1"));
            DataBind();

        }
        public override void DataBind()
        {
            //Ncuhome.Blog.Controls.WebReference.Weblog w = new Ncuhome.Blog.Controls.WebReference.Weblog();
            //List<Ncuhome.Blog.Controls.WebReference.Weblog_Log> l = new List<Ncuhome.Blog.Controls.WebReference.Weblog_Log>();
           
            //l.Add( w.GetLogByLogId(blogContext.LogId));
            
            //repeater.DataSource = l.ToArray();
            //repeater.DataBind();
            //base.DataBind();
        }
    }
}
