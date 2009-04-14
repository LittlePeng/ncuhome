using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls.Manage
{
     public  class Friend :SkinnedBlogWebControl
    {
        public Repeater repeater1;
        public Friend()
        {
            SkinFileName = "Friend.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            repeater1 = (Repeater)Skin.FindControl("repeater1");
            DataBind();
        }
        public override void DataBind()
        {  
            if (blogContext.ID != -1)
                BCommon_Friend.DeleteByID(blogContext.ID);
            repeater1.DataSource = BView_BlogUserFriend.GetByFIID(blogContext.MFiiD);
            repeater1.DataBind();
      
            base.DataBind();
        }
    }
}
