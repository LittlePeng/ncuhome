using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Linq;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;

namespace Ncuhome.Blog.Core
{
    public  class BView_WeblogUserComment :BlogTableBase
    {
        public static IEnumerable<View_WeblogUserComment> GetByLogId(int LogId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserComments.Where(p => p.Comment_LogId == LogId);
        }
        /// <summary>
        /// 根据userid来获取
        /// </summary>
        /// <param name="LogUID"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogUserComment> GetByLogUID(int LogUID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserComments.Where(p => p.Comment_UserId == LogUID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <param name="BlogUserId"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogUserComment> GetUserLastestComments(int PageIndex, int Length, int BlogUserId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserComments.Where(p => p.Comment_UserId == BlogUserId).OrderByDescending(p=>p.Comment_CreateTime).Skip((PageIndex-1)*Length).Take(Length);
        }
        /// <summary>
        /// 根据logID来获取评论分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogUserComment> GetCommentsByLogID(int PageIndex, int Length, int LogID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserComments.Where(p => p.Comment_LogId == LogID).OrderBy(p => p.Comment_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogUserComment> GetLastestComments(int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserComments.Select(p=>p).OrderByDescending(p => p.Comment_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }


        public static IEnumerable<View_WeblogUserComment> GetTopCommentByLogUID(int LogUID)
        {

            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserComments.Where(p => p.Comment_UserId == LogUID).Take(10);
        }
        /// <summary>
        /// 根据用户UID来获取评论总数
        /// </summary>
        /// <param name="FIID"></param>
        /// <returns></returns>
        public static int GetCommentCountByUID(int? UID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            int tempCount = 0;
            foreach (Weblog_Log WL in BWeblog_log.GetByBlogUID(Convert.ToInt32(UID)))
            {
                tempCount += BD.View_WeblogUserComments.Where(p => p.Comment_LogId == WL.Log_Id).Count();
            }
            return tempCount;
        }
    }
}
