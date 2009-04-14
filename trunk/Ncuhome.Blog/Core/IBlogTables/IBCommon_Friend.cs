using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Core
{
    public interface IBCommon_Friend
    {
        /// <summary>
        /// 获得所有朋友记录(好像没什么用)
        /// </summary>
        /// <returns></returns>
        IList<Common_Friend> GetAll();

        /// <summary>
        /// 获得所有朋友分页记录
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        IList<Common_Friend> GetAllByPage(int pageIndex, int pageSize);

        /// <summary>
        /// 通过主键获得对应记录
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        Common_Friend GetByID(int id);

        /// <summary>
        /// 通过通行证id获得对应记录列表
        /// </summary>
        /// <param name="txzID">通行证id</param>
        /// <returns></returns>
        IList<Common_Friend> GetListByTXZID(int txzID);

        /// <summary>
        /// 通过通行证id获得对应记录分页列表
        /// </summary>
        /// <param name="txzID">通行证id</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        IList<Common_Friend> GetListByTXZIDAndPage(int txzID, int pageIndex, int pageSize);

        /// <summary>
        /// 通过UserID获得对应记录列表
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <returns></returns>
        IList<Common_Friend> GetListByUserID(int userID);

        /// <summary>
        /// 通过UserID获得对应记录分页列表
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IList<Common_Friend> GetListByUserIDAndPage(int userID, int pageIndex, int pageSize);

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="friend"></param>
        /// <returns></returns>
        bool Insert(Common_Friend friend);

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="friend"></param>
        /// <returns></returns>
        bool Update(Common_Friend friend);

        /// <summary>
        /// 通过主键删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteByID(int id);

        /// <summary>
        /// 通过UserID删除记录列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        bool DeleteByUserID(int userID);

        /// <summary>
        /// 通过通行证id删除记录列表
        /// </summary>
        /// <param name="txzID"></param>
        /// <returns></returns>
        bool DeleteByTXZID(int txzID);

        /// <summary>
        /// 判断是否存在某条记录
        /// </summary>
        /// <param name="friend"></param>
        /// <returns></returns>
        bool CheckIsFriend(Common_Friend friend);
    }
}
