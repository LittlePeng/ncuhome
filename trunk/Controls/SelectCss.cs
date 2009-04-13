using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core;
using System.ComponentModel;
using Ncuhome.Blog.Entity;
using System.Web.UI.WebControls;

namespace Ncuhome.Blog.Controls
{
   
    public  class SelectCss:SkinnedBlogWebControl
    {
        private  RepeaterPaged repeater1;
        private TextBox TextBox1;
        private LinkButton LinkButton1;
        private string CssName;
        public SelectCss()
        {
            SkinFileName = "SelectCss2.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            repeater1 = (RepeaterPaged)Skin.FindControl("repeater1");
            TextBox1 = (TextBox)Skin.FindControl("TextBox1");
            LinkButton1 = (LinkButton)Skin.FindControl("LinkButton1");
            LinkButton1.Click += new EventHandler(LinkButton1_Click);
            DataBind();
            if (blogContext.ID != -1)
            {
                if (BView_WeblogThemeCssFile.CheckExist(blogContext.ID))
                {
                    if (!BWeblog_UserCss.CheckHasCssFile(blogContext.BlogUserId))
                    {
                        Weblog_UserCss WUC = new Weblog_UserCss();
                        WUC.UserCss_CssFileId = blogContext.ID;
                        WUC.UserCss_UserId = blogContext.BlogUserId;
                        WUC.UserCss_Used = true;
                        BWeblog_UserCss.Insert(WUC);
                    }
                    else//如果已经有了的话 更新
                    {
                        var temp= BWeblog_UserCss.GetByBlogUserId(blogContext.BlogUserId);
                        
                        Weblog_UserCss WUC = new Weblog_UserCss();
                        WUC.UserCss_Id = temp.First().UserCss_Id;
                        WUC.UserCss_CssFileId = blogContext.ID;
                        WUC.UserCss_UserId = blogContext.BlogUserId;
                        WUC.UserCss_Used = true;
                        BWeblog_UserCss.Update(WUC);
                    }
                    Context.Response.Redirect("/" + blogContext.Owner.User_DomainName);
                }
            }
        }

        void LinkButton1_Click(object sender, EventArgs e)
        {
            CssName = TextBox1.Text;
            Context.Response.Redirect("/" + blogContext.Owner.User_DomainName + "/Manage/SelectCss-" + blogContext.GroupID + "-" + CssName + ".html");
            //throw new NotImplementedException();
        }
        public override void DataBind()
        {
            repeater1.Length = 18;
            if (Context.Request["CssName"] != null)
            {
                CssName = Convert.ToString(Context.Request["CssName"]);
                repeater1.Count = BView_WeblogThemeCssFile.GetThemeCssFileCountByCssName(CssName);
                repeater1.UrlFormat = "/Manage/SelectCss.aspx?mfiid=" + blogContext.MFiiD + "&GroupId=" + blogContext.GroupID + "CssName=" + CssName + "&";
                if (blogContext.PageIndex != -1)
                {
                    repeater1.DataSource = BView_WeblogThemeCssFile.GetThemeCssFileByCssNamePaged(CssName, 18, blogContext.PageIndex);
                }
                else
                {
                    repeater1.DataSource = BView_WeblogThemeCssFile.GetThemeCssFileByCssNamePaged(CssName, 18, 1);
                }
            }
            else
            {
                repeater1.Count = BView_WeblogThemeCssFile.GetThemeCssFileCountByThemeId(blogContext.GroupID);
                repeater1.UrlFormat = "/Manage/selectcss.aspx?mfiid=" + blogContext.MFiiD + "&GroupId=" + blogContext.GroupID + "&";
                if (blogContext.PageIndex != -1)
                {
                    repeater1.DataSource = BView_WeblogThemeCssFile.GetThemeCssFileByThemeIdPaged(blogContext.GroupID, 18, blogContext.PageIndex);
                }
                else
                {
                    repeater1.DataSource = BView_WeblogThemeCssFile.GetThemeCssFileByThemeIdPaged(blogContext.GroupID, 18, 1);
                }
            }
            repeater1.DataBind();
            base.DataBind();
        }
    }
}
