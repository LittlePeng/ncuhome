using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls
{
    public class VisitStat:SkinnedBlogWebControl
    {
        public VisitStat()
        {
            SkinFileName = "VisitStat.ascx";
            IsThemed = true;
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            //throw new NotImplementedException();
        }
    }
}
