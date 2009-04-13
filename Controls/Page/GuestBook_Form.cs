using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Blog.Controls
{
   public class GuestBook_Form:SkinnedBlogWebControl
    {
        public GuestBook_Form()
        {
            IsThemed = true;
            SkinFileName = "GuestBook_Form.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            
        }
    }
}
