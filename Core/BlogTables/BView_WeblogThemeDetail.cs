using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;

namespace Ncuhome.Blog.Core
{
    public  class BView_WeblogThemeDetail:BlogTableBase
    {
        public static View_WeblogThemeDetail GetByBlogUserId(int BlogUserId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.View_WeblogThemeDetails.Where(p => p.User_Id == BlogUserId);
            if (temp.Count() >= 1)
                return temp.First();
            else
                return null;
        }
    }
}
