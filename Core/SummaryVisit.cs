using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Blog.Core
{
  public class SummaryVisit
    {
      public bool AddVisitLog(int BlogUserID,string Url,string FromUrl,string IP)
      {
          WebReference.SummaryVisitService sv = new Ncuhome.Blog.Core.WebReference.SummaryVisitService();
          return sv.AddUrl(BlogUserID, Url, FromUrl, IP);
      }
    }
}
