using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;


namespace Ncuhome.Login
{
    public class Login
    {
        ///这里填写各个项目的数据库连接字符串，llj098，20090420
        internal static string SQLCONNECTIONSTRING_GDXSXX_HARDCODE = @"";
        internal static string SQLCONNECTIONSTRING_NCUHOME2006_HARDCODE = @"";
        internal static string SQLCONNECTIONSTRING_JYBBS_HARDCODE = @"";
        internal static string SQLCONNECTIONSTRING_WEBDISK_HARDCODE = @"";
        internal static string SQLCONNECTIONSTRING_MAIL_HARDCODE = @"";
        internal static string[] Cookiekeys()
        {
            return new string[]{
                "ID","ID2","Cookie_UID","Cookie_UID","Cookie_UID",
                "Cookie_UID2","Cookie_UserGroup","Cookie_LEV","Cookie_XM",
                "Cookie_Number","Cookie_BH","Cookie_BBS_UserID","Cookie_BBS_UserLevelID","Cookie_WebDisk_UserID",
                "Cookie_Weblog_UserID","Cookie_FLV_UserID","Cookie_Mail_UserID"
            };
        }

        internal static HttpCookieCollection GetCookieCollection()
        {
            HttpCookieCollection cookieCollection = new HttpCookieCollection();

            foreach (string key in Cookiekeys())
            {
                cookieCollection.Add( new HttpCookie(key));
            }

            return cookieCollection;
        }

        internal static HttpCookieCollection GetSavedCookieCollection()
        {
            HttpCookieCollection cookieCollection = new HttpCookieCollection();

            foreach (string key in Cookiekeys())
            {
                cookieCollection.Add(HttpContext.Current.Request.Cookies[key]);
            }

            return cookieCollection;
        }

        /// <summary>
        /// 保存Cookie
        /// </summary>
        /// <param name="saveLong"></param>
        /// <param name="username"></param>
        /// <param name="saveLong"></param>
        internal static void SaveCookie(bool saveLong, string username)
        {
            Hashtable CookieValues = new Hashtable();
            CookieValues["ID"] = DES.CDES1.Encrypt(GetUser_ID(username));
            CookieValues["ID2"] = GetUser_ID(username);
            CookieValues["Cookie_UID"] = DES.CDES1.Encrypt(username);
            CookieValues["Cookie_UID2"] = GetUser_ID(username);
            CookieValues["Cookie_UserGroup"] = GetUserGroup(username);
            CookieValues["Cookie_LEV"] = GetLEV(username);
            CookieValues["Cookie_XM"] = GetXM(username);
            CookieValues["Cookie_Number"] = GetNumber(username);
            CookieValues["Cookie_BH"] = GetBH(username);
            CookieValues["Cookie_BBS_UserID"] = GetBBS_UserID(username);
            CookieValues["Cookie_BBS_UserLevelID"] = GetBBS_UserLevelID(username);
            CookieValues["Cookie_WebDisk_UserID"] = GetWebDisk_UserID(username);
            CookieValues["Cookie_Weblog_UserID"] = GetWeblog_UserID(username);
            CookieValues["Cookie_FLV_UserID"] = GetFLV_UserID(username);
            CookieValues["Cookie_Mail_UserID"] = GetMail_UserID(username);

            HttpCookieCollection cookieCollection = GetCookieCollection();
            foreach (string key in Cookiekeys())
            {
                if (CookieValues[key].ToString() != "")
                {
                    cookieCollection[key].Value = CookieValues[key].ToString();
                    cookieCollection[key].Domain = "ncuhome.cn";
                    if (saveLong)
                        cookieCollection[key].Expires = DateTime.Now.AddDays(14);
                    HttpContext.Current.Response.Cookies.Add(cookieCollection[key]);
                }
            }
        }

        /// <summary>
        /// 判断用户是否已从通行证登陆，是则返回true,否则返回false
        /// </summary>
        /// <returns></returns>
        public static bool CheckLogin()
        {
            HttpCookieCollection CookieCollection = GetSavedCookieCollection();

            //判断Cookie不为空
            foreach (string key in CookieCollection.AllKeys)
            {
                if (CookieCollection[key] == null)
                {
                    return false;
                }
            }

            //判断Cookie是否被修改
            if (CookieCollection[0].Value == DES.CDES1.Encrypt(CookieCollection[1].Value) && CookieCollection[2].Value == DES.CDES1.Encrypt(CookieCollection[3].Value))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 验证用户输入的用户名和密码是否正确，正确则保存Cookie14天，返回true，否则返回false（用户选择保存cookie的前提下使用）
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckLoginAndSaveCookie(string username, string password)
        {
           if (isUserIn(username))
            {
                if (isUserRight(username, password))
                {
                    SaveCookie(true, username);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 验证用户输入的用户名和密码是否正确，正确则保存临时Cookie（关闭浏览器Cookie即失效），返回true，否则返回false（用户选择不保存cookie的前提下使用）
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckLogin(string username, string password)
        {
            if (isUserIn(username))
            {
                if (isUserRight(username, password))
                {
                    SaveCookie(false, username);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        
        /// <summary>
        /// 如果用户既登陆又是此项目的激活用户，返回真，其余情况返回假。
        /// 经常用于发帖等功能处
        /// </summary>
        /// <returns></returns>
        public static bool CheckLoginAndActive()
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
            
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["Cookiefiled"]))
            {
                return (true && CheckLoginAndRedirect());
            }
            
            string CookieFiled=ConfigurationManager.AppSettings["Cookiefiled"].Trim();

            if ((HttpContext.Current.Request.Cookies[CookieFiled] != null) && CheckLoginAndRedirect())
                return true;
            else
            {
                System.Web.HttpContext.Current.Response.Redirect(LoginPage);
                return false;
            }
        }


        /// <summary>
        /// 此函数经常用于必须登陆才能访问的系统，如果用户没有登陆通行证，将页面返回到配置文件记录的登陆页面
        /// </summary>
        /// <returns></returns>
        public static bool CheckLoginAndRedirect()
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

        /// <summary>
        /// 指向到参数里面的页面
        /// </summary>
        /// <param name="GotoPage"></param>
        /// <returns></returns>
        public static bool CheckLoginAndRedirect(string GotoPage)
        {
            if (!CheckLogin())
            {
                System.Web.HttpContext.Current.Response.Redirect(GotoPage);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 退出登陆,并且重定向
        /// </summary>
        public void SignOut(string Addr)
        {

            HttpCookieCollection CookieCollection = GetSavedCookieCollection();

            foreach (HttpCookie item in CookieCollection)
            {
                if (item != null)
                {
                    item.Expires = DateTime.Now.AddDays(-1d);
                    item.Values.Clear();
                    HttpContext.Current.Request.Cookies.Set(item);
                }
            }

            HttpContext.Current.Response.Redirect(Addr);
        }
        
        public void SignOut()
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

            HttpCookieCollection CookieCollection = GetSavedCookieCollection();

            foreach (HttpCookie item in CookieCollection)
            {
                if (item != null)
                {
                    item.Expires = DateTime.Now.AddDays(-1d);
                    item.Values.Clear();
                    HttpContext.Current.Request.Cookies.Set(item);
                }
            }

            HttpContext.Current.Response.Redirect(LoginPage);
        }


        #region 获得各种信息的方法
        public static bool isUserIn(string UID)
        {
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_GDXSXX_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@UID", UID);
            conn.Open();
            cmd.CommandText = "select count(*) as num from TXZ_USERS where UID = @UID";
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            if (num > 0) return true;
            else return false;
        }
        public static bool isUserRight(string UID, string PWD)
        {
            int num = 0;
            if (isUserIn(UID))
            {
                SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_GDXSXX_HARDCODE);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@UID", UID);
                cmd.Parameters.Add("@PWD", PWD);
                conn.Open();
                cmd.CommandText = "select count(*) as num from TXZ_USERS where UID = @UID AND PWD=@PWD";
                num = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            if (num > 0)
                return true;
            else return false;
        }
        public static string GetUserGroup(string UID)//得到UID所在的组
        {
            string UserGroup = "";
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_GDXSXX_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@UID", UID);
            conn.Open();
            cmd.CommandText = "select count(*) as num from TXZ_USERS where UID = @UID";
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num > 0)
            {
                cmd.CommandText = "select UserGroup from TXZ_USERS where UID = @UID";
                UserGroup = cmd.ExecuteScalar().ToString();
            }
            conn.Close();
            return UserGroup;
        }
        public static string GetXM(string UID)//得到对应的姓名
        {
            string XM = "";
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_GDXSXX_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@UID", UID);
            conn.Open();
            cmd.CommandText = "select count(*) as num from TXZ_USERS where UID = @UID";
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num > 0)
            {
                cmd.CommandText = "select TRUENAME from TXZ_USERS where UID = @UID";
                XM = cmd.ExecuteScalar().ToString();
            }
            conn.Close();
            return XM;
        }
    
        public static string GetNumber(string UID)//得到对应的学号或是工资号
        {
            string Number = "";
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_GDXSXX_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@UID", UID);
            conn.Open();
            cmd.CommandText = "select count(*) as num from TXZ_USERS where UID = @UID";
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num > 0)
            {
                cmd.CommandText = "select NUMBER from TXZ_USERS where UID = @UID";
                Number = cmd.ExecuteScalar().ToString();
            }
            conn.Close();
            return Number;
        }

        public static string GetLEV(string UID)//得到UID所在的组
        {
            string LEV = "";
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_GDXSXX_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@UID", UID);
            conn.Open();
            cmd.CommandText = "select count(*) as num from TXZ_USERS where UID = @UID";
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num > 0)
            {
                cmd.CommandText = "select LEV from TXZ_USERS where UID = @UID";
                LEV = cmd.ExecuteScalar().ToString();
            }
            conn.Close();
            return LEV;
        }
        public static string GetBH(string UID)//得到对应的UID所在的班号
        {
            string UserGroup = "";
            string BH = "";
            if (GetUserGroup(UID).Trim() != "")
                UserGroup = GetUserGroup(UID);
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_GDXSXX_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            conn.Open();
            switch (UserGroup)
            {
                case "S":
                    {
                        cmd.Parameters.Add("@XH", GetNumber(UID));
                        cmd.CommandText = "select count(*) as num from TS_XS_XSJBXX where XH = @XH";
                        int num = Convert.ToInt32(cmd.ExecuteScalar());
                        if (num > 0)
                        {
                            cmd.CommandText = "select BH from TS_XS_XSJBXX where XH = @XH";
                            BH = cmd.ExecuteScalar().ToString();
                        }
                    }
                    break;
                case "P":
                    {
                        cmd.Parameters.Add("@XH", GetNumber(UID));
                        cmd.CommandText = "select count(*) as num from TS_XS_XSJBXX where XH = @XH";
                        int num = Convert.ToInt32(cmd.ExecuteScalar());
                        if (num > 0)
                        {
                            cmd.CommandText = "select BH from TS_XS_XSJBXX where XH = @XH";
                            BH = cmd.ExecuteScalar().ToString();
                        }
                    }
                    break;
                case "M"://因为是老师，可能会对应多个班级，所以还应判断班主任是不是对应这个班号就行，此所得到的只是第一个班级。
                    {
                        cmd.Parameters.Add("@BZRZGH", GetNumber(UID));
                        cmd.CommandText = "select count(*) as num from TS_XX_BJJBXX where BZRZGH= @BZRZGH";
                        int num = Convert.ToInt32(cmd.ExecuteScalar());
                        if (num > 0)
                        {
                            cmd.CommandText = "select BH from TS_XX_BJJBXX where BZRZGH = @BZRZGH";
                            BH = cmd.ExecuteScalar().ToString();
                        }
                    }
                    break;
                case "T":
                    {
                        cmd.Parameters.Add("@ZGH", GetNumber(UID));//因为是老师，可能会对应多个班级，所以还判断班主任是不是对应这个班号就行，此所得到的只是第一个对应的班级。
                        cmd.CommandText = "select count(*) as num from XZZX_Teacher_Class where ZGH = @ZGH";
                        int num = Convert.ToInt32(cmd.ExecuteScalar());
                        if (num > 0)
                        {
                            cmd.CommandText = "select BH from XZZX_Teacher_Class where ZGH = @ZGH";
                            BH = cmd.ExecuteScalar().ToString();
                        }
                    }
                    break;
                default: BH = ""; break;
            }
            return BH;
        }
        /// <summary>
        /// 根据通行证用户名得到用户ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetUser_ID(string UID)
        {
            string UserID = "";
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_GDXSXX_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@UID", UID);
            conn.Open();
            cmd.CommandText = "select count(*) as num from [TXZ_USERS] where UID=@UID";
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num > 0)
            {
                cmd.CommandText = "SELECT ID FROM [TXZ_USERS] where UID=@UID";
                UserID = cmd.ExecuteScalar().ToString();
            }
            conn.Close();
            return UserID;
        }
        public static string GetBBS_UserID(string UID)
        {
            string BBS_UserID = "";
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_JYBBS_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@UID", UID);
            conn.Open();
            cmd.CommandText = "select count(*) as num from [user] where User_Name=@UID";
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num > 0)
            {
                cmd.CommandText = "SELECT User_ID FROM [user] where User_Name=@UID";
                BBS_UserID = cmd.ExecuteScalar().ToString();
            }
            conn.Close();
            return BBS_UserID;
        }
        public static string GetBBS_UserLevelID(string UID)
        {
            string BBS_UserLevelID = "";
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_JYBBS_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@UID", UID);
            conn.Open();
            cmd.CommandText = "select count(*) as num from [user] where User_Name=@UID";
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num > 0)
            {
                cmd.CommandText = "SELECT User_LevelID FROM [user] where User_Name=@UID";
                BBS_UserLevelID = cmd.ExecuteScalar().ToString();
            }
            conn.Close();
            return BBS_UserLevelID;
        }
        /// <summary>
        /// 根据通行证用户ID得到WebDisk的User_ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetWebDisk_UserID(string ID)
        {
            string WebDisk_UserID = "";
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_WEBDISK_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ID", ID);
            conn.Open();
            cmd.CommandText = "select count(*) as num from [user] where User_TXZID=@ID";
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num > 0)
            {
                cmd.CommandText = "SELECT User_ID FROM [user] where User_TXZID=@ID";
                WebDisk_UserID = cmd.ExecuteScalar().ToString();
            }
            conn.Close();
            return WebDisk_UserID;
        }
        /// <summary>
        /// 根据通行证用户ID得到Weblog的User_ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetWeblog_UserID(string ID)
        {
            string Weblog_UserID = "";
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_NCUHOME2006_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ID", ID);
            conn.Open();
            cmd.CommandText = "select count(*) as num from [Weblog_User] where User_TXZID=@ID";
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num > 0)
            {
                cmd.CommandText = "SELECT User_ID FROM [Weblog_User] where User_TXZID=@ID";
                Weblog_UserID = cmd.ExecuteScalar().ToString();
            }
            conn.Close();
            return Weblog_UserID;
        }
        /// <summary>
        /// 根据通行证用户ID得到FLV的User_ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetFLV_UserID(string ID)
        {
            string FLV_UserID = "";
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_NCUHOME2006_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ID", ID);
            conn.Open();
            cmd.CommandText = "select count(*) as num from [FLV_User] where User_TXZID=@ID";
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num > 0)
            {
                cmd.CommandText = "SELECT User_ID FROM [FLV_User] where User_TXZID=@ID";
                FLV_UserID = cmd.ExecuteScalar().ToString();
            }
            conn.Close();
            return FLV_UserID;
        }
        /// <summary>
        /// 根据通行证用户ID得到Mail的User_ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetMail_UserID(string ID)
        {
            string Mail_UserID = "";
            SqlConnection conn = new SqlConnection(SQLCONNECTIONSTRING_MAIL_HARDCODE);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ID", ID);
            conn.Open();
            cmd.CommandText = "select count(*) as num from [Mail_User] where User_ID=@ID";
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num > 0)
            {
                cmd.CommandText = "SELECT ID FROM [Mail_User] where User_ID=@ID";
                Mail_UserID = cmd.ExecuteScalar().ToString();
            }
            conn.Close();
            return Mail_UserID;
        }
        #endregion
    }
}
