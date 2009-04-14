using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls.Manage
{
    public class BlogNotice:SkinnedBlogWebControl
    {

        public BlogNotice()
        {
            SkinFileName = "BlogNotice.ascx";
        }

        private Literal Literal;
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            Literal = (Literal)Skin.FindControl("Literal1");
            Literal.Text = BWeblog_Notice.GetLatestNotice().Notice_Content;
        }
    }
}
