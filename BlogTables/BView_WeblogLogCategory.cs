using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Core
{
    public class BView_WeblogLogCategory:BlogTableBase
    {
        /// <summary>
        /// 根据CateID和UID来获取用户log的数量
        /// </summary>
        /// <param name="CateID"></param>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static int GetLogCountByCateIDAndUID(int CateID, int UID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogLogCategorys.Where(p => p.Log_CateId == CateID && p.Log_UserId == UID && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime <= DateTime.Now).Count();
        }
        /// <summary>
        /// 根据CateID和UID来获取用户logs
        /// </summary>
        /// <param name="CateID"></param>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogLogCategory> GetLogsByCateIDAndUID(int CateID, int UID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogLogCategorys.Where(p => p.Log_CateId == CateID && p.Log_UserId == UID && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime <= DateTime.Now);
        }

        public static IEnumerable<View_WeblogLogCategory> GetLogsByUID(int UID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogLogCategorys.Where(p => p.Log_UserId == UID && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime <= DateTime.Now);
        }
        /// <summary>
        /// 根据LogID来获取文章种类的名字
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public static View_WeblogLogCategory GetByLogID(int LogID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.View_WeblogLogCategorys.Where(p => p.Log_Id == LogID && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime <= DateTime.Now);
            if (temp.Count() > 0)
                return temp.First();
            else
                return null;
        }

        /// <summary>
        /// 根据搜索关键字和UID来获取Log数量
        /// </summary>
        /// <param name="LogTitle"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static int GetCountByLogTitleAndUID(string LogTitle, int UserId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogLogCategorys.Select(p => p).Where(p => p.Log_Title.Contains(LogTitle) && p.Log_UserId == UserId && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now).Count();
        }

        /// <summary>
        /// 根据标题关键字进行模糊查询获取Log分页
        /// </summary>
        /// <param name="LogTitle"></param>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogLogCategory> GetByLogTitleAndUIDPaged(string LogTitle, int UserId, int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogLogCategorys.Select(p => p).Where(p => p.Log_Title.Contains(LogTitle) && p.Log_UserId == UserId && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now).OrderByDescending(p => p.Log_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
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
            return BD.View_WeblogLogCategorys.Select(p => p).Where(p => p.Log_CateId == LogCateID && p.Log_UserId == UID && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now).Count();
        }

        /// <summary>
        /// 根据文章种类ID和UID来获取log分页
        /// </summary>
        /// <param name="LogCateID"></param>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogLogCategory> GetByLogCateIDAndUIDPaged(int LogCateID, int UID, int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogLogCategorys.Select(p => p).Where(p => p.Log_CateId == LogCateID && p.Log_UserId == UID && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now).OrderByDescending(p => p.Log_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BlogUID">用户ID</param>
        /// <param name="Year">年</param>
        /// <param name="Day">日</param>
        /// <param name="Month">月</param>
        /// <returns></returns>
        public static int GetCountYearAndMonthAndDay(int BlogUID, int Year, int Month, int Day)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogLogCategorys.Where(p => p.Log_UserId == BlogUID && p.Log_CreateTime.Year == Year && p.Log_CreateTime.Month == Month && p.Log_CreateTime.Day == Day && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime <= DateTime.Now).Count();
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
        public static IEnumerable<View_WeblogLogCategory> GetByBlogYearAndMonthAndDayPaged(int BlogUID, int Year, int Month, int Day, int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogLogCategorys.Where(p => p.Log_UserId == BlogUID && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime.Year == Year && p.Log_CreateTime.Month == Month && p.Log_CreateTime.Day == Day && p.Log_CreateTime <= DateTime.Now).OrderByDescending(p => p.Log_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
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
            return BD.View_WeblogLogCategorys.Where(p => p.Log_UserId == BlogUID && p.Log_CreateTime.Year == Year && p.Log_CreateTime.Month == Month && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime <= DateTime.Now).Count();
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
        public static IEnumerable<View_WeblogLogCategory> GetByBlogYearAndMonthPaged(int BlogUID, int Year, int Month, int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogLogCategorys.Where(p => p.Log_UserId == BlogUID && p.Log_IsDraft == false && p.Log_IsVisible == true && p.Log_CreateTime.Year == Year && p.Log_CreateTime.Month == Month && p.Log_CreateTime <= DateTime.Now).OrderByDescending(p => p.Log_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }

        /// <summary>
        /// 获取一个用户博文数量
        /// </summary>
        /// <param name="BlogUID"></param>
        /// <returns></returns>
        public static int GetBLogCountByUID(int BlogUID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogLogCategorys.Where(p => p.Log_UserId == BlogUID && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now).Count();
        }

        /// <summary>
        ///  根据UID获取日志(分页)
        /// </summary>
        /// <param name="BlogUID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogLogCategory> GetByBlogUIDPaged(int BlogUID, int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogLogCategorys.Select(p => p).Where(p => p.Log_UserId == BlogUID && p.Log_IsVisible == true && p.Log_IsDraft == false && p.Log_CreateTime <= DateTime.Now).OrderByDescending(p => p.Log_CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }
    }
}
