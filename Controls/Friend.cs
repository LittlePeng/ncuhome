using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using System.Web.UI.WebControls;


namespace Ncuhome.Blog.Controls
{
    public class Friend :SkinnedBlogWebControl
    {
        private RepeaterPaged repeater1;
        //private TextBox InputName;
        //private Button Search;

        public Friend()
        {
            IsThemed = true;
            SkinFileName = "friend.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            repeater1 = (RepeaterPaged)Skin.FindControl("repeater1");
            //InputName = (TextBox)Skin.FindControl("Name");
            //Search = (Button)Skin.FindControl("Search1");

            DataBind();
        }
        public override void DataBind()
        {
            //Search.Click += new EventHandler(Search_Click);
            repeater1.Count = BView_BlogUserFriend.GetCountByFIID(blogContext.MFiiD);
            repeater1.Length = 10;
            repeater1.UrlFormat = "/friend.aspx?mfiid=" + blogContext.MFiiD.ToString() + "&";
            if (blogContext.PageIndex!=-1)
            {
                repeater1.DataSource = BView_BlogUserFriend.GetByFIIDPaged(blogContext.MFiiD, blogContext.PageIndex, 10);
            }
            else
            {
                repeater1.DataSource = BView_BlogUserFriend.GetByFIIDPaged(blogContext.MFiiD,1,10);
            }
            //repeater1.DataSource = BWeblog_User.GetByNickName(InputName.ToString());
            repeater1.DataBind();

            //repeater1.DataBind();
        base.DataBind();
        }
        //void Search_Click(object sender, EventArgs e)
        //{
        //    Weblog_User wu = new Weblog_User();
        //    repeater1.DataSource = BView_BlogUserFriend.GetByNickName(InputName.Text);
        //    //repeater1.DataSource = BView_BlogUserFriend.GetByNickName(InputName.Text);
        //    //repeater1.DataSource = BWeblog_User.GetByNickName(InputName.ToString());
        //    repeater1.DataBind();

        //}


    }
}
