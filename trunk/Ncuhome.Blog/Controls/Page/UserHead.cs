using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Text;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls
{
    public class UserHead:SkinnedBlogWebControl
    {
        private Image UserHeads;
        private Repeater Repeater1;
        public UserHead()
        {
            IsThemed = true;
            SkinFileName = "UserHead.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            UserHeads = (Image)Skin.FindControl("UserHead");
            //Repeater1 = (Repeater)Skin.FindControl("Repeater1");
            if (BWeblog_User.GetByID(Convert.ToInt32(BlogContext.Current.Owner.User_Id)).User_PortraitUrl==null)
            {
                UserHeads.ImageUrl = "/images/defaulthead.gif";
            }
            else
            {
                UserHeads.ImageUrl = "http://resource.ncuhome.cn/Blog/ThumbnailImage/UserHead/" + BWeblog_User.GetByID(Convert.ToInt32(BlogContext.Current.Owner.User_Id)).User_PortraitUrl.ToString();
            }
            DataBind();
        }
        public override void DataBind()
        {
            //Repeater1.DataSource = BWeblog_User.GetByNickName(BlogContext.Current.Owner.User_NickName.ToString());
            base.DataBind();
        }
    }
}
