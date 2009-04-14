using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using System.Web.UI.WebControls;

namespace Ncuhome.Blog.Controls
{
   public   class UserInfor:SkinnedBlogWebControl
    {
       private Repeater repeater1;
       public UserInfor()
       {
           IsThemed = true;
           SkinFileName = "UserInfor.ascx";
       }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            //repeater1 = (Repeater)Skin.FindControl("repeater1");
            //DataBind();
        }
        public override void DataBind()
        {
            List<Weblog_User> u = new List<Weblog_User>();
            u.Add(BWeblog_User.GetByID(Convert.ToInt32(blogContext.Owner.User_Id)));
            repeater1.DataSource = u;
            repeater1.DataBind();
            base.DataBind();
        }
    }
}
