using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core.NoticeReference;

namespace Ncuhome.Blog.Core
{
    public class BNotice : BlogTableBase
    {
        public static Notice[] GetNotice(int Fiid)
        {
            NoticeService no = new NoticeService();
           return no.GetNoticeByFIID(Fiid);
        }
        public static void DeleteNotice(int NotcID)
        {
            NoticeService no = new NoticeService();
            no.DeleteNotice(NotcID);
        }
        public static void UpdateNotice(long NoctID,string Title,string Context,int Fiid)
        {
            NoticeService no = new NoticeService();
            no.UpdateNotice(NoctID, Title, Context, Fiid,true,"","","");
        }
        public static void AddNotice(string Title, string Context, int Fiid)
        {
            NoticeService no = new NoticeService();
            no.InsertNotice(Title, Context, Fiid, true, "", "","");
        }
    }
}
