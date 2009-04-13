using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Ncuhome.Blog.Controls
{
   public  class Default_Ower_Head :SkinnedBlogWebControl
    {
        public Default_Ower_Head()
        {
            SkinFileName = "Default_Ower_Head.ascx";
            IsThemed = true;
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            if (Ncuhome.Blog.Core.BlogContext.Current.ThemeName.Contains("space"))
            {
                HttpContext.Current.Response.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                HttpContext.Current.Response.Write("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            }
            if (Ncuhome.Blog.Core.BlogContext.Current.ThemeName.Contains("baidu"))
            {
                HttpContext.Current.Response.Write("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
                HttpContext.Current.Response.Write("<HTML xmlns=\"http://www.w3.org/1999/xhtml\">");
            }
            if (Ncuhome.Blog.Core.BlogContext.Current.ThemeName.Contains("X-space"))
            {
                HttpContext.Current.Response.Write("<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.01 Transitional//EN' 'http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd'>");
                HttpContext.Current.Response.Write("<HTML xmlns='http://www.w3.org/1999/xhtml'>");

            }
            if (Ncuhome.Blog.Core.BlogContext.Current.ThemeName.Contains("Lxblog"))
            {
                HttpContext.Current.Response.Write("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd\">");
                HttpContext.Current.Response.Write("<HTML xmlns=\"http://www.w3.org/1999/xhtml\">");
            }
            if (Ncuhome.Blog.Core.BlogContext.Current.ThemeName.Contains("blogbus"))
            {
                HttpContext.Current.Response.Write("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd\">");
                HttpContext.Current.Response.Write("<HTML xmlns=\"http://www.w3.org/1999/xhtml\">");
            }
        }
    }
}
