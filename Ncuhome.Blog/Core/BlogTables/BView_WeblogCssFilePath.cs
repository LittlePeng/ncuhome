using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Core
{
   public  class BView_WeblogCssFilePath:BlogTableBase
    {
        /// <summary>
        ///返回Css文件路径集合
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static View_WeblogCssFilePath GetCssFilePathByUserId(int UserId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp= BD.View_WeblogCssFilePaths.Where(p => p.User_Id == UserId);
            if (temp.Count() >= 1)
                return temp.First();
            else
                return null;
        }
    }
}
