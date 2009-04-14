using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using System.Web.UI;
using System.Web;

namespace Ncuhome.Blog.Controls.Manage
{
   public class Login:SkinnedBlogWebControl
    {
        private TextBox UserName;
        private TextBox Password;
        private CheckBox CheckBox1;
        private LinkButton LinkButton1;
        private Label Label1;
        public Login()
        {
            SkinFileName = "Login.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            UserName = (TextBox)Skin.FindControl("UserName");
          Password = (TextBox)Skin.FindControl("Password");
          CheckBox1 = (CheckBox)Skin.FindControl("CheckBox1");
          LinkButton1 = (LinkButton)Skin.FindControl("LinkButton1");
          Label1 = (Label)Skin.FindControl("Label1");

            //保存上一次访问的跳转前的Url
          //Uri url = System.Web.HttpContext.Current.Request.UrlReferrer;
          //Context.Response.Write("我来测试一下~~"+url);
          //if (url != null)
          //{
          //    string UrlStr = url.ToString().ToLower();
          //    if (!UrlStr.Contains("blog.ncuhome.cn/firend.aspx"))
          //    {
          ////        if(UrlStr.Contains("blog.ncuhome.cn/manage"))
          ////            if (UrlStr != "http://blog.ncuhome.cn" && UrlStr != "http://blog.ncuhome.cn/" && UrlStr != "http://blog.ncuhome.cn/default.aspx" && UrlStr != "http://blog.ncuhome.cn/manage" && UrlStr != "http://blog.ncuhome.cn/manage/default.aspx")
          ////        {
          //        HttpContext.Current.Session["UrlStr"] = UrlStr;
          ////        }
          ////            else
          ////            {
          ////                HttpContext.Current.Session["UrlStr"] = null;
          ////            }
          //    }
          //    else
          //    {
          //        HttpContext.Current.Session["UrlStr"] = null;
          //    }
          //}
          LinkButton1.Click += new EventHandler(LinkButton1_Click);
          if (blogContext.User.IsLogin)
          {
              BWeblog_User.AddLoginTimes(blogContext.User.UserInfo.User_Id);
              if (BView_WeblogThemeDetail.GetByBlogUserId(blogContext.User.UserInfo.User_Id)==null)
              {
                  HttpContext.Current.Response.Write("<script>alert('您还没有设置您的个性模板！');window.location='/" + blogContext.User.UserInfo.User_DomainName + "/Manage/selecttheme.aspx';</script>");
                  HttpContext.Current.Response.End();
              }
              if (HttpContext.Current.Session["toDomain"] != null)
              {
                  string RedDomain=Convert.ToString(HttpContext.Current.Session["toDomain"]);
                  HttpContext.Current.Session["toDomain"] = null;
                  System.Web.HttpContext.Current.Response.Redirect("/Manage/sendmessage/" + blogContext.User.UserInfo.User_DomainName + "-to-" + RedDomain + ".html");
              }
              else
              {
                  System.Web.HttpContext.Current.Response.Redirect("/" + blogContext.User.UserInfo.User_DomainName + "/Manage/Default.aspx");
              }
          }

        }

        void LinkButton1_Click(object sender, EventArgs e)
        {
            string strUserName = UserName.Text;
            string strPassword = Password.Text;
            bool IsSave = CheckBox1.Checked;
            if (strUserName != "" && strPassword != "")
            {
                if (IsSave)
                {
                    if (Ncuhome.Login.Login.CheckLoginAndSaveCookie(strUserName, strPassword))
                    {
                        //HttpContext.Current.Session["login"] = "true";
                        System.Web.HttpContext.Current.Response.Write("<script>if(self==top){window.location='/Manage/Default.aspx';}else{parent.window.location='/Manage/Default.aspx';}</script>");
                    }
                    else { Label1.Visible = true; }
                }
                else
                {
                    if (Ncuhome.Login.Login.CheckLogin(strUserName, strPassword))
                    {
                        //HttpContext.Current.Session["login"] = "true";

                        System.Web.HttpContext.Current.Response.Write("<script>if(self==top){window.location=window.location.href;}else{parent.window.location=parent.window.location.href;}</script>");
                    }
                    else { Label1.Visible = true; }
                }
            }
        }
    }
}
