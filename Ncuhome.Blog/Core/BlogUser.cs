using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Login;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Core
{
    public  class BlogUser
    {
        public BlogUser()
        {
            if (Ncuhome.Login.Login.CheckLogin())
            {
                IsLogin = true;
                //获取cookies
                if (System.Web.HttpContext.Current.Request.Cookies["Weblog_UserID"] != null)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Cookies["Weblog_UserID"].Value))
                        BlogUserID = Convert.ToInt32(System.Web.HttpContext.Current.Request.Cookies["Weblog_UserID"].Value);
                    else
                    {
                        BlogUserID = -1;
                        //IsLogin = false;
                    }
                }
                else
                {
                    //IsLogin = false;
                    BlogUserID = -1;
                }

                TxzUID =System.Web.HttpContext.Current.Request.Cookies["UID"].Value;
                TxzID = Convert.ToInt32(System.Web.HttpContext.Current.Request.Cookies["ID"].Value);
                TxzXM = System.Web.HttpContext.Current.Request.Cookies["XM"].Value;
                TxzNumber = System.Web.HttpContext.Current.Request.Cookies["Number"].Value;
                TxzBH = System.Web.HttpContext.Current.Request.Cookies["BH"].Value;

                if(BlogUserID!=-1)
                UserInfo = BWeblog_User.GetByID(BlogUserID);
            }
            else
            {
                UserInfo = new Weblog_User(); //47是匿名用户
                BlogUserID = 47; //
                UserInfo.User_NickName = "游客";
                IsLogin = false;
            }
        }
        //cookies获取
        public string TxzBH { get; set; }
        public string TxzNumber { get; set; }
        public string TxzXM { get; set; }
        public int TxzID { get; set; }
        public string TxzUID { get; set; }
        /// <summary>
        /// 没有登陆即为 0 ，没有注册是是-1 登陆后大于0
        /// </summary>
        public int BlogUserID { get; set; }
        public int? MfiiD { get {
            return BView_CommonFunction.GetFIID(TxzID, 3);
        } }

        public bool IsLogin { get; set; }
        public Weblog_User UserInfo { get; set; }

    }
}
