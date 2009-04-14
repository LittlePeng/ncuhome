using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls
{
    public class SearchLog:SkinnedBlogWebControl
    {
        private TextBox LogTitle;
        private Button Search;
        public SearchLog()
        {
            IsThemed = true;
            SkinFileName = "SearchLog.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            LogTitle = (TextBox)Skin.FindControl("LogTitle");
            Search = (Button)Skin.FindControl("Search");
            Search.Click += new EventHandler(Search_Click);
            //throw new NotImplementedException();
        }

        void Search_Click(object sender, EventArgs e)
        {
            if (LogTitle.Text=="")
            {
                return;
            }
            Context.Response.Redirect("/"+blogContext.Owner.User_DomainName+"/Logs/"+LogTitle.Text);
            //throw new NotImplementedException();
        }
    }
}
