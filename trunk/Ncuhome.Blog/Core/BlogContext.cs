using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Data.Linq;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Core
{
    /// <summary>
    /// BlogContext 封装，扩充了HttpContext。
    /// 主要用于 博客 项目的各项信息的获取，包括QueryString，From，Cookie等，目前，主要是从QueryString中获取
    /// 
    /// 这个类的设计参考了 Community Server 的设计方式，BlogContext 来源于 HttpContext 
    /// HttpContext 是一个 aspnet 开发的“好朋友” ，而这个类的目的也是同样的。 ;)
    /// 
    /// llj098,20090422
    /// </summary>
    public class BlogContext
    {
        #region Fileds
        private int year = -1;
        private int month = -1;
        private int day = -1;
        private int mfiid = -1;
        private string afiid = "0";
        private int bloguserid = -1;
        private int logId = -1;
        private int messageID = -1;
        private int groupID = -1;
        private int postID = -1;
        private int threadID = -1;
        private int iD = -1;
        private string userName = "";
        private int pageIndex = 1;
        private int roleID = -1;
        private string queryText = "";
        private string returnUrl = "";
        private string checkGuid = "";
        private int attachmentID = -1;
        private bool isUrlReWritten = false;
        private string currentUrl;
        private int friendGroupID = -1;
        private bool isQuote = false;
        private string category = "";
        private bool isManager = false;
        //是否为个人博客
        private bool isPesonal = true;
        private string action = "";
        private string themeName = "";
        private string cssFilePath = "";

        private HttpContext context;
        private DateTime requestStartTime = DateTime.Now;

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public BlogContext()
        {
            context = HttpContext.Current;

            if (context == null)
                return;


            // Read common values we expect to find on the QS
            //
            action = context.Request.QueryString["action"];
            year = GetIntFromQueryString(context, "year");
            month = GetIntFromQueryString(context, "month");
            mfiid = GetIntFromQueryString(context, "mfiid");
            iD = GetIntFromQueryString(context, "iD");
            if (mfiid <= 0)
            {
                mfiid = GetMfiidByDomain(context, "Domain");
            }
            if (iD <= 0)
            {
                iD = GetMfiidByDomain(context, "toDomain");
            }

            afiid = context.Request.QueryString["afiid"];
            //根据FIID获取博客用户ID
            if (mfiid != -1)
            {
                bloguserid = Ncuhome.Blog.Core.BWeblog_User.GetUserIDByFiiD(mfiid);
            }
            postID = GetIntFromQueryString(context, "PostID");
            logId = GetIntFromQueryString(context, "logId");
            groupID = GetIntFromQueryString(context, "GroupID");
            messageID = GetIntFromQueryString(context, "MessageID");
            pageIndex = GetIntFromQueryString(context, "PageIndex");
            roleID = GetIntFromQueryString(context, "RoleID");
            //取得FriendGroupID
            int i = GetIntFromQueryString(context, "FriendGroupID");
            if (i == 0)
                i = -1;
            friendGroupID = i;

            attachmentID = GetIntFromQueryString(context, "AttachmentID");

            // emmmm./...
            //why not bool.TryParse???
            //llj098,20090422
            try
            {
                isQuote = bool.Parse(context.Request.QueryString["Quote"]);
            }
            catch
            {
            }
            queryText = context.Request.QueryString["q"];
            returnUrl = context.Request.QueryString["returnUrl"];
            checkGuid = context.Request.QueryString["guid"];

            category = context.Request.QueryString["Category"];


            var tempTheme = BView_WeblogThemeDetail.GetByBlogUserId(bloguserid);
            if (tempTheme == null)
                themeName = "space"; //默认space的主题
            else
            {
                themeName = tempTheme.Theme_Name;
                cssFilePath = tempTheme.CssFile_Path;
            }
        }

        public static BlogContext Current
        {
            get
            {
                //在同一个请求中缓存基本数据
                if (HttpContext.Current.Items["BlogContext"] == null)
                {
                    BlogContext Blog = new BlogContext();
                    HttpContext.Current.Items.Add("BlogContext", Blog);
                    return Blog;
                }
                return (BlogContext)HttpContext.Current.Items["BlogContext"];
            }

        }
        /// <summary>
        /// 根据Domain来获取用户Mfiid
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// 1. myself：将访问权限由public设置为private
        /// 2. myself：BWeblog_User.GetMfiidByDomain(string)方法已做错误处理，这里不用再try catch
        private static int GetMfiidByDomain(HttpContext context, string key)
        {
            int returnValue = -1;
            string queryStringValue = string.Empty;
            queryStringValue = context.Request.QueryString[key];
            if (queryStringValue == null || queryStringValue.Length == 0)
            {
                return returnValue;
            }

            returnValue = BWeblog_User.GetMfiidByDomain(queryStringValue);
            //用户不存在,跳回首页
            if (returnValue == -1)
            {
                context.Response.Write("<script>alert('该用户不存在！！');top.window.location='/default.aspx';</script>");
                context.Response.End();
            }
            return returnValue;
        }

        /// <summary>
        ///  获取整数类型的Querystring
        /// </summary>
        /// <param name="context">当前上下文</param>
        /// <param name="key">QueryString名称</param>
        /// <returns></returns>
        public static int GetIntFromQueryString(HttpContext context, string key)
        {
            int returnValue = -1;
            string queryStringValue;

            // Attempt to get the value from the query string
            //
            queryStringValue = context.Request.QueryString[key];

            // If we didn't find anything, just return
            //
            if (queryStringValue == null)
                return returnValue;

            // Found a value, attempt to conver to integer
            //
            try
            {
                if (queryStringValue.IndexOf("#") > 0)
                    queryStringValue = queryStringValue.Substring(0, queryStringValue.IndexOf("#"));

                if (queryStringValue.IndexOf(",") > 0)
                    queryStringValue = queryStringValue.Substring(0, queryStringValue.IndexOf(","));

                returnValue = Convert.ToInt32(queryStringValue);
            }
            catch
            {
                //
            }

            return returnValue;
        }

        public static string GetApplicationName()
        {
            return GetApplicationName(HttpContext.Current);
        }

        public static string GetApplicationName(HttpContext context)
        {
            if (context == null)
                return "";

            string hostName = context.Request.Url.Host;
            string applicationPath = context.Request.ApplicationPath;

            return hostName + applicationPath;
        }

        public HttpContext Context
        {
            get
            {
                if (context == null)
                    return new HttpContext(null);

                return context;
            }
        }
        public bool IsPesonal
        {
            get
            {
                if (Ncuhome.Blog.Core.BView_CommonFunction.GetModIDByFiid(mfiid) != 1)
                    isPesonal = false;
                return isPesonal;
            }
        }
        /// <summary>
        /// 被访问者的 信息
        /// </summary>
        public Ncuhome.Blog.Entity.Weblog_User Owner
        {
            get
            {
                if (HttpContext.Current.Items["Weblog_User"] == null)
                {
                    Ncuhome.Blog.Entity.Weblog_User u = BWeblog_User.GetByID(BlogUserId);
                    HttpContext.Current.Items.Add("Weblog_User", u);
                    return u;
                }
                else
                {
                    return (Ncuhome.Blog.Entity.Weblog_User)HttpContext.Current.Items["Weblog_User"];
                }
            }
        }

        /// <summary>
        /// 但前用户的信息
        ///  缓存
        /// </summary>
        public BlogUser User
        {
            get
            {
                if (HttpContext.Current.Items["BlogUser"] == null)
                {
                    BlogUser u = new BlogUser();
                    HttpContext.Current.Items.Add("BlogUser", u);
                    return u;
                }
                else
                {
                    return (BlogUser)HttpContext.Current.Items["BlogUser"];
                }
            }
        }

        public string Action
        {
            get { return action; }
        }

        //判断当前用户是否是管理员
        public bool IsManager
        {
            get
            {
                if (BlogUserId == User.BlogUserID)
                    isManager = true;
                return isManager;
            }
        }
        public int MessageID
        {
            get { return messageID; }
        }
        public int Year
        {
            get { return year; }
        }
        public int Month
        {
            get { return month; }
        }
        public int Day
        {
            get { return day; }
        }
        /// <summary>
        /// FIID对应的Blog用户ID
        /// </summary>
        public int BlogUserId
        {
            get { return bloguserid; }
        }
        public int MFiiD
        {
            get { return mfiid; }
        }
        public string AFiiD
        {
            get { return afiid; }
        }
        public int LogId
        {
            get { return logId; }
        }

        public int GroupID
        {
            get { return groupID; }
        }

        public int PostID
        {
            get { return postID; }
        }

        public int ThreadID
        {
            get { return threadID; }
        }

        public int ID
        {
            get { return iD; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public int RoleID
        {
            get { return roleID; }
        }

        public string QueryText
        {
            get { return queryText; }
        }

        public string ReturnUrl
        {
            get { return returnUrl; }
        }

        public int PageIndex
        {
            get
            {
                if (pageIndex < 1)
                    return 1;
                else
                    return pageIndex;
            }
            set { pageIndex = value; }
        }

        public DateTime RequestStartTime
        {
            get { return requestStartTime; }
        }


        public string CheckGuid
        {
            get { return checkGuid; }
        }

        public int FriendGroupID
        {
            get { return friendGroupID; }
        }

        /// <summary>
        /// 是否为引用发帖
        /// </summary>
        public bool IsQuote
        {
            get { return isQuote; }
        }

        public int AttachmentID
        {
            get { return attachmentID; }
        }


        /// <summary>
        /// 是否已进行URL重写
        /// </summary>
        public bool IsUrlReWritten
        {
            get { return isUrlReWritten; }
            set { isUrlReWritten = value; }
        }

        /// <summary>
        /// 当前页面URL
        /// </summary>
        public string CurrentUrl
        {
            get { return currentUrl; }
            set { currentUrl = value; }
        }

        public string Category
        {
            get { return category; }
        }
        public string ThemeName
        {
            get
            {
                return themeName;
            }

        }
        public string CssFilePath
        {
            get
            {
                return cssFilePath;
            }
        }
    }
}