using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;

namespace Ncuhome.Blog.Core
{
    public class BWeblog_UserRssLink
    {
        /// <summary>
        /// 根据UID获取用户的RssLink
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_UserRssLink> GetRssLinkByUID(int? UID)
        {
            BlogDataDataContext BD=new BlogDataDataContext();
            return BD.Weblog_UserRssLinks.Where(p => p.Weblog_UserId == UID&&p.Weblog_UserRssIsPassed==true);
        }
        /// <summary>
        /// 根据UID获取用户的RssLink数
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static int GetRssLinkCountByUID(int? UID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_UserRssLinks.Where(p => p.Weblog_UserId == UID&&p.Weblog_UserRssIsPassed==true).Count();
        }
        /// <summary>
        /// 插入新的RssLink
        /// </summary>
        /// <param name="WURL"></param>
        public static bool InsertRssLink(Weblog_UserRssLink WURL)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            BD.Weblog_UserRssLinks.InsertOnSubmit(WURL);
            BD.SubmitChanges();
            return true;
        }
        /// <summary>
        /// 根据ID来删除RssLink
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool DeleteRssLinkByID(int UID,int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            Weblog_UserRssLink temp = null;
            var WURL = BD.Weblog_UserRssLinks.Where(p => p.Weblog_UserRssLinkId == ID&&p.Weblog_UserId==UID);
            if (WURL.Count()>0)
            {
                temp = WURL.First();
                BD.Weblog_UserRssLinks.DeleteOnSubmit(temp);
                BD.SubmitChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 更新RSS镜像是否审核通过
        /// </summary>
        /// <param name="ID">RssLinkID</param>
        /// <returns></returns>
        public static bool UpdateRssLinkByID(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            Weblog_UserRssLink temp = null;
            var WURL = BD.Weblog_UserRssLinks.Where(p => p.Weblog_UserRssLinkId == ID);
            if (WURL.Count()>0)
            {
                temp = WURL.First();
                if (temp.Weblog_UserRssIsPassed==true)
                {
                    temp.Weblog_UserRssIsPassed = false;
                }
                else
                {
                    temp.Weblog_UserRssIsPassed = true;
                }
                BD.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
