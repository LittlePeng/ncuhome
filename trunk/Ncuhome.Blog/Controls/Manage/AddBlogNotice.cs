using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls.Manage
{

    public class AddBlogNotice : SkinnedBlogWebControl
    {
        public AddBlogNotice()
        {
            this.SkinFileName = "AddBlogNotice.ascx";
        }

        private TextBox txtContent;
        private Button btnOK;

        protected override void InitializeSkin(System.Web.UI.Control skin)
        {
            txtContent = (TextBox)skin.FindControl("TextBox1");
            btnOK = (Button)skin.FindControl("Button1");
            txtContent.Text = BWeblog_Notice.GetLatestNotice().Notice_Content;
            btnOK.Click += new EventHandler(btnOK_Click);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Weblog_Notice wn = new Weblog_Notice();
            
            //myself：加上Encode
            wn.Notice_Content = System.Web.HttpContext.Current.Server.HtmlEncode(txtContent.Text).Replace("\n", "<br />");
            wn.Notice_CreateTime = DateTime.Now;
            BWeblog_Notice.Insert(wn);
            Context.Response.Write("<script>alert('修改成功');window.location='Admin_BlogNotice.aspx'</script>");
        }
    }
}
