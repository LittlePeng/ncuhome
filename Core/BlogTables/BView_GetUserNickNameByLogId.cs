using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;

namespace Ncuhome.Blog.Core
{
    public  class BView_GetUserNickNameByLogId : BlogTableBase
    {
        public static IEnumerable<View_GetUserNickNameByLogId> GetTop(int Top)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return  BD.View_GetUserNickNameByLogIds.Select(p => p).OrderByDescending(p=>p.Log_Id).Take(Top);
        }
        public static IEnumerable<View_GetUserNickNameByLogId> GetTopPaged(int Len, int PageIndex)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return   BD.View_GetUserNickNameByLogIds.Select(p => p).OrderByDescending(p => p.Log_Id).Skip((PageIndex-1)*Len).Take(Len);
        }
    }
}
