using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Data;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Core
{
    class BWeblog_Group:BlogTableBase
    {
        /// <summary>
        /// 根据GroupId返回记录
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public static IEnumerable<Weblog_Group> GetGroupByGroupId(int GroupId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            return BD.Weblog_Groups.Where(p => p.Group_Id == GroupId);
        }
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="WG"></param>
        public static void Insert(Weblog_Group WG)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            BD.Weblog_Groups.InsertOnSubmit(WG);
            BD.SubmitChanges();
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="WG"></param>
        public static void Update(Weblog_Group WG)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.Weblog_Groups.Single(p=>p.Group_Id==WG.Group_Id);
            temp.Group_AdministratorsCount = WG.Group_AdministratorsCount;
            temp.Group_ClassId = WG.Group_ClassId;
            temp.Group_Competence = WG.Group_Competence;
            temp.Group_CreateTime = WG.Group_CreateTime;
            temp.Group_FounderId = WG.Group_FounderId;
            temp.Group_ImageUrl = WG.Group_ImageUrl;
            temp.Group_Introduce = WG.Group_Introduce;
            temp.Group_IsCertificateWhileJoin = WG.Group_IsCertificateWhileJoin;
            temp.Group_IsViewByStrangers = WG.Group_IsViewByStrangers;
            temp.Group_Keywords = WG.Group_Keywords;
            temp.Group_MembersCount = WG.Group_MembersCount;
            temp.Group_Name = WG.Group_Name;
            temp.Group_Notice = WG.Group_Notice;
            temp.Group_TopicCount = WG.Group_TopicCount;
            temp.Group_Url = WG.Group_Url;
            BD.SubmitChanges();
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="GroupId"></param>
        public static void Delete(int GroupId)
        {
            BlogDataDataContext BD = new BlogDataDataContext();
            var temp = BD.Weblog_Groups.Single(p => p.Group_Id == GroupId);
            BD.Weblog_Groups.DeleteOnSubmit(temp);
            BD.SubmitChanges();
        }
    }
}
