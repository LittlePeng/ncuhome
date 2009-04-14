using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using System.Web.UI.WebControls;

namespace Ncuhome.Blog.Controls.Manage
{
    public  class Catagory :SkinnedBlogWebControl
    {
        private Repeater repeater1;
        private Button AddCategory;
        private TextBox Cate_Name;
        public Catagory()
        {
            SkinFileName = "Category.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            repeater1 = (Repeater)Skin.FindControl("repeater1");
            AddCategory = (Button)Skin.FindControl("AddCategory");
            Cate_Name = (TextBox)Skin.FindControl("Cate_Name");
            AddCategory.Click += new EventHandler(AddCategory_Click);
            DataBind();
        }

        void AddCategory_Click(object sender, EventArgs e)
        {
            if (Cate_Name.Text.Trim() != "")
            {
                Weblog_Category WC = new Weblog_Category();
                WC.Cate_CreateTime = DateTime.Now;
                WC.Cate_Intro = Cate_Name.Text.Trim();
                WC.Cate_Name = Cate_Name.Text.Trim();
                WC.Cate_UserId = blogContext.BlogUserId;
                BWeblog_Category.Insert(WC);
                Cate_Name.Text = "";
                Context.Response.Redirect("/" + blogContext.Owner.User_DomainName + "/Manage/category.aspx");
            }
        }
        public override void DataBind()
        {
            if (blogContext.ID != -1)
                BWeblog_Category.Delete(blogContext.BlogUserId, blogContext.ID);
            repeater1.DataSource = BView_WeblogUserLogCategory.GetByUserIdWithOutDefalt(blogContext.BlogUserId);
            repeater1.DataBind();
            base.DataBind();
        }
    }
}
