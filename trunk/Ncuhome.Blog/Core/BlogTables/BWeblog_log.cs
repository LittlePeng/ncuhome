using System;
using System.Collections.Generic;
using System.Linq;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;

namespace Ncuhome.Blog.Core
{
    public  class BWeblog_log : BlogTableBase
    {
        public BWeblog_log()
        { 
        }
        /// <summary>
        /// 获取所有日志
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Log> GetAllPaged(int PageIndex,int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Select(p => p).Where(p=>p.Log_IsVisible==true&&p.Log_IsDraft==false&&p.Log_CreateTime<=DateTime.Now).Skip((PageIndex - 1) * Length).Take(Length);
        }
        /// <summary>
        /// 获取最新的日志
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Log> GetLastestLogs(int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Where(p => p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_IsPasssword == false).OrderByDescending(p => p.Log_Id).Skip((PageIndex - 1) * Length).Take(Length);
        }
        /// <summary>
        ///  获取最新的日志(不包括class的)
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogUserLog> GetLastestLogsWithoutClass(int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserLogs.Where(p => p.Log_IsVisible == true &&p.User_TxzId<200000&& p.Log_IsDraft == false && p.Log_IsPasssword == false).OrderByDescending(p => p.Log_Id).Skip((PageIndex - 1) * Length).Take(Length);
        }
        /// <summary>
        /// 获取用户的最新日志
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <param name="BlogUserId"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Log> GetUserLastestLogs(int PageIndex, int Length, int BlogUserId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Where(p => p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_IsPasssword == false && p.Log_UserId == BlogUserId).OrderByDescending(p => p.Log_Id).Skip((PageIndex - 1) * Length).Take(Length);
        }
        /// <summary>
        /// 根据ID获取日志
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Weblog_Log GetByID(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            //AddViewCount(ID);
            Weblog_Log temp = null;
            var ret = BD.Weblog_Logs.Select(p => p).Where(p => p.Log_Id == ID && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now);
            if (ret.Count() > 0)
                temp = ret.First();
            return temp;
        }
        public static View_WeblogUserLog GetByIDAndFiid(int ID,int FiiD)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var ret = BD.View_WeblogUserLogs.Where(p => p.Log_Id == ID &&p.User_FIID==FiiD&& p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now);
            if (ret.Count() > 0)
               return ret.First();
            return null;
        }

        /// <summary>
        /// 根据ID获取日志或草稿
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Weblog_Log GetWithDraftByID(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            //AddViewCount(ID);
            Weblog_Log temp = null;
            var ret = BD.Weblog_Logs.Select(p => p).Where(p => p.Log_Id == ID && p.Log_IsVisible == true);
            if (ret.Count() > 0)
                temp = ret.First();
            return temp;
        }
        /// <summary>
        /// 根据用户UID和日记的标题来判断是否已经存在这篇日记
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="CreateTime"></param>
        /// <returns></returns>
        public static bool HasLogByUIDAndTitle(int UID, string Title,DateTime Time)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.Weblog_Logs.Where(p => p.Log_UserId == UID && (p.Log_Title.Trim()==Title.Trim()||p.Log_CreateTime==Time));
            if (temp.Count() > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 根据UID获取日志
        /// </summary>
        /// <param name="BlogUID"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Log> GetByBlogUID(int BlogUID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Select(p => p).Where(p => p.Log_UserId == BlogUID && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now).OrderByDescending(p => p.Log_CreateTime);
        }
        /// <summary>
        /// 移动一个类到另一个类中
        /// </summary>
        /// <param name="SourceCateId"></param>
        /// <param name="TagetCateId"></param>
        public static void UpdateLogCateIdAll(int SourceCateId, int TagetCateId)
        { 
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.Weblog_Logs.Where(p => p.Log_CateId == SourceCateId);
            foreach (var ret in temp)
            {
                ret.Log_CateId = TagetCateId;
              
            }
            BD.SubmitChanges();
        }
        /// <summary>
        /// 移动单个日志到
        /// </summary>
        /// <param name="SourceCateId"></param>
        /// <param name="TagetCateId"></param>
        /// <param name="LogId"></param>
        public static void UpdateLogCateIdSingle( int TagetCateId, int LogId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.Weblog_Logs.Where(p => p.Log_Id == LogId);
            foreach (var ret in temp)
            {
                ret.Log_CateId = TagetCateId;
            }
         BD.SubmitChanges();
        }
        /// <summary>
        /// 根据文章种类ID和UID来获取log数量
        /// </summary>
        /// <param name="LogCateID"></param>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static int GetCountByLogCateIDAndUID(int LogCateID, int UID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Select(p => p).Where(p => p.Log_CateId == LogCateID && p.Log_UserId == UID && p.Log_IsVisible == true && p.Log_IsDraft == false).Count();
        }
        /// <summary>
        /// 根据CateId获取log按时间反序
        /// </summary>
        /// <param name="CateId"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Log> GetByCateIdLogUIDDesc(Int32 CateId,Int32 LogUID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Where(p => p.Log_CateId == CateId && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now&&p.Log_UserId==LogUID).OrderByDescending(p => p.Log_CreateTime);
        }
        

        /// <summary>
        /// 根据文章种类ID和UID来获取log分页
        /// </summary>
        /// <param name="LogCateID"></param>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Log> GetByLogCateIDAndUIDPaged(int LogCateID, int UID, int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Select(p => p).Where(p => p.Log_CateId == LogCateID && p.Log_UserId == UID && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now).OrderByDescending(p => p.Log_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }

        /// <summary>
        /// 根据搜索关键字和UID来获取Log数量
        /// </summary>
        /// <param name="LogTitle"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static int GetCountByLogTitleAndUID(string LogTitle,int UserId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Select(p => p).Where(p => p.Log_Title.Contains(LogTitle) && p.Log_UserId == UserId && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now).Count();
        }
        /// <summary>
        /// 根据标题关键字进行模糊查询获取Log分页
        /// </summary>
        /// <param name="LogTitle"></param>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Log> GetByLogTitleAndUIDPaged(string LogTitle, int UserId, int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Select(p => p).Where(p => p.Log_Title.Contains(LogTitle) && p.Log_UserId == UserId && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now).OrderByDescending(p => p.Log_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }
        /// <summary>
        ///  根据UID获取日志(分页)
        /// </summary>
        /// <param name="BlogUID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Log> GetByBlogUIDPaged(int BlogUID, int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Select(p => p).Where(p => p.Log_UserId == BlogUID && p.Log_IsVisible == true && p.Log_IsDraft == false ).OrderByDescending(p => p.Log_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }

        /// <summary>
        /// 根据UID获取日志(分页)类别
        /// </summary>
        /// <param name="BlogUID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <param name="Cate_Id"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Log> GetByBlogUIDPaged(int BlogUID, int PageIndex, int Length,int Cate_Id)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Select(p => p).Where(p => p.Log_UserId == BlogUID && p.Log_CateId == Cate_Id && p.Log_IsVisible == true && p.Log_IsDraft == false).OrderByDescending(p => p.Log_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }

        /// <summary>
        ///  根据UID获取草稿(分页)
        /// </summary>
        /// <param name="BlogUID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Log> GetByBlogDraftUIDPaged(int BlogUID, int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Select(p => p).Where(p => p.Log_UserId == BlogUID && p.Log_IsVisible == true && p.Log_IsDraft == true ).OrderByDescending(p => p.Log_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }
        public static IEnumerable<Weblog_Log> GetByBlogYearAndMonth(int BlogUID, int Year, int Month)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Where(p => p.Log_UserId == BlogUID && p.Log_CreateTime.Year == Year && p.Log_CreateTime.Month == Month && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime <= DateTime.Now);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BlogUID">用户ID</param>
        /// <param name="Year">年</param>
        /// <param name="Month">月</param>
        /// <param name="Day">日</param>
        /// <param name="PageIndex">页面索引</param>
        /// <param name="Length">每页显示日记数量</param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Log> GetByBlogYearAndMonthAndDayPaged(int BlogUID, int Year, int Month,int Day, int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Where(p => p.Log_UserId == BlogUID && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime.Year == Year && p.Log_CreateTime.Month == Month && p.Log_CreateTime.Day == Day && p.Log_CreateTime <= DateTime.Now).OrderByDescending(p => p.Log_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }
        /// <summary>
        /// 根据年、月来获取日记分页
        /// </summary>
        /// <param name="BlogUID">用户ID</param>
        /// <param name="Year">年</param>
        /// <param name="Month">月</param>
        /// <param name="PageIndex">页面索引</param>
        /// <param name="Length">每页显示日记数量</param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Log> GetByBlogYearAndMonthPaged(int BlogUID, int Year, int Month,int PageIndex,int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Where(p => p.Log_UserId == BlogUID && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime.Year == Year && p.Log_CreateTime.Month == Month && p.Log_CreateTime <= DateTime.Now).OrderByDescending(p => p.Log_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BlogUID">用户ID</param>
        /// <param name="Year">年</param>
        /// <param name="Day">日</param>
        /// <param name="Month">月</param>
        /// <returns></returns>
        public static int GetCountYearAndMonthAndDay(int BlogUID, int Year, int Month,int Day)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Where(p => p.Log_UserId == BlogUID && p.Log_CreateTime.Year == Year && p.Log_CreateTime.Month == Month && p.Log_CreateTime.Day == Day && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime <= DateTime.Now).Count();
        }
        /// <summary>
        /// 根据年、月来获取日记总数
        /// </summary>
        /// <param name="BlogUID">用户ID</param>
        /// <param name="Year">年</param>
        /// <param name="Month">月</param>
        /// <returns></returns>
        public static int GetCountYearAndMonth(int BlogUID, int Year, int Month)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Where(p => p.Log_UserId == BlogUID && p.Log_CreateTime.Year == Year && p.Log_CreateTime.Month == Month && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime <= DateTime.Now).Count();
        }
        /// <summary>
        /// 获取一个用户博文数量
        /// </summary>
        /// <param name="BlogUID"></param>
        /// <returns></returns>
        public static int GetBLogCountByUID(int BlogUID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Where(p => p.Log_UserId == BlogUID && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now).Count();
        }
        /// <summary>
        /// 获取一个用户草稿数量
        /// </summary>
        /// <param name="BlogUID"></param>
        /// <returns></returns>
        public static int GetBLogDraftCountByUID(int BlogUID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Logs.Where(p => p.Log_UserId == BlogUID && p.Log_IsVisible == true && p.Log_IsDraft == true && p.Log_CreateTime <= DateTime.Now).Count();
        }

        //获得文章密码
        public static string GetPW(Int32 LogID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var s=BD.Weblog_Logs.Where(p => p.Log_Id ==LogID);
            string temp=null; 
            if (s.Count()>0)
            {
                temp=s.First().Log_PassWord;
            }
            else
            {

            }
            return temp;
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="WL"></param>
        /// <returns></returns>
        public static bool Insert(Weblog_Log WL)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
                BD.Weblog_Logs.InsertOnSubmit(WL);
            BD.SubmitChanges();
            return true;
            
        }
        public static bool Insert(Weblog_Log WL ,out int Log_Id)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            BD.Weblog_Logs.InsertOnSubmit(WL);
            BD.SubmitChanges();
            Log_Id = WL.Log_Id;
            return true;

        }
        
        
        /// <summary>
        /// 自动添加
        /// </summary>
        /// <param name="WL"></param>
        /// <returns></returns>
        public static void AutoInsert(Weblog_Log WL,out int LogId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
                BD.Weblog_Logs.InsertOnSubmit(WL);
            BD.SubmitChanges();
            LogId = WL.Log_Id; 
        }

        public static void Update(Weblog_Log WL)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            Weblog_Log temp = BD.Weblog_Logs.Single(p => p.Log_Id == WL.Log_Id);
            temp.Log_CateId = WL.Log_CateId;
            temp.Log_Title = WL.Log_Title;
            temp.Log_Content = WL.Log_Content;
            temp.Log_IsDraft = WL.Log_IsDraft;
            temp.Log_LastModiTime = WL.Log_LastModiTime;
            temp.Log_IsTop = WL.Log_IsTop;
            temp.Log_IsPasssword = WL.Log_IsPasssword;
            temp.Log_IsEnRePly = WL.Log_IsEnRePly;
            temp.Log_IsIndexShow = WL.Log_IsIndexShow;
            temp.Log_PassWord = WL.Log_PassWord;
            temp.Log_KeyWords = WL.Log_KeyWords;
            temp.Log_CreateTime = WL.Log_CreateTime;
            BD.SubmitChanges();
        }
        /// <summary>
        /// 删除日志(根据log_ID)
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool DeleteByID(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            int? UserID = -1;
            try
            {
                Weblog_Log up = BD.Weblog_Logs.Select(p => p).Single(p => p.Log_Id == ID && p.Log_IsVisible == true);
             up.Log_IsVisible = false;
             UserID = up.Log_UserId;
             BD.SubmitChanges();
             
            }
            catch
            { return false; }
            BWeblog_User.MinusLogCount(UserID);
            return true;
        }
        /// <summary>
        /// 删除日志（根据BlogUID）
        /// </summary>
        /// <param name="BlogUID"></param>
        /// <returns></returns>
        public static bool DeleteByBlogUID(int BlogUID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                IEnumerable<Weblog_Log> up= BD.Weblog_Logs.Select(p=>p).Where(p=>p.Log_UserId==BlogUID);
                foreach (Weblog_Log u in up)
                {
                    u.Log_IsVisible = false;
                }
                BD.SubmitChanges();
            }
            catch
            { return false; }
            return true;
        }
        //不显示加密文章
        public static string ShowIfNotSecret(string LogContent,bool Ispassword)
        {
            if (Ispassword == false)
            {
                string logContent = Globals.HtmlDecode(LogContent);
                logContent = System.Text.RegularExpressions.Regex.Replace(logContent, "<[^>]*?>", "");
                logContent = logContent.Replace("  ","");
                if (logContent.Length<=100)
                {
                    return logContent;
                }
                else
                {
                    return logContent.Substring(0, 100);
                }
                
            }
            else
            {
                return "该文章已加密!";
            }
           
            
        } 
        


        /// <summary>
        /// 点击数加1
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool AddViewCount(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                Weblog_Log up = BD.Weblog_Logs.Select(p => p).Single(p => p.Log_Id == ID);
                up.Log_ViewCount = up.Log_ViewCount + 1;
                BD.SubmitChanges();
            }
            catch
            { return false; }
            return true;
        }
        /// <summary>
        /// 评论数加1
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool  AddCommentCount(int? ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                Weblog_Log up = BD.Weblog_Logs.Select(p => p).Single(p => p.Log_Id == ID);
                up.Log_CommentCount = up.Log_CommentCount + 1;
                BD.SubmitChanges();
            }
            catch
            { return false; }
            return true;
        }
        /// <summary>
        /// 推荐加1
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool AddRecommendCount(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                Weblog_Log up = BD.Weblog_Logs.Select(p => p).Single(p => p.Log_Id == ID);
                up.Log_RecommendCount = up.Log_RecommendCount + 1;
                BD.SubmitChanges();
            }
            catch
            { return false; }
            return true;
        }
        /// <summary>
        /// 点击数减1
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool MinusViewCount(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                Weblog_Log up = BD.Weblog_Logs.Select(p => p).Single(p => p.Log_Id == ID);
                up.Log_ViewCount = up.Log_ViewCount - 1;
                BD.SubmitChanges();
            }
            catch
            { return false; }
            return true;
        }
        /// <summary>
        /// 评论数减1
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool MinusCommentCount(int? ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                Weblog_Log up = BD.Weblog_Logs.Select(p => p).Single(p => p.Log_Id == ID);
                up.Log_CommentCount = up.Log_CommentCount - 1;
                BD.SubmitChanges();
            }
            catch
            { return false; }
            return true;
        }
        /// <summary>
        /// 推荐减1
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool MinusRecommendCount(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                Weblog_Log up = BD.Weblog_Logs.Select(p => p).Single(p => p.Log_Id == ID);
                up.Log_RecommendCount = up.Log_RecommendCount - 1;
                BD.SubmitChanges();
            }
            catch
            { return false; }
            return true;
        }

        /// <summary>
        /// 更新用户的日记数量统计
        /// </summary>
        /// <param name="UID"></param>
        public static void SetLogCountByUID(int UID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                Weblog_User WU = null;
                var WUCount = BD.Weblog_Users.Select(p => p).Where(p => p.User_Id == UID);
                if (WUCount.Count()>0)
                {
                    WU = WUCount.First();
                    WU.User_LogCount = BWeblog_log.GetBLogCountByUID(UID);
                    BD.SubmitChanges();
                }
                else
                {
                    WU = null;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
    }

}
