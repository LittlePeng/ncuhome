using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Ncuhome.Blog.Controls
{
   public  class DefaultLogs:SkinnedBlogWebControl
    {
        private Repeater repeater1;
        public DefaultLogs()
        {
            SkinFileName = "DefaultLogs.ascx";
            IsThemed = true;
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            repeater1 = (Repeater)Skin.FindControl("repeater1");
            DataBind();
        }
        public override void DataBind()
        {
            repeater1.DataSource = Ncuhome.Blog.Core.BView_GetUserNickNameByLogId.GetTopPaged(10, 1);
            repeater1.DataBind();
            base.DataBind();
        }

    }
}
