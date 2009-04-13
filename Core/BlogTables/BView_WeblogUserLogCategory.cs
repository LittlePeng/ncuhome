using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Entity;
using System.Data.Linq;
using Ncuhome.Blog.Data;

namespace Ncuhome.Blog.Core
{
    public class BView_WeblogUserLogCategory
    {
        /// <summary>
        /// 方法有点不好主要是发现视图没有建好，但又不想改
        /// 效率应该可以把，可可
        /// </summary>
        /// <param name="BlogUserId"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogUserLogCategory> GetByUserId(int BlogUserId)
        {
            
            //先选出默认的
            BlogDataDataContext BD = new BlogDataDataContext();
            int Count= BWeblog_log.GetCountByLogCateIDAndUID(1, BlogUserId);
            View_WeblogUserLogCategory v = new View_WeblogUserLogCategory();
            v.Cate_UserId = BlogUserId;
            v.Cate_Name = "随笔";
            v.Cate_Id = 1;
            v.Cate_Intro = "随笔";
            v.Log_Count = Count;
            List<View_WeblogUserLogCategory> l = new List<View_WeblogUserLogCategory>();
            l.Add(v);


            var temp = GetByUserIdWithOutDefalt(BlogUserId);
            return temp.Concat(l);
        }
        public static IEnumerable<View_WeblogUserLogCategory> GetByUserIdWithOutDefalt(int BlogUserId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserLogCategorys.Where(p => p.Cate_UserId == BlogUserId);
        }
    }
   
}
