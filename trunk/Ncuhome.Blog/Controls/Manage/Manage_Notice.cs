using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;

namespace Ncuhome.Blog.Controls.Manage
{
    
    public class Manage_Notice : SkinnedBlogWebControl
    {
        
        public Manage_Notice()
        {
            SkinFileName = "Manage_Notice.ascx";
        }
        private TextBox CT;
        private Button Submit;
        private Literal Alert;

        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            CT = (TextBox)Skin.FindControl("Article");
            Alert = (Literal)Skin.FindControl("Literal1");
            Submit = (Button)Skin.FindControl("Submit");
            var Content=BNotice.GetNotice(blogContext.MFiiD);
            if (Content.Length > 0)
            {
                CT.Text = Content[0].Ntc_Content;
            }
            //CT.Text = Convert.ToString( BNotice.GetNotice(blogContext.MFiiD));

            Submit.Click += new EventHandler(Submit_Click);
            
        }

        void Submit_Click(object sender, EventArgs e)
        {
            
            var temp=BNotice.GetNotice(blogContext.MFiiD);
            bool success=false;
            if (temp.Count() <= 0)
            {
                BNotice.AddNotice("",Globals.HtmlEncode( CT.Text), blogContext.MFiiD);
                success = true;
            }
            else {

                BNotice.UpdateNotice(temp.First().Ntc_ID, "",Globals.HtmlEncode( CT.Text), blogContext.MFiiD);
                success = true;
            }
            if (success == true)
            {
                Alert.Text = "<script>alert('保存成功！');</script>";
                //Context.Response.Redirect("/" + blogContext.Owner.User_DomainName + "/Manage/blogconfig.aspx");
            }
            else
            {
                Alert.Text = "<script>alert('保存失败！');</script>";
            }
            
        }
        //protected void Submit_Click(object sender, EventArgs e)
        //{
        //    BNotice.AddNotice("", CT.Text, blogContext.MFiiD);

        //}
    }

}
