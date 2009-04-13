using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Core
{
    public  class BView_CommonFunction : BlogTableBase
    {        /// <summary>
        /// 根据FIID 获取通行证ID
        /// </summary>
        /// <param name="FIID"></param>
        /// <returns></returns>
        public static int? GetTxzIDByFIID(int FIID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp=BD.View_CommonFunctions.Where(p => p.FI_ID == FIID && p.FI_FuncID == 3);
            if (temp.Count() > 0)
                return temp.First().FI_OwnerID;
            else
                return 0;
        }

        public static int? GetFIID(int TxzID,int FuncID,int ModID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.View_CommonFunctions.Select(p => p).Where(p => p.FI_FuncID == FuncID && p.FI_MODID == ModID && p.FI_OwnerID == TxzID);
            if (temp.Count() > 0)
                return temp.First().FI_ID;
            else
                return 0;
        }
        public static int? GetFIID(int TxzID, int FuncID)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.View_CommonFunctions.Select(p => p).Where(p => p.FI_FuncID == FuncID && p.FI_OwnerID == TxzID);
            if (temp.Count() > 0)
                return temp.First().FI_ID;
            else
                return 0;
            
        }
        public static int? GetModIDByFiid(int FiiD)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp= BD.View_CommonFunctions.Where(p => p.FI_ID == FiiD);
            if (temp.Count() > 0)
                return temp.First().FI_MODID;
            else
                return 0;
        }
    }
}
