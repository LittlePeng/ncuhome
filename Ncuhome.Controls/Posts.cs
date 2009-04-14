using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;


namespace Ncuhome.Blog.Controls
{
    public  class Posts :SkinnedBlogWebControl
    {
        private Repeater repeater;

        public Posts()
        {
            SkinFileName = "posts.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control skin)
        {
           repeater = (Repeater)skin.FindControl("Posts");
           DataBind();
        }
        public override void DataBind()
        {
            //Weblog w = new Weblog();
            //Log[] c= w.GetLogsByFiid(10, 1,blogContext.ID );  
      
           
            //repeater.DataSource = c;
            //repeater.DataBind();
            //base.DataBind();
        }
    }
}
