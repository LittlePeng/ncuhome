using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls
{
    public class AddBook:SkinnedBlogWebControl
    {
        private TextBox TextBox1;
        private Button Button1;
        private Label Label1;
        private int userFiid;
        private string UserName,BookContent,UserIP;
        public AddBook()
        {
            IsThemed = true;
            SkinFileName = "AddBook.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            TextBox1 = (TextBox)Skin.FindControl("TextBox1");
            Button1 = (Button)Skin.FindControl("Button1");
            Label1 = (Label)Skin.FindControl("Label1");
            Button1.Click += new EventHandler(Button1_Click);
            //throw new NotImplementedException();
        }

        void Button1_Click(object sender, EventArgs e)
        {
            UserName = blogContext.User.UserInfo.User_NickName;
            BookContent = TextBox1.Text;
            UserIP = Globals.IPAddress;
            userFiid = Convert.ToInt32(BlogContext.Current.Owner.User_FIID);
            if (BGbook.InsertBooks(BookContent, UserIP, UserName, "", userFiid, true))
            {
                Context.Response.Redirect("/" + blogContext.Owner.User_DomainName + "/Manage/userinfor.aspx");

            }
            else
            {
                Label1.Text = "<font color=red>留言失败！</font>";
            }
            
            //throw new NotImplementedException();
        }
    }
}
