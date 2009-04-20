using System;
using System.Configuration;
using System.Web;

/// <summary>
/// 
/// </summary>
/// 

namespace Ncuhome.Login
{
    public class Module : IHttpModule
    {
        public Module() { }

        public String ModuleName
        {
            get { return "Ncuhome.Login.Module"; }
        }

        public void Init(HttpApplication application)
        {
            HttpCookieCollection collection = Login.GetSavedCookieCollection();


            //HttpCookie Cookie_ID = System.Web.HttpContext.Current.Request.Cookies["ID"];
            //HttpCookie Cookie_UID = System.Web.HttpContext.Current.Request.Cookies["UID"];
            //HttpCookie Cookie_UID2 = System.Web.HttpContext.Current.Request.Cookies["UID2"];
            //HttpCookie Cookie_UserGroup = System.Web.HttpContext.Current.Request.Cookies["UserGroup"];
            //HttpCookie Cookie_LEV = System.Web.HttpContext.Current.Request.Cookies["LEV"];
            //HttpCookie Cookie_XM = System.Web.HttpContext.Current.Request.Cookies["XM"];
            //HttpCookie Cookie_Number = System.Web.HttpContext.Current.Request.Cookies["Number"];
            //HttpCookie Cookie_BH = System.Web.HttpContext.Current.Request.Cookies["BH"];
            //HttpCookie Cookie_BBS_UserID = System.Web.HttpContext.Current.Request.Cookies["BBS_UserID"];
            //HttpCookie Cookie_BBS_UserLevelID = System.Web.HttpContext.Current.Request.Cookies["BBS_UserLevelID"];
            //HttpCookie Cookie_WebDisk_UserID = System.Web.HttpContext.Current.Request.Cookies["WebDisk_UserID"];
            //HttpCookie Cookie_Weblog_UserID = System.Web.HttpContext.Current.Request.Cookies["Weblog_UserID"];
            //HttpCookie Cookie_FLV_UserID = System.Web.HttpContext.Current.Request.Cookies["FLV_UserID"];
            //HttpCookie Cookie_Mail_UserID = System.Web.HttpContext.Current.Request.Cookies["Mail_UserID"];


            //注册页面请求开始和结束事件
            application.BeginRequest +=
                (new EventHandler(this.Application_BeginRequest));

        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {

            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["Cookiefiled"]))
            {
                CheckLoginAndRedirect();
            }
            else
            {
                Login.CheckLoginAndActive();
            }

        }

        public void Dispose()
        {
        }

        private bool CheckLoginAndRedirect()
        {

            string LoginPage = "";

            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["LoginPage"]))
            {
                LoginPage = "Http://passport.ncuhome.cn/login.aspx?address=" + HttpContext.Current.Request.Url;
            }
            else
            {
                LoginPage = ConfigurationManager.AppSettings["LoginPage"].Trim();
            }

            if (!CheckLogin())
            {
                System.Web.HttpContext.Current.Response.Redirect(LoginPage);
                return false;
            }

            return true;
        }

        private bool CheckLogin()
        {
            string LoginPage = "Http://passport.ncuhome.cn/login.aspx?address=" + HttpContext.Current.Request.Url;

            //通过配置文件来获得登录页面
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["LoginPage"]))
            {
                LoginPage = System.Configuration.ConfigurationManager.AppSettings["LoginPage"].ToString();
            }
            string LoginPage2 = "";
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["LoginPage2"]))
            {
                LoginPage2 = System.Configuration.ConfigurationManager.AppSettings["LoginPage2"].ToString();
            }
            string LoginPage3 = "";
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["LoginPage3"]))
            {
                LoginPage3 = System.Configuration.ConfigurationManager.AppSettings["LoginPage3"].ToString();
            }
            string LoginPage4 = "";
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["LoginPage4"]))
            {
                LoginPage4 = System.Configuration.ConfigurationManager.AppSettings["LoginPage4"].ToString();
            }
            string LoginPage5 = "";
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["LoginPage5"]))
            {
                LoginPage5 = System.Configuration.ConfigurationManager.AppSettings["LoginPage5"].ToString();
            }
            string VisitPage = System.Web.HttpContext.Current.Request.RawUrl;

            if (string.Equals(LoginPage.ToUpper().Trim(), VisitPage.ToUpper().Trim()) || string.Equals(LoginPage2.ToUpper().Trim(), VisitPage.ToUpper().Trim()) || string.Equals(LoginPage3.ToUpper().Trim(), VisitPage.ToUpper().Trim()) || string.Equals(LoginPage4.ToUpper().Trim(), VisitPage.ToUpper().Trim()) || string.Equals(LoginPage5.ToUpper().Trim(), VisitPage.ToUpper().Trim()))
                return true;



            if (Login.CheckLogin())
            {
                return true;
            }
            return false;
        }
    }
}