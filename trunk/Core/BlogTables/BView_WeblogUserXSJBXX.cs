using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Data;
using System.Data.Linq.SqlClient;
using System.Linq.Expressions;
using System.Linq.Dynamic;

namespace Ncuhome.Blog.Core
{
    public class BView_WeblogUserXSJBXX : BlogTableBase
    {
        public static IEnumerable<View_WeblogUserXSJBXX> Search(View_WeblogUserXSJBXX VW)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserXSJBXXes.Where(p => p.XH == VW.XH);
        }


        public static IEnumerable<View_WeblogUserXSJBXX> SearchTopTwenty()
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserXSJBXXes.Take(20);

        }

        //计数
        public static int GetCountAll()
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserXSJBXXes.Where(p => p.User_TxzId < 200000).Select(p => p).Count();
        }



        //通过学号选
        public static IEnumerable<View_WeblogUserXSJBXX> SearchByXH(string XH)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            //return BD.View_WeblogUserXSJBXXes.Single(p=>p.XH==XH);
            return BD.View_WeblogUserXSJBXXes.Where(p => p.XH == XH);

        }


        //通过昵称选
        public static IEnumerable<View_WeblogUserXSJBXX> SearchByNickName(string NickName)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserXSJBXXes.Where(p => p.User_NickName == NickName);
        }

        //通过姓名选
        public static IEnumerable<View_WeblogUserXSJBXX> SearchByName(string Name)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserXSJBXXes.Where(p => p.User_Name == Name);
        }
        //通过专业选
        public static IEnumerable<View_WeblogUserXSJBXX> SearchByZY(string ZY)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserXSJBXXes.Where(p => p.ZYMC == ZY);
        }
        //通过QQ选
        public static IEnumerable<View_WeblogUserXSJBXX> SearchByQQ(string QQ)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.View_WeblogUserXSJBXXes.Where(p => p.User_QQ == QQ);
        }
        /// <summary>
        /// 搜索好友（为空或0不进行搜索）
        /// LINQ 运行时动态构建查询条件
        /// 引用 System.Linq.Dynamic; 可以在linqSample中找到
        /// </summary>
        /// <param name="Sex">性别（0为不限，1为女，2为男）</param>
        /// <param name="User_QQ"></param>
        /// <param name="User_NickName"></param>
        /// <param name="User_Name"></param>
        /// <param name="User_XH"></param>
        /// <param name="YXSH"></param>
        /// <param name="ZYH"></param>
        /// <returns></returns>
        public static IEnumerable<View_WeblogUserXSJBXX> SearchByAll(int PageIndex, int Length, out int Count, string Sex, string User_QQ, string User_NickName, string User_Name, string User_XH, string YXSH, string ZYH)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            string Sql = "User_TxzId<200000 and";
            if (Sex == "1")
                Sql += " XB==\"男\" and ";
            if (Sex == "2")
                Sql += " XB==\"女\" and ";

            if (User_QQ != "")
                Sql += " User_QQ.Contains(\"" + User_QQ + "\") and  ";
            if (User_NickName != "")
                Sql += " User_NickName.Contains(\"" + User_NickName + "\") and  ";
            if (User_Name != "")
                Sql += " XM.Contains(\"" + User_Name + "\") and  ";
            if (User_XH != "")
                Sql += " XH.Contains(\"" + User_XH + "\") and  ";
            if (YXSH != "0")
                Sql += " YXSH.Contains(\"" + YXSH + "\") and ";
            if (ZYH != "0")
                Sql += " ZYH.Contains(\"" + ZYH + "\") and ";
            Sql += " 1==1";

            //myself：要利用Linq2Sql的延迟
            var userXSJBXX = BD.View_WeblogUserXSJBXXes.Where(Sql);
            Count = userXSJBXX.Count();
            return userXSJBXX.Skip((PageIndex - 1) * Length).Take(Length);
        }
    }
}
