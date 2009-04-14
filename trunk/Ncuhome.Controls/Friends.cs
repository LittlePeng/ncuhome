using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls
{
    public  class Friends :SkinnedBlogWebControl
    {
        private  Repeater repeater1;
        public Friends()
        {
            SkinFileName = "Friend.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            
        }
        public override void DataBind()
        {

            base.DataBind();
        }
    }
}
