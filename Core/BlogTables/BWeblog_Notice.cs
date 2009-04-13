using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;
using System.Collections;

namespace Ncuhome.Blog.Core
{
   public class BWeblog_Notice
    {
       public static void Edit(Weblog_Notice WN)
       {
           BlogDataDataContext BD = new BlogDataDataContext();
           Weblog_Notice notice = BD.Weblog_Notices.Where(p => p.Notice_Type == 1).First();
           notice.Notice_Content = System.Web.HttpContext.Current.Server.HtmlEncode(WN.Notice_Content).Replace("\n", "<br />");
           notice.Notice_CreateTime = DateTime.Now;
           BD.SubmitChanges();
       }

       /// <summary>
       /// myself：更改方法名
       /// </summary>
       /// <param name="wn"></param>
       public static void Insert(Weblog_Notice wn)
       {
           BlogDataDataContext BD = new BlogDataDataContext();
           BD.Weblog_Notices.InsertOnSubmit(wn);
           BD.SubmitChanges();
       }
       
       /// <summary>
       /// myself：BD.Weblog_Notices.Count()返回的不是数据行数。
       /// </summary>
       /// <returns></returns>
       public static  Weblog_Notice GetLatestNotice()
       {
           BlogDataDataContext BD = new BlogDataDataContext();
           var notices = BD.Weblog_Notices.Where(p => p.Notice_Type == 1).OrderByDescending(p => p.ID);
           if (notices.Count() > 0)
           {
               return notices.First();
           }
           return null;

           //待改
           //if (BD.Weblog_Notices.Count() > 0)
           //{
           //    return BD.Weblog_Notices.Where(p=>p.Notice_Type==1).OrderByDescending(p => p.ID).First();
           //}
           //else
           //{ 
           //    return null;
           //}
       }
    }
}
