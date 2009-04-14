using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Core
{
   public  class BWeblog_UserCss:BlogTableBase
    {
        /// <summary>
        /// 根据CssId返回集合
        /// </summary>
        /// <param name="CssId"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_UserCss> GetUserCssByCssId(int CssId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_UserCsses.Where(p => p.UserCss_Id == CssId);
        }
        public static IEnumerable<Weblog_UserCss> GetByBlogUserId(int BlogUserId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_UserCsses.Where(p=>p.UserCss_UserId==BlogUserId);
        }
        /// <summary>
        /// 插入UserCss记录
        /// </summary>
        /// <param name="WUC"></param>
        public static void Insert(Weblog_UserCss WUC)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            BD.Weblog_UserCsses.InsertOnSubmit(WUC);
            BD.SubmitChanges();
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="WUC"></param>
        public static void Update(Weblog_UserCss WUC)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.Weblog_UserCsses.Single(p => p.UserCss_Id == WUC.UserCss_Id);
            temp.UserCss_CssFileId = WUC.UserCss_CssFileId;
            temp.UserCss_Used = WUC.UserCss_Used;
            temp.UserCss_UserId = WUC.UserCss_UserId;
            BD.SubmitChanges();
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="CssId"></param>
        public static void Delete(int CssId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.Weblog_UserCsses.Single(p => p.UserCss_Id == CssId);
            BD.Weblog_UserCsses.DeleteOnSubmit(temp);
            BD.SubmitChanges();
        }
        public static bool CheckHasCssFile(int BlogUserId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            if (BD.Weblog_UserCsses.Where(p => p.UserCss_UserId == BlogUserId).Count() >= 1)
                return true;
            else
                return false;
        }
    }
}
