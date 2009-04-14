using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Blog.Controls
{
    public class Top:SkinnedBlogWebControl
    {
        public Top()
        {
            SkinFileName = "Top.ascx";
            IsThemed = true;
        }

        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
          
        }
    }
}
