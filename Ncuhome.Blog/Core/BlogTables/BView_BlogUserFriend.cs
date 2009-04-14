using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;
using System.Data.Linq;

namespace Ncuhome.Blog.Core
{
    public  class BView_BlogUserFriend :BlogTableBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static IEnumerable<View_BlogUserFriend> GetByUserID(int UserID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_BlogUserFriends.Where(p => p.Frd_UserId == UserID);
        }

        public static View_BlogUserFriend GetByNickName(string NickName)
        {
            BlogDataDataContext BD = new BlogDataDataContext();

            return BD.View_BlogUserFriends.Single(p => p.User_NickName == NickName);
            //return BD.View_BlogUserFriends.select(p => p.User_NickName == NickName);
        
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="TxzUID"></param>
        /// <returns></returns>
        public static IEnumerable<View_BlogUserFriend> GetByTxzUID(int TxzUID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_BlogUserFriends.Where(p => p.Frd_TxzUID == TxzUID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FIID"></param>
        /// <returns></returns>
        public static IEnumerable<View_BlogUserFriend> GetByFIID(int FIID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            int? TxzID = BView_CommonFunction.GetTxzIDByFIID(FIID);
            return BD.View_BlogUserFriends.Where(p => p.Frd_TxzUID == TxzID);
        }
        /// <summary>
        /// 根据用户FIID获取用户好友分页
        /// </summary>
        /// <param name="FIID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static IEnumerable<View_BlogUserFriend> GetByFIIDPaged(int FIID, int PageIndex, int length)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            int? TxzID = BView_CommonFunction.GetTxzIDByFIID(FIID);
            return BD.View_BlogUserFriends.Where(p => p.Frd_TxzUID == TxzID).Skip((PageIndex - 1) * length).Take(length);
        }
        public static int GetCountByFIID(int FIID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            int? TxzID = BView_CommonFunction.GetTxzIDByFIID(FIID);
            return BD.View_BlogUserFriends.Where(p => p.Frd_TxzUID == TxzID).Count();
        }
        
    }
}
