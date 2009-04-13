using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;


namespace Ncuhome.Blog.Core
{
   public   class BGetCommentInfoByLogId : BlogTableBase 
    {
        public IEnumerable<View_GetCommentInforByLogId> GetByLogId(int LogId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_GetCommentInforByLogIds.Select(p => p).Where(p => p.Log_Id == LogId);
        }
        public IEnumerable<View_GetCommentInforByLogId> GetByUserId(int UserId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_GetCommentInforByLogIds.Select(p => p).Where(p => p.Log_UserId == UserId);
        }
        /// <summary>
        /// 根据LogUID获取最新评论15条
        /// </summary>
        /// <param name="LogUID"></param>
        /// <returns></returns>
        public static IEnumerable<View_GetCommentInforByLogId> GetTopCommentByLogUID(int LogUID)
        {

            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_GetCommentInforByLogIds.Where(p => p.Log_UserId == LogUID&&p.Log_IsDraft==false&&p.Log_IsVisible==true).OrderByDescending(p => p.Comment_CreateTime).Take(5);
        }
       /// <summary>
       /// 根据LogUID获取所有最新评论
       /// </summary>
       /// <param name="LogUID"></param>
       /// <returns></returns>
        public static IEnumerable<View_GetCommentInforByLogId> GetCommentsByLogUIDDesc(int LogUID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_GetCommentInforByLogIds.Where(p => p.Log_UserId== LogUID&&p.Log_IsDraft==false&&p.Log_IsVisible==true).OrderByDescending(p=>p.Comment_CreateTime);
        }
    }
}
