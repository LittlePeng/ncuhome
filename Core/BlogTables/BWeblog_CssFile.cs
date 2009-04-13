using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;

namespace Ncuhome.Blog.Core
{
  public    class BWeblog_CssFile :BlogTableBase
    {
      /// <summary>
      /// 根据Id获取
      /// </summary>
      /// <param name="Id"></param>
      /// <returns></returns>
      public static Weblog_CssFile GetById(int Id)
      {
          BlogDataDataContext BD = new BlogDataDataContext();
         var temp= BD.Weblog_CssFiles.Where(p => p.CssFile_Id == Id);
         if (temp.Count() == 0)
             return new Weblog_CssFile();
         else
             return temp.First();
      }
      /// <summary>
      /// 根据GroupId来获取模板的数量
      /// </summary>
      /// <param name="ThemeId"></param>
      /// <returns></returns>
      public static int GetCountByThemeId(int ThemeId)
      {
          BlogDataDataContext BD = new BlogDataDataContext();
          return BD.Weblog_CssFiles.Where(p => p.CssFile_ThemeId == ThemeId).Count();
          BD.SubmitChanges();
      }
      public static void Insert(Weblog_CssFile WC)
      {
          BlogDataDataContext BD = new BlogDataDataContext();
          BD.Weblog_CssFiles.InsertOnSubmit(WC);
          BD.SubmitChanges();
      }
      public static void DeleteById(int Id)
      {
          BlogDataDataContext BD = new BlogDataDataContext();
          var temp = BD.Weblog_CssFiles.Where(p => p.CssFile_Id == Id);
          BD.Weblog_CssFiles.DeleteAllOnSubmit(temp);
          BD.SubmitChanges();
      }
    }

}
