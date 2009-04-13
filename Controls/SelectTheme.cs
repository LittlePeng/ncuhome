using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using System.Web.UI.WebControls;

namespace Ncuhome.Blog.Controls
{
   public class SelectTheme:SkinnedBlogWebControl
    {
       public Repeater repeater1;
       public SelectTheme()
       {
           SkinFileName = "SelectTheme.ascx";
       }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            repeater1 = (Repeater)Skin.FindControl("repeater1");
            DataBind();
        }
        public override void DataBind()
        {
            repeater1.DataSource = BWeblog_Theme.GetAll();
            repeater1.DataBind();
            base.DataBind();
        }
    }
}
