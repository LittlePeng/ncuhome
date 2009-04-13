using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;


namespace Ncuhome.Blog.Core
{
    public  class BWeblog_Comment : BlogTableBase
    {
      
        /// <summary>
        /// 获取所有（分页）
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Comment> GetAllPaged(int PageIndex,int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Comments.Select(p => p).OrderByDescending(p => p.Comment_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }
        
        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Weblog_Comment GetByID(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Comments.Select(p => p).Single(p => p.Comment_Id == ID);
        }

        /// <summary>
        /// 根据LogUID获取
        /// </summary>
        /// <param name="LogUID"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Comment> GetByLogUID(int LogUID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Comments.Where(p => p.Comment_UserId == LogUID);
        }
        /// <summary>
        /// 根据LogUID获取时间反序
        /// </summary>
        /// <param name="LogUID"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Comment> GetByLogUIDDesc(int LogUID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Comments.Where(p => p.Comment_UserId == LogUID).OrderByDescending(p => p.Comment_CreateTime);
        }
        
        /// <summary>
        /// 根据logid获取对应的评论总数
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public static int GetCountByLogID(int LogID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Comments.Where(p => p.Comment_LogId == LogID).Count();
        }
        /// <summary>
        /// 根据LogUID获取最新评论15条
        /// </summary>
        /// <param name="LogUID"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Comment> GetTopCommentByLogUID(int LogUID)
        {

            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Comments.Where(p => p.Comment_UserId == LogUID).OrderByDescending(p => p.Comment_CreateTime).Take(15);     
        }
        /// <summary>
        /// 根据LogID获取
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Comment> GetByLogID(int LogID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Comments.Select(p => p).Where(p=>p.Comment_LogId==LogID).OrderByDescending(p=>p.Comment_CreateTime);
        }
        /// <summary>
        /// 根据LogID获取（分页）
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Comment> GetByLogIDPaged(int PageIndex, int Length, int LogID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Comments.Select(p => p).Where(p => p.Comment_LogId == LogID).Skip((PageIndex-1)*Length).Take(Length);
        }



        /// <summary>
        /// 根据ID删除评论
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool DeleteByID(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            //int? LogID = -1;
            try
            {
                BD.Weblog_Comments.DeleteOnSubmit(BD.Weblog_Comments.Select(p => p).Single(p => p.Comment_Id == ID));
                BD.SubmitChanges();
                
            }
            catch { return false; }
            if(BWeblog_log.MinusCommentCount(Blog.Core.BlogContext.Current.LogId))
            return true;
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据Logid删除
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public static bool DeleteByLogID(int LogID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                BD.Weblog_Comments.DeleteAllOnSubmit(  BD.Weblog_Comments.Select(p => p).Where(p => p.Comment_LogId == LogID));
                BD.SubmitChanges();
            }
            catch { return false; }
            return true;
        }
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="WC"></param>
        /// <returns></returns>
        public static bool Insert(Weblog_Comment WC)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                BD.Weblog_Comments.InsertOnSubmit(WC);
                BD.SubmitChanges();
            }
            catch { return false; }
            BWeblog_log.AddCommentCount(WC.Comment_LogId);
            return true;
        }
    }

}
