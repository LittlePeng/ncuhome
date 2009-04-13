using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;

namespace Ncuhome.Blog.Core
{
   public  class BWeblog_Theme:BlogTableBase
    {
        /// <summary>
        ///  根据Id返回主题
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Theme> GetThemeById(int Id)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Themes.Where(p => p.Theme_Id == Id);
        }
        public static IEnumerable<Weblog_Theme> GetAll()
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Themes.Select(p => p);
        }
        /// <summary>
        /// 插入主题记录
        /// </summary>
        /// <param name="WT"></param>
        public static void Insert(Weblog_Theme WT)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            BD.Weblog_Themes.InsertOnSubmit(WT);
            BD.SubmitChanges();
        }
        /// <summary>
        /// 修改主题
        /// </summary>
        /// <param name="WT"></param>
        public static void Update(Weblog_Theme WT)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.Weblog_Themes.Single(p => p.Theme_Id == WT.Theme_Id);
            temp.Theme_Intro = WT.Theme_Intro;
            temp.Theme_Name = WT.Theme_Name;
            BD.SubmitChanges();
        }
        /// <summary>
        /// 删除主题
        /// </summary>
        /// <param name="Id"></param>
        public static void Delete(int Id)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.Weblog_Themes.Single(p => p.Theme_Id == Id);
            BD.Weblog_Themes.DeleteOnSubmit(temp);
            BD.SubmitChanges();
        }
       
    }
}
