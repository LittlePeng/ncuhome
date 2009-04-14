using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core.GbookReference;

namespace Ncuhome.Blog.Core
{
    /// <summary>
    /// 留言本的操作，调用 Gbook.ncuhome.cn/gbookwebservice.asmx服务
    /// 
    /// </summary>
   public   class BGbook : BlogTableBase
    {
        private static GbookWebService Gbook = new GbookWebService();
        public BGbook()
        {
            
            
        }
        /// <summary>
        /// 根据FIID获取所有留言
        /// </summary>
        /// <param name="FIID"></param>
        /// <returns></returns>
        public static Gbook[] GetByFIID(int FIID)
        {
            return Gbook.GetAllList(FIID);  
        }
        /// <summary>
        /// 根据FIID获取所有留言( 分页)
        /// </summary>
        /// <param name="FIID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static Gbook[] GetByFIIDPaged( int FIID,int PageIndex,int Length)
        {
            return Gbook.GetGbookPage(PageIndex,FIID,Length);
       }
        /// <summary>
        /// 根据ID 获取留言
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Gbook GetByID(int ID)
        {
           
            return Gbook.GetSingleList(ID);
        }
     /// <summary>
        ///  获取留言本
     /// </summary>
     /// <param name="Fiid">日志的FIID</param>
     /// <param name="NickName">显示的昵称</param>
     /// <param name="VistType">访问的类型 True为本人 False 为访客</param>
     /// <param name="CanWrite">是否可写</param>
     /// <param name="CanDelete">是否可以删除</param>
     /// <param name="IsPaged">是否需要分页显示</param>
     /// <param name="PageLen">如果分页的话显示的 每页数量</param>
     /// <returns></returns>
        public static string GetGbook(int Fiid,string NickName,bool VistType,bool CanWrite,bool CanDelete,bool IsPaged,int PageLen)
        {
            //第二个参数没有用到
            return Gbook.GetGbook(Fiid, 1,NickName, VistType, CanWrite, CanDelete, IsPaged, PageLen);
        }
       /// <summary>
       /// 插入留言
       /// </summary>
       /// <param name="Content">留言内容</param>
       /// <param name="IP">留言者IP</param>
       /// <param name="Name">留言者昵称</param>
       /// <param name="Title"></param>
       /// <param name="FuncIID"></param>
       /// <param name="IsVisible"></param>
       /// <returns></returns>
        public static bool InsertBooks(string Content,string IP,string Name,string Title,int FuncIID,bool IsVisible)
        {
            try
            {
                Gbook.InsertMsg(Content, IP, Name, Title, FuncIID, true);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        /// <summary>
        /// 根据FIID删除留言
        /// </summary>
        /// <param name="FIID"></param>
        /// <returns></returns>
        public static bool DeleteByFIID(int FIID)
        {
            return Gbook.DeleteMsgByFIID(FIID);
        }
        /// <summary>
        /// 根据ID删除留言
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool DeleteByID(int ID)
        {
            return Gbook.DeleteMsgByMsgID(ID);
        }
    }
}
