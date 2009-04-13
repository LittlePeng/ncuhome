using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;

namespace Ncuhome.Blog.Core
{
    public class BWeblog_Category:BlogTableBase
    {
        /// <summary>
        /// 根据Cate_Id获取文章种类
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Weblog_Category SelectByID(int ID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp= BD.Weblog_Categorys.Where(p => p.Cate_Id == ID);
            if (temp.Count() > 0)
                return temp.First();
            else
                return null;
        }
        /// <summary>
        /// 根据Cate_UserId来获取文章种类
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Category> SelectByUID(int UID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Categorys.Where(p => p.Cate_UserId == UID);
        }
        /// <summary>
        /// 插入新的文章种类
        /// </summary>
        /// <param name="WC"></param>
        /// <returns></returns>
        public static bool Insert(Weblog_Category WC)
        {
            BlogDataDataContext BD = new BlogDataDataContext();

            try
            {
                BD.Weblog_Categorys.InsertOnSubmit(WC);
                BD.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 插入新的文章种类并返回CateID
        /// </summary>
        /// <param name="WC"></param>
        /// <param name="CateID"></param>
        public static void Insert(Weblog_Category WC, out int CateID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                BD.Weblog_Categorys.InsertOnSubmit(WC);
                BD.SubmitChanges();
                CateID = WC.Cate_Id;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 修改文章种类
        /// </summary>
        /// <param name="WC"></param>
        /// <returns></returns>
        public static bool UpDate(Weblog_Category WC)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            Weblog_Category temp = new Weblog_Category();
            temp.Cate_CreateTime = DateTime.Now;
            temp.Cate_Intro = WC.Cate_Intro;
            temp.Cate_Name = WC.Cate_Name;
            temp.Cate_UserId = WC.Cate_UserId;
            try
            {
                BD.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static void Delete(int BlogUserId, int Cate_Id)
        {
            if (Cate_Id == 1)
                return;
            BlogDataDataContext BD = new BlogDataDataContext();
            BD.Weblog_Categorys.DeleteAllOnSubmit(BD.Weblog_Categorys.Where(p=>p.Cate_Id==Cate_Id&&p.Cate_UserId==BlogUserId));
            BD.SubmitChanges();
            //将日志分类改为默认
            
            BWeblog_log.UpdateLogCateIdAll(Cate_Id, 1);

        }
        /// <summary>
        /// 根据Cate_Id删除文章种类
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool DeleteByID(int ID)
        {
            if (ID == 1)
                return false;
            BlogDataDataContext BD = new BlogDataDataContext();
            try
            {
                BD.Weblog_Categorys.DeleteOnSubmit(BWeblog_Category.SelectByID(ID));
                BD.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
