using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Text;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls
{
    public class BlogStar:SkinnedBlogWebControl
    {
        private DataList DataList1;
        public BlogStar()
        {
            SkinFileName = "BlogStar.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            DataList1 = (DataList)Skin.FindControl("DataList1");
            DataBind();
            //throw new NotImplementedException();
        }
        public override void DataBind()
        {
            //一个月之内新添加的日志访问量综合排名
            DataList1.DataSource = BWeblog_User.GetTopUsersInAnyDay(7,30);
            DataList1.DataBind();
            base.DataBind();
        }
    }
}
