using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;


namespace Ncuhome.Blog.Core
{
    public  class BWeblog_ViewLog : BlogTableBase
    {

        public IEnumerable<Weblog_ViewLog> GetByUserID(int UserID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_ViewLogs.Select(p => p).Where(p => p.ViewLog_UserId == UserID);
        }
    }
}
