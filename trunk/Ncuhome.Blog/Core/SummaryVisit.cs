using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Blog.Core
{
    /// <summary>
    /// 访问量统计
    /// llj098,20090423
    /// </summary>
    public class SummaryVisit
    {
        /// <summary>
        /// 记录访问量方法。
        /// 这个方法有几个问题：
        /// 1.没有辨别恶意刷的问题
        /// 2.调用远端service实现，独立性不好，当然，如果作为家园团队来讲，统一是一件好事情，那么放在开源系统中，则不然。
        /// llj098,20090423
        /// </summary>
        /// <param name="BlogUserID"></param>
        /// <param name="Url"></param>
        /// <param name="FromUrl"></param>
        /// <param name="IP"></param>
        /// <returns></returns>
        public bool AddVisitLog(int blogUserId, string url, string fromUrl, string ip)
        {
            WebReference.SummaryVisitService sv = new Ncuhome.Blog.Core.WebReference.SummaryVisitService();
            return sv.AddUrl(blogUserId, url, fromUrl, ip);
        }
    }
}
