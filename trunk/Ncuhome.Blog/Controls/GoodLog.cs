using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls
{
    public class GoodLog:SkinnedBlogWebControl
    {
        private Repeater Repeater1;
        public GoodLog()
        {
            SkinFileName = "GoodLog.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            Repeater1 = (Repeater)Skin.FindControl("Repeater1");
            DataBind();
            //throw new NotImplementedException();
        }
        public override void DataBind()
        {
            //一个月之内的
            Repeater1.DataSource = BWeblog_User.GetTopUsersBlogByAnyDays(1, 7, 30);
            Repeater1.DataBind();
            base.DataBind();
        }
    }
}
