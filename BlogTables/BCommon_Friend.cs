using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Core
{
    public class BCommon_Friend : IBCommon_Friend
    {

        #region IBCommon_Friend 成员

        public IList<Common_Friend> GetAll()
        {
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                var friends = BDContext.Common_Friends.Select(f => f);
                if (friends.Count() > 0)
                {
                    return friends.ToList();
                }
                return null;
            }
        }

        public IList<Common_Friend> GetAllByPage(int pageIndex, int pageSize)
        {
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                var friends = BDContext.Common_Friends.Select(f => f).Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderByDescending(f => f.Frd_Id);
                if (friends.Count() > 0)
                {
                    return friends.ToList();
                }
                return null;
            }
        }

        public Common_Friend GetByID(int id)
        {
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                var friends = BDContext.Common_Friends.Select(f => f).Where(f => f.Frd_Id == id);
                if (friends.Count() > 0)
                {
                    return friends.First();
                }
                return null;
            }
        }

        public IList<Common_Friend> GetListByTXZID(int txzID)
        {
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                var friends = BDContext.Common_Friends.Select(f => f).Where(f => f.Frd_TxzUID == txzID);
                if (friends.Count() > 0)
                {
                    return friends.ToList();
                }
                return null;
            }
        }

        public IList<Common_Friend> GetListByTXZIDAndPage(int txzID, int pageIndex, int pageSize)
        {
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                var friends = BDContext.Common_Friends.Select(f => f).Where(f => f.Frd_TxzUID == txzID).Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderByDescending(f => f.Frd_Id);
                if (friends.Count() > 0)
                {
                    return friends.ToList();
                }
                return null;
            }
        }

        public IList<Common_Friend> GetListByUserID(int userID)
        {
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                var friends = BDContext.Common_Friends.Select(f => f).Where(f => f.Frd_UserId == userID);
                if (friends.Count() > 0)
                {
                    return friends.ToList();
                }
                return null;
            }
        }

        public IList<Common_Friend> GetListByUserIDAndPage(int userID, int pageIndex, int pageSize)
        {
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                var friends = BDContext.Common_Friends.Select(f => f).Where(f => f.Frd_UserId == userID).Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderByDescending(f => f.Frd_Id);
                if (friends.Count() > 0)
                {
                    return friends.ToList();
                }
                return null;
            }
        }

        public bool Insert(Common_Friend friend)
        {
            if (CheckIsFriend(friend))
            {
                return false;
            }
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                try
                {
                    BDContext.Common_Friends.InsertOnSubmit(friend);
                    BDContext.SubmitChanges();
                    return true;
                }
                catch (ChangeConflictException)
                {
                    return false;
                }
            }
        }

        public bool Update(Common_Friend friend)
        {
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                try
                {
                    //这里应该有更好的方法！知道的说一下哈～
                    Common_Friend friendTmp = BDContext.Common_Friends.Select(f => f).Single(f => f.Frd_Id == friend.Frd_Id);
                    friendTmp = friend;
                    BDContext.SubmitChanges();
                    return true;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
                catch (ChangeConflictException)
                {
                    return false;
                }
            }
        }

        public bool DeleteByID(int id)
        {
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                try
                {
                    Common_Friend friend = BDContext.Common_Friends.Select(f => f).Single(f => f.Frd_Id == id);
                    BDContext.Common_Friends.DeleteOnSubmit(friend);
                    BDContext.SubmitChanges();
                    return true;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
                catch (ChangeConflictException)
                {
                    return false;
                }
            }
        }

        public bool DeleteByUserID(int userID)
        {
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                try
                {
                    IQueryable<Common_Friend> friends = BDContext.Common_Friends.Select(f => f).Where(f => f.Frd_UserId == userID);
                    BDContext.Common_Friends.DeleteAllOnSubmit(friends);
                    BDContext.SubmitChanges();
                    return true;
                }
                catch (ChangeConflictException)
                {
                    return false;
                }
            }
        }

        public bool DeleteByTXZID(int txzID)
        {
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                try
                {
                    IQueryable<Common_Friend> friends = BDContext.Common_Friends.Select(f => f).Where(f => f.Frd_TxzUID == txzID);
                    BDContext.Common_Friends.DeleteAllOnSubmit(friends);
                    BDContext.SubmitChanges();
                    return true;
                }
                catch (ChangeConflictException)
                {
                    return false;
                }
            }
        }

        public bool CheckIsFriend(Common_Friend friend)
        {
            using (BlogDataDataContext BDContext = new BlogDataDataContext())
            {
                var friends = BDContext.Common_Friends.Where(f => f.Frd_UserId == friend.Frd_UserId && f.Frd_FriendUserId == friend.Frd_FriendUserId);
                if (friends.Count() > 0)
                {
                    return true;
                }
                return false;
            }
        }

        #endregion
    }
}
