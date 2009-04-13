using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;

namespace Ncuhome.Blog.Core
{
  public    class BWeblog_Recommend : BlogTableBase
    {
       

        public IEnumerable<Weblog_Recommend> GetByLogID(int LogID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Recommends.Select(p => p).Where(p => p.Recommend_LogId == LogID);
        }
      public static bool Insert(Weblog_Recommend WR)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            BD.Weblog_Recommends.InsertOnSubmit(WR);
            BD.SubmitChanges();
            return true;

          
        }
      public static void Edit(Weblog_Recommend WR)
      {
          BlogDataDataContext BD = new BlogDataDataContext();
         var temp= BD.Weblog_Recommends.Single(p=>p.Recommend_Id==WR.Recommend_Id);
         temp.Recommend_LogId = WR.Recommend_LogId;
         BD.SubmitChanges();
      }

    }
}
