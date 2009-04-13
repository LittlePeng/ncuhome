using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;
using System.Data.Linq;

namespace Ncuhome.Blog.Core
{
    public class BWeblog_User : BlogTableBase
    {
        public static void Insert(Weblog_User WU)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            BD.Weblog_Users.InsertOnSubmit(WU);
            BD.SubmitChanges();
        }
        /// <summary>
        /// 获取所有(分页)
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_User> GetAllPaged(int PageIndex, int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Users.Select(p => p).OrderByDescending(p => p.CreateTime).Skip((PageIndex - 1) * Length).Take(Length);
        }

        /// <summary>
        /// myself：要利用Linq2Sql的延迟
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_User> GetAllPaged(int PageIndex, int Length, out int Count)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var users = BD.Weblog_Users.Select(p => p).Where(p => p.User_TxzId < 200000).OrderByDescending(p => p.CreateTime);

            Count = users.Count();
            return users.Skip((PageIndex - 1) * Length).Take(Length);
        }

        /// <summary>
        /// 根据用户域名来获取MFIID
        /// </summary>
        /// <param name="Domain"></param>
        /// <returns></returns>
        public static int GetMfiidByDomain(string Domain)
        {
            BlogDataDataContext BD = new BlogDataDataContext();

            //var user = BD.Weblog_Users.Single(p => p.User_DomainName.Trim() == Domain.Trim());
            //if (user != null)
            //{
            //    //
            //}

            try
            {
                return Convert.ToInt32(BD.Weblog_Users.Single(p => p.User_DomainName.Trim() == Domain.Trim()).User_FIID);
            }
            catch (Exception)
            {

                return -1;
                //throw;
            }
        }
        /// <summary>
        /// 根据logid来获取用户域名
        /// </summary>
        /// <param name="logId">日记ID</param>
        /// <returns></returns>
        public static string GetUserDomainByLogID(int logId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            //string domain = "";
            //int userId = -1;
            Weblog_Log temp = null;
            var WL = BD.Weblog_Logs.Where(p => p.Log_Id == logId);
            if (WL.Count() > 0)
            {
                temp = WL.First();
                var WU = BD.Weblog_Users.Where(p => p.User_Id == temp.Log_UserId);
                if (WU.Count() > 0)
                {
                    return WU.First().User_DomainName;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Weblog_User GetByID(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            Weblog_User temp = null;
            var ret = BD.Weblog_Users.Select(p => p).Where(p => p.User_Id == ID);
            if (ret.Count() > 0)
                temp = ret.First();
            else
            {
                temp = new Weblog_User();
                temp.User_NickName = "匿名";
            }
            return temp;
        }
        /// <summary>
        /// 根据用户访问量获取blog之星
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_User> GetTopUsers(int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Users.Select(p => p).Where(p => p.User_PortraitUrl != "").OrderByDescending(p => p.User_BeViewCount).Take(Length);
        }
        /// <summary>
        /// 博客之星（去几天之内的日志访问量最多的一个）
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_User> GetTopUsersInAnyDay(int Length, int Days)
        {
            string ToDays = DateTime.Now.AddDays(-Days).ToString();
            string Sqlstr = "SELECT top " + Length.ToString() + " * " +
            " FROM [NCUHOME2006].[dbo].[Weblog_User]" +
            " where User_Id in (select top 20 Log_UserId" +
            " from dbo.Weblog_Log where Log_IsDraft=0 and  Log_IsPasssword=0 and Log_IsVisible =1 and log_CreateTime <='" + DateTime.Now + "'" +
            " and Log_CreateTime>'" + ToDays + "'" +
            " group by Log_UserId" +
            " order by sum(Log_ViewCount)  desc) and User_TxzId<200000  ";
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.ExecuteQuery<Weblog_User>(Sqlstr, "");

        }
        /// <summary>
        /// 根据blog浏览量获取精选博文(几天之内的日志)
        /// </summary>
        /// <param name="Length">数量</param>
        /// <param name="Day">天数</param>
        /// <returns></returns>

        public static IEnumerable<View_WeblogUserLog> GetTopUsersBlogByAnyDays(int PageIndex, int Length, int Day)
        {
            DateTime da = DateTime.Now.AddDays(-Day);
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserLogs.Where(p => p.Log_IsDraft == false && p.Log_IsVisible == true && p.User_PortraitUrl != null && p.Log_CreateTime > da && p.Log_CreateTime <= DateTime.Now).OrderByDescending(p => p.Log_ViewCount).Skip((PageIndex - 1) * Length).Take(Length);
        }
        /// <summary>
        /// 根据最近发表日记的时间来获取用户动态
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogUserLog> GetTopUser(int Length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserLogs.Select(p => p).Where(p => p.Log_IsDraft == false && p.Log_IsIndexShow == true && p.User_TxzId < 200000 && p.Log_IsPasssword == false && p.Log_IsVisible == true && p.User_PortraitUrl != null && p.Log_CreateTime <= DateTime.Now).OrderByDescending(p => p.Log_CreateTime).Take(Length);
        }

        /// <summary>
        /// 根据用户昵称来获取用户信息
        /// </summary>
        /// <param name="NickName"></param>
        /// <returns></returns>
        public static Weblog_User GetByNickName(string NickName)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            Weblog_User temp = null;
            var ret = BD.Weblog_Users.Select(p => p).Where(p => p.User_NickName == NickName);
            if (ret.Count() > 0)
                temp = ret.First();
            else
            {
                temp = new Weblog_User();
                temp.User_NickName = "匿名";
            }
            return temp;
        }


        public static Weblog_User GetByFIID(int FIID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            Weblog_User temp = null;
            var ret = BD.Weblog_Users.Select(p => p).Where(p => p.User_FIID == FIID);
            if (ret.Count() > 0)
                temp = ret.First();
            else
            {
                temp = new Weblog_User();
                temp.User_NickName = "匿名";
            }
            return temp;
        }
        public static Weblog_User getByTxzID(int TxzID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            Weblog_User temp = new Weblog_User();
            var ret = BD.Weblog_Users.Select(p => p).Where(p => p.User_TxzId == TxzID);
            if (ret.Count() > 0)
                temp = ret.First();
            else
            {
                temp = new Weblog_User();
                temp.User_NickName = "匿名";
            }
            return temp;
        }

        public static bool Update(Weblog_User WU)
        {
            BlogDataDataContext BD = new BlogDataDataContext();


            Weblog_User up = BD.Weblog_Users.Select(p => p).Single(p => p.User_Id == WU.User_Id);

            //up.User_Amimation = WU.User_Amimation;
            up.User_BeViewCount = WU.User_BeViewCount;
            up.User_Book = WU.User_Book;
            up.User_NickName = WU.User_NickName;
            //up.User_CellPhone = WU.User_CellPhone;
            //up.User_CommentCount = WU.User_CommentCount;
            up.User_DomainName = WU.User_DomainName;
            //up.User_Doodle = WU.User_Doodle;
            //up.User_FixedPhone = WU.User_FixedPhone;
            up.User_Game = WU.User_Game;
            up.User_HomePage = WU.User_HomePage;
            up.User_Interest = WU.User_Interest;
            up.User_Movie = WU.User_Movie;
            up.User_MSN = WU.User_MSN;
            up.User_Music = WU.User_Music;
            //up.User_Name = WU.User_Name;
            //up.User_Number = WU.User_Number;
            //up.User_PortraitUrl =  WU.User_PortraitUrl;
            if (WU.User_PortraitUrl != null)
            {
                up.User_PortraitUrl = WU.User_PortraitUrl;
            }
            up.User_QQ = WU.User_QQ;
            if (WU.User_BeViewLastTime != null)
            {
                up.User_BeViewLastTime = WU.User_BeViewLastTime;
            }
            //up.User_Sport=WU.User_Sport;
            BD.SubmitChanges();

            return true;
        }
        /// <summary>
        /// 用户登陆次数加1
        /// </summary>
        /// <param name="UserID">用户UserID</param>
        public static void AddLoginTimes(int? UserID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            Weblog_User temp = null;
            var WU = BD.Weblog_Users.Select(p => p).Where(p => p.User_Id == UserID);
            if (WU.Count() > 0)
            {
                temp = WU.First();
            }
            try
            {
                if (temp.User_LoginTimes == null)
                {
                    temp.User_LoginTimes = 1;
                }
                else
                {
                    temp.User_LoginTimes += 1;
                }
                BD.SubmitChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 访问量加1
        /// </summary>
        /// <param name="UserID"></param>
        public static void AddBeViewCount(int? UserID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.Weblog_Users.Single(p => p.User_Id == UserID);

            if (temp.User_BeViewCount == null)
            {
                temp.User_BeViewCount = 1;
            }
            else
            {
                temp.User_BeViewCount += 1;
            }
            BD.SubmitChanges();
        }
        public static void AddCommentCount(int? UID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            Weblog_User temp = null;
            var WU = BD.Weblog_Users.Select(p => p).Where(p => p.User_Id == UID);
            if (WU.Count() > 0)
            {
                temp = WU.First();
            }
            try
            {
                temp.User_CommentCount += 1;
                BD.SubmitChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 用户日志数量加1
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static bool AddLogCount(int? UserID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                Weblog_User up = BD.Weblog_Users.Select(p => p).Single(p => p.User_Id == UserID);
                up.User_LogCount = up.User_LogCount + 1;
                BD.SubmitChanges();
            }
            catch { return false; } return true;
        }
        /// <summary>
        /// 用户日志数量减1
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static bool MinusLogCount(int? UserID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                Weblog_User up = BD.Weblog_Users.Select(p => p).Single(p => p.User_Id == UserID);
                up.User_LogCount = up.User_LogCount - 1;
                BD.SubmitChanges();
            }
            catch { return false; } return true;
        }
        /// <summary>
        ///  根据FIID获取用户的博客Userid
        /// </summary>
        /// <param name="FiiD"></param>
        /// <returns></returns>
        public static int GetUserIDByFiiD(int FiiD)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            int? TxzID = BView_CommonFunction.GetTxzIDByFIID(FiiD);
            int UserId = -1;
            UserId = BD.Weblog_Users.First(p => p.User_TxzId == TxzID).User_Id;
            return UserId;
        }

        /// <summary>
        /// 重置用户的所有评论总数
        /// </summary>
        /// <param name="FIID">用户FIID</param>
        public static void SetUserCommentCount(int? UID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            Weblog_User temp = null;
            var WU = BD.Weblog_Users.Select(p => p).Where(p => p.User_Id == UID);
            if (WU.Count() > 0)
            {
                temp = WU.First();
                try
                {
                    temp.User_CommentCount = BView_WeblogUserComment.GetCommentCountByUID(UID);
                    BD.SubmitChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        /// <summary>
        /// 存档  --不知道这个效率有没有问题啊
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static LogNav[] GetLogNav(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var t = from n in BD.Weblog_Logs
                    where
                    n.Log_UserId == ID && n.Log_IsDraft == false && n.Log_IsVisible == true && n.Log_CreateTime <= DateTime.Now
                    group n by new { n.Log_CreateTime.Year, n.Log_CreateTime.Month } into g
                    select new { c = g.Count(), t = g.First().Log_CreateTime };
            List<LogNav> log = new List<LogNav>();

            foreach (var tt in t)
            {
                log.Add(new LogNav(tt.c, tt.t.Year, tt.t.Month));
            }
            return log.OrderByDescending(p => p.Month).OrderByDescending(p => p.Year).ToArray();
            //var temp = BD.Weblog_Logs.Where(p => p.Log_UserId == ID).GroupBy(p => p.Log_CreateTime.Year && p.Log_CreateTime.Month);
        }
        /// <summary>
        /// 检验用户域名是否存在
        /// </summary>
        /// <param name="Domain"></param>
        /// <returns></returns>
        public static bool CheckDomain(string Domain)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.Weblog_Users.Where(p => p.User_DomainName == Domain);
            if (temp.Count() > 0)
            {
                return true;
            }
            return false;
        }
        public static bool CheckNickName(string NickName)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.Weblog_Users.Where(p => p.User_NickName == NickName);
            if (temp.Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
    public class LogNav
    {
        public LogNav(int Count, int Year, int Month)
        {
            this.Count = Count;
            this.Year = Year;
            this.Month = Month;
        }
        public int Count { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
