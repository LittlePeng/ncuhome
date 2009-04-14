using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using System.Web.UI.WebControls;


namespace Ncuhome.Blog.Controls
{
    public class SearchFriend : SkinnedBlogWebControl
    {
        public SearchFriend()
        {
            SkinFileName = "SearchFriend.ascx";
        }

        private TextBox InputName;

        private Button Search;
        //private string querry;


        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {

            //throw new NotImplementedException();

            InputName = (TextBox)Skin.FindControl("Name");
            Search = (Button)Skin.FindControl("Search1");
            DataBind();


        }
        public override void DataBind()
        {
            Search.Click += new EventHandler(Search_Click);
            base.DataBind();

        }

        void Search_Click(object sender, EventArgs e)
        {
            Weblog_User WU = new Weblog_User();
            BWeblog_User.GetByNickName(InputName.ToString());
            //SearchF();


            //throw new NotImplementedException();
        }
        //void SearchF()
        //{
        //    var s = from p in BWeblog_User.g
        //            where p.User_NickName == InputName
        //            select p;
        //    return (s);

        //}



    }
}

