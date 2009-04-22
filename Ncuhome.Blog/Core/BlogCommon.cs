using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Blog.Core
{
   public  class BlogCommon
    {
       //llj098,20090422
       static string UPLOADPATH_HARDCODE = @"http://resource.ncuhome.cn/Blog/ThumbnailImage/UserHead/";
       /// <summary>
       /// 获得用户的头像,llj099,0422
       /// </summary>
       /// <param name="PicPath"></param>
       /// <returns></returns>
       public static string CheckUserPic(object PicPath)
       {
           if (PicPath == null || PicPath.ToString() == "")
               return "/images/defaulthead.gif";
           else
               return UPLOADPATH_HARDCODE + PicPath.ToString();
       }
    }
}
