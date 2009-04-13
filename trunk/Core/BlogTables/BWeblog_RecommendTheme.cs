using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;


namespace Ncuhome.Blog.Core
{
    public class BWeblog_RecommendTheme
    {
        public static bool  Insert(Weblog_RecommendTheme WRT)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            BD.Weblog_RecommendThemes.InsertOnSubmit(WRT); 
            BD.SubmitChanges();
            return true;

        }
        public static int[] GetAllThemeId()
        {

            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_RecommendThemes.Where(p=>p.Reco_Visible==true).Select(p => p.ID).ToArray();
        }

        public static Weblog_RecommendTheme GetByPageIndex(Int32 PageIndex)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
                      
            return BD.Weblog_RecommendThemes.Where(p => p.ID == PageIndex&&p.Reco_Visible==true).First();
        }
        /// <summary>
        /// 获取期刊总数
        /// </summary>
        /// <returns></returns>
        public static int GetAllThemeCount()
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_RecommendThemes.Select(p=>p).Count();
        }
        /// <summary>
        /// 获取所有期刊
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Weblog_RecommendTheme> GetAllThemes()
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_RecommendThemes.Select(p=>p).Where(p=>p.Reco_Visible==true);
        }
        //public static Weblog_RecommendTheme GetLatestTheme()
        ////public static IEnumerable<Weblog_RecommendTheme> GetLatestTheme()
        //{
        //    BlogDataDataContext BD = new BlogDataDataContext();
        //    var anothertemp = BD.Weblog_RecommendThemes.OrderByDescending(p => p.Reco_Edition);
        //    Int32 LatestEdition;
        //    if (anothertemp.Count() != 0)
        //    {
        //        LatestEdition = anothertemp.First().Reco_Edition;
        //    }
        //    else
        //    {
        //        LatestEdition = 1;
        //    }


        //     //var LatestEdition=BD.Weblog_RecommendThemes.OrderByDescending(p=>p.Reco_Edition).First().Reco_Edition;
        //     var temp = BD.Weblog_RecommendThemes.Where(p => p.Reco_Edition == LatestEdition);
        //     if (temp.Count() != 0)
        //     {
        //         return BD.Weblog_RecommendThemes.Where(p => p.Reco_Edition == LatestEdition).First();
        //     }
        //     else 
        //     {
        //         return null; 
        //     }
            
            
        //    //try
        //    //{
        //    //    var LatestEdition=BD.Weblog_RecommendThemes.OrderByDescending(p=>p.Reco_Edition).First().Reco_Edition;
        //    //    return BD.Weblog_RecommendThemes.Single(p => p.Reco_Edition == LatestEdition);
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    return null;
        //    //    //throw;
        //    //}
            
        //}
        //public static Weblog_RecommendTheme GetThemeByEdition(Int32 Ed)
        //{
        //    BlogDataDataContext BD = new BlogDataDataContext();
        //    var temp = BD.Weblog_RecommendThemes.Where(p => p.Reco_Edition == Ed);
        //    if (temp.Count() != 0 )
        //    {
        //        //return BD.Weblog_RecommendThemes.OrderByDescending(p => p.Reco_CreateTime).Single(p => p.Reco_Edition == Ed);
        //        return BD.Weblog_RecommendThemes.OrderByDescending(p => p.Reco_CreateTime).Where(p => p.Reco_Edition == Ed).First();
        //    }
        //    else
        //    {
        //        return null;
        //    }


        //}
        //public static void Edit(Weblog_RecommendTheme WRT,Int32 Edition)
        //{
        //    BlogDataDataContext BD = new BlogDataDataContext();
        //    var temp = BD.Weblog_RecommendThemes.Single(p => p.Reco_Edition == Edition);
        //    temp.Reco_Title=WRT.Reco_Title;
        //    temp.Reco_Content=WRT.Reco_Content;
        //    BD.SubmitChanges();

        
        //}
    }
}
