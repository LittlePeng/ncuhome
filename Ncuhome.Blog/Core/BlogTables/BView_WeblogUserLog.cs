using System;
using System.Collections.Generic;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Ncuhome.Blog.Core
{
    public class BView_WeblogUserLog:BlogTableBase
    {
        public static IEnumerable<View_WeblogUserLog> GetByLogId(int LogId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserLogs.Where(p => p.Log_Id == LogId && p.Log_CreateTime <= DateTime.Now);
        }

    }
}
