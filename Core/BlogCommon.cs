using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Blog.Core
{
   public  class BlogCommon
    {
       public static string CheckUserPic(object PicPath)
       {
           if (PicPath == null||PicPath.ToString()=="")
               return "/images/defaulthead.gif";
           else
               return "http://resource.ncuhome.cn/Blog/ThumbnailImage/UserHead/"+PicPath.ToString();
       }
    }
}
