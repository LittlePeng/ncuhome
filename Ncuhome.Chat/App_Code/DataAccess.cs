using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using nbyd.DBHelper;
using System.Data.SqlClient;
using System.Text;
/// <summary>
/// DataAccess 的摘要说明
/// </summary>

namespace nbyd.DataAccess
{
    using DBHelper;
    public class DataAccess:nbyd.DBHelper.DBHelper
    {
        public DataAccess()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public class user
        {
            public static void SetOnline(string userName)
            {
                string sql = "update [user] set IsOnline = 1,ActionTime=GetDate() where username = @userName ";
                SqlParameter pa = new SqlParameter("@userName", userName);
                Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteReader(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.Text, sql, pa);
            
            }

            public static SqlDataReader GetOnlineUserList()
            {
                string sql = "GetOnlineUserList";

                return Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteReader(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.StoredProcedure, sql, null);
            }

            public static SqlDataReader GetOnlineGuestList()
            {
                string sql = "GetOnlineGuestList";

                return Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteReader(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.StoredProcedure, sql, null);
            }

            public static string GetOnlineUserCount()
            {
                string sql = "select Count(UserID) from [USER] where IsOnline = 1 and guest=0";
                string ret = "50";
                SqlDataReader dr =  Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteReader(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.Text, sql, null);
                if (dr.Read())
                {
                    ret = dr[0].ToString();
                }
                dr.Close();
                return ret;
            }


            public static string GetOnlineGuestCount()
            {
                string sql = "select Count(UserID) from [USER] where IsOnline = 1 and guest=1";
                string ret = "50";
                SqlDataReader dr = Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteReader(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.Text, sql, null);
                if (dr.Read())
                {
                    ret = dr[0].ToString();
                }
                dr.Close();
                return ret;
            }
            /// <summary>
            /// user表中UserName（用户名）
            /// </summary>
            /// <param name="UserID"></param>
            /// <returns>string</returns>
            public static string UserName(Int64 UserID)
            {
                string condition = "UserID = '" + UserID.ToString() + "'";
                try
                {
                    return nbyd.DBHelper.DBHelper.ExecuteReader("[User]", "UserName", condition);
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            /// <summary>
            /// user表中UserPWD（密码）
            /// </summary>
            /// <param name="UserID"></param>
            /// <returns>string</returns>
            public static string UserPWD(Int64 UserID)
            {
                string condition = "UserID = '" + UserID.ToString() + "'";
                try
                {
                    return nbyd.DBHelper.DBHelper.ExecuteReader("[User]", "UserPWD", condition);
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            /// <summary>
            /// user表中的UserSex（性别）
            /// </summary>
            /// <param name="UserID"></param>
            /// <returns>string</returns>
            public static string UserSex(Int64 UserID)
            {
                string condition = "UserID = '" + UserID.ToString() + "'";
                try
                {
                    return nbyd.DBHelper.DBHelper.ExecuteReader("[User]", "UserSex", condition);
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            /// <summary>
            /// user表中IsOnline（是否上线）
            /// </summary>
            /// <param name="UserID"></param>
            /// <returns>bool</returns>
            public static bool IsOnline(Int64 UserID)
            {
                string condition = "UserID = '" + UserID.ToString() + "'";
                try
                {
                    return Convert.ToBoolean(nbyd.DBHelper.DBHelper.ExecuteReader("[User]", "IsOnline", condition));
                }
                catch
                {
                    return false;
                }
            }
            /// <summary>
            /// user表中LoginCount（登录次数）
            /// </summary>
            /// <param name="UserID"></param>
            /// <returns>string</returns>
            public static string LoginCount(Int64 UserID)
            {
                string condition = "UserID = '" + UserID.ToString() + "'";
                try
                {
                    return nbyd.DBHelper.DBHelper.ExecuteReader("[User]", "LoginCount", condition);
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            /// <summary>
            /// user表中LoginTime（登录时间）
            /// </summary>
            /// <param name="UserID"></param>
            /// <returns>DateTime</returns>
            public static DateTime LoginTime(Int64 UserID)
            {
                string condition = "UserID = '" + UserID.ToString() + "'";
                return Convert.ToDateTime(nbyd.DBHelper.DBHelper.ExecuteReader("[User]", "LoginTime", condition));
            }
            /// <summary>
            /// user表中UserID
            /// </summary>
            /// <param name="UserName"></param>
            /// <returns>string</returns>
            public static string UserID(string UserName)
            {
                string condition = "UserName = N'" + UserName + "'";
                try
                {
                    return DBHelper.ExecuteReader("[User]", "UserID", condition);
                }
                catch (Exception ex)
                {
                    return "0";
                }
              
            }
            /// <summary>
            /// 用户登录时修改记录
            /// </summary>
            /// <param name="UserID"></param>
            /// <returns></returns>
            public static void UserReg(Int64 UserID)
            {
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
                SqlCommand cmd1 = conn.CreateCommand();
                conn.Open();
                cmd1.CommandText = "UPDATE [User] SET [LoginCount] = [LoginCount]+1,[LoginTime]=@time WHERE USERID=@ID";
                cmd1.Parameters.AddWithValue("@ID", UserID);
                cmd1.Parameters.AddWithValue("@time", DateTime.Now);
                cmd1.ExecuteNonQuery();
                conn.Close();
            }

            public static string GetKickedReason(string userName)
            {
                string sql = "select reason from kickedUser where username=@username";
                SqlParameter pa = new SqlParameter("@username", userName);

                object obj = Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteScalar(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.Text, sql, pa);

                if (obj == null)
                    return "";
                else
                    return obj.ToString();
            }
        }
      
        
        
        public class chat
        {
            /// <summary>
            /// 最近一次聊天是第几次
            /// </summary>
            /// <returns></returns>
            public static string ID()
            {
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
                SqlCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "SELECT TOP 1 [ID] FROM [Chat] ORDER BY ID DESC";
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                try
                {
                    return dr[0].ToString();
                }
                finally
                {
                    dr.Close();
                    conn.Close();
                }
            }
            /// <summary>
            /// 聊天的公告
            /// </summary>
            /// <returns></returns>
            public static string notice()
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TOP 1 Notice FROM [Chat] ORDER BY ID DESC";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string tmp = "";
                try
                {
                    tmp = dr[0].ToString();
                }
                catch
                {
                }
                dr.Close();
                con.Close();

                return tmp;
            }
            /// <summary>
            /// 聊天的公告
            /// </summary>
            /// <returns></returns>
            public static string noticeinside()
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TOP 1 Notice_inside FROM [Chat] ORDER BY ID DESC";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                try
                {
                    return dr[0].ToString();
                }
                finally
                {
                    dr.Close();
                    con.Close();
                }
            }
            /// <summary>
            /// 聊天的公告
            /// </summary>
            /// <returns></returns>
            public static string noticeinside2()
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TOP 1 Notice_inside2 FROM [Chat] ORDER BY ID DESC";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                try
                {
                    return dr[0].ToString();
                }
                finally
                {
                    dr.Close();
                    con.Close();
                }
            }
            /// <summary>
            /// 返回聊天室是否开放
            /// </summary>
            /// <returns></returns>
            public static bool IsOpen()
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TOP 1 IsOpen FROM [Chat] ORDER BY ID DESC";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                bool open = false;
                try
                {
                    open = Convert.ToBoolean(dr[0]);
                }
                catch { }
                dr.Close();
                con.Close();
                return open;
            }

         
        }

        public class ChatInfo
        {
            public  static SqlDataReader GetPublicChat(int currentId, int chatNum)
            {
                //后续可以把这里改成存储过程，llj098,20080423, ;)
                string sql = "GetPublicChat";

                SqlParameter[] parms = new SqlParameter[2];
                parms[0] = new SqlParameter("@ChatNum", chatNum);
                parms[1] = new SqlParameter("@currnetId", currentId);

                SqlDataReader dr = Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteReader(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.StoredProcedure, sql, parms);

                return dr;
            }
            public static SqlDataReader GetPrivateChat(int currentId,int chatNum, string sender)
            {
                string sql = "GetPrivateChat";
                SqlParameter[] parms = new SqlParameter[3];
                parms[0] = new SqlParameter("@ChatNum", chatNum);
                parms[1] = new SqlParameter("@sender", sender);            
                parms[2] = new SqlParameter("@currnetId", currentId);

                SqlDataReader dr = Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteReader(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.StoredProcedure, sql, parms);

                return dr;
            }


 

            public static SqlDataReader GetGuestList()
            {
                string sql = "SELECT [UserName] FROM [User] WHERE ([IsOnline] = 1) AND ([guest]=1)";
                 
                SqlDataReader dr = Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteReader(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.Text, sql, null);

                return dr;
            }

            public static SqlDataReader GetUserList(int chatNum)
            {
                string sql = "SELECT [UserName] FROM [User] WHERE ([IsOnline] = 1) AND ([guest]=0)";

                SqlDataReader dr = Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteReader(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.Text, sql, null);

                return dr;
            }
        }

        public class PublicTale
        {
            /// <summary>
            /// 表PublicTale的PublicTale列
            /// </summary>
            /// <returns></returns>
            public static string PT(string chatnum)
            {
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT TOP 2 [PublicTale] FROM [PublicTale] WHERE ChatNum=@chatnum ORDER BY ID DESC ";
                cmd.Parameters.AddWithValue("@chatnum",chatnum);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                StringBuilder html = new StringBuilder();
                html.Append("<table>");
                while (dr.Read())
                {
                    html.Append("<tr><td><font style='color:Red'>");
                    html.Append(dr[0].ToString());
                    html.Append("</font></td></tr>");
                }
                html.Append("</table>");
                dr.Close();
                conn.Close();
                return html.ToString();
            }
        }
    }
}