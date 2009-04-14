using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;

namespace Ncuhome.Blog.Core
{
     public class BView_WeblogUserRecommend
    {
         /// <summary>
         /// 读出总数
         /// </summary>
         /// <returns></returns>
         public static Int32 GetCount()
         {
             BlogDataDataContext BD = new BlogDataDataContext();
             return BD.View_WeblogUserRecommends.Count();


         
         }

         public static IEnumerable<View_WeblogUserRecommend> GetAll()
         {
             BlogDataDataContext BD = new BlogDataDataContext();
             return BD.View_WeblogUserRecommends.OrderByDescending(p=>p.Recommend_Id);
         
         
         }

         public static IEnumerable<View_WeblogUserRecommend> GetByPageIndex(Int32 PageIndex,Int32 Length)
         {
             BlogDataDataContext BD = new BlogDataDataContext();
             
             return BD.View_WeblogUserRecommends.Where(p=>p.Recommend_ThemeId==PageIndex).OrderByDescending(p=>p.Recommend_CreateTime);
         
         }
         //public static IEnumerable<View_WeblogUserRecommend> GetRecommendByEdition(Int32 Edition)
         //{
         //    BlogDataDataContext BD = new BlogDataDataContext();
         //    return BD.View_WeblogUserRecommends.Where(p => p.Recommend_Edition == Edition&&p.Log_IsVisible==true&&p.Recommend_Visible==true).OrderByDescending(p=>p.Recommend_CreateTime).Take(7);
         //}
         //public static IEnumerable<View_WeblogUserRecommend> GetLatestRecommend()
         //{
         //    BlogDataDataContext BD = new BlogDataDataContext();
         //    var temp = BD.View_WeblogUserRecommends.OrderByDescending(p => p.Recommend_Edition);
         //    if (temp.Count() != 0)
         //    {
         //        Int32 LatestEdition = temp.First().Recommend_Edition;
         //        //Int32 LatestEdition = BD.View_WeblogUserRecommends.OrderByDescending(p => p.Recommend_Edition).First().Recommend_Edition;
         //        return BD.View_WeblogUserRecommends.Where(p => p.Recommend_Edition == LatestEdition && p.Log_IsVisible == true&&p.Recommend_Visible==true).OrderByDescending(p=>p.Recommend_CreateTime).Take(7);
         //    }
         //    else
         //    {
         //        return null; 
         //    }
         //}

    }
}
