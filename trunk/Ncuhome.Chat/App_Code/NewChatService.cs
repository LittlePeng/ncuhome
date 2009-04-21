using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using nbyd.DataAccess;
using System.Collections.Generic;
using Ncuhome.Chat;
/// <summary>
///NewChatService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class NewChatService : System.Web.Services.WebService {

    public NewChatService () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    private string GetKickedReason(string userName)
    {
        string ret = "";
        if (HttpRuntime.Cache["KickReason_" + userName] == null)
        {
            ret = nbyd.DataAccess.DataAccess.user.GetKickedReason(userName);
            HttpRuntime.Cache.Insert("KickReason_" + userName, ret, null, DateTime.UtcNow.AddSeconds(8), System.Web.Caching.Cache.NoSlidingExpiration);

        }
        else
            ret = HttpRuntime.Cache["KickReason_" + userName].ToString();
        return ret;
    }

    /// <summary>
    /// 合并请求
    /// </summary>
    /// <param name="ChatNum">聊天期数</param>
    /// <param name="UserName">用户名</param>
    /// <param name="IsUserState">是否请求用户状态</param>
    /// <param name="IsOnlineGuestCount">是否请求在线总人数</param>
    /// <param name="IsGuestUserName">是否请求嘉宾列表</param>
    /// <param name="IsUserUserName">是否请求用户列表</param>
    /// <param name="IsPublicChatList">是否请求公聊信息</param>
    /// <param name="IsPrivateChatList">是否请求私聊信息</param>
    /// <param name="sendTo">私聊的话，发送给谁</param>
    /// <param name="CurrentChatId">当前的公聊id</param>
    /// <param name="CurrentPrivateId">当前的私聊id</param>
    /// <returns>合并对象</returns>
    [WebMethod]
    public Ncuhome.Chat.ChatInfo GetNewChatInfo(int ChatNum,string UserName, bool IsUserState, bool IsOnlineUserCount
        , bool IsGuestUserName, bool IsUserUserName,bool IsPublicChatList,bool IsPrivateChatList, int CurrentChatId,int CurrentPrivateId)
    {
        Ncuhome.Chat.ChatInfo chat = new Ncuhome.Chat.ChatInfo();
		//return chat;
        chat.IsChange = true;

        // 0:正常,其他:被踢,2:关闭
        #region
        chat.UserState = "0";
        if (IsUserState)
        {
            string reason = "";
            //if (!nbyd.DataAccess.DataAccess.chat.IsOpen())
            if (HttpContext.Current.Application["IsOpen"] != null && HttpContext.Current.Application["IsOpen"].ToString() == "0")
            {
                chat.UserState = "2";
            }
            else if ((reason = this.GetKickedReason(UserName)) != "")
            {
                chat.UserState = "您被管理员请出了聊天室,原因:" + reason;
            }
            else
            {
                nbyd.DataAccess.DataAccess.user.SetOnline(UserName);
            }
        }
        #endregion
       
        #region 在线用户数量
        //if (IsOnlineUserCount)
        if(false)
        {
            if (HttpRuntime.Cache["OnlineUserCount"] == null)
            {
                int Online = Convert.ToInt32(nbyd.DataAccess.DataAccess.user.GetOnlineUserCount());
                chat.OnlineUserCount = Online;
                HttpRuntime.Cache.Insert("OnlineUserCount", Online, null, DateTime.UtcNow.AddSeconds(5), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            else
                chat.OnlineUserCount = Convert.ToInt32(HttpRuntime.Cache["OnlineUserCount"]);
        }
        #endregion
    
        #region 嘉宾列表
        if (IsGuestUserName)
        {
            if (HttpRuntime.Cache["GuestUserName"] == null)
            {
                SqlDataReader dr = DataAccess.user.GetOnlineGuestList();
                List<ChatUser> Guest = new List<ChatUser>();
                while (dr.Read())
                {
                    ChatUser guest = new ChatUser();
                    guest.Name = dr["UserName"].ToString();
                    guest.UserId = Convert.ToInt32(dr["UserId"]);
                    Guest.Add(guest);
                }
                dr.Close();
                chat.GuestUser = Guest.ToArray();
                HttpRuntime.Cache.Insert("GuestUserName", chat.GuestUser, null, DateTime.UtcNow.AddSeconds(3), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            else
                chat.GuestUser = (ChatUser[])HttpRuntime.Cache["GuestUserName"];
        }
        #endregion
      
        #region 用户列表
        if (IsUserUserName)
        {
            if (HttpRuntime.Cache["UserUserName"] == null)
            {
                SqlDataReader dr = DataAccess.user.GetOnlineUserList();
                List<ChatUser> User = new List<ChatUser>();
                while (dr.Read())
                {
                    ChatUser user = new ChatUser();
                    user.Name = dr["UserName"].ToString();
                    user.UserId = Convert.ToInt32(dr["UserId"]);
                    User.Add(user);
                }
                dr.Close();
                chat.UserUser = User.ToArray();
                HttpRuntime.Cache.Insert("UserUserName", chat.UserUser, null, DateTime.UtcNow.AddSeconds(5), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            else
                chat.UserUser = (ChatUser[])HttpRuntime.Cache["UserUserName"];
        }
        #endregion      
        
        #region 公聊
        if (IsPublicChatList)
        {           
            List<Ncuhome.Chat.ChatList> lschat = new List<Ncuhome.Chat.ChatList>();
            SqlDataReader dr = DataAccess.ChatInfo.GetPublicChat(CurrentChatId, ChatNum);
            while (dr.Read())
            {
                Ncuhome.Chat.ChatList cl=new Ncuhome.Chat.ChatList();
                cl.Chat_Id =Convert.ToInt32( dr["id"].ToString());
                cl.Content = dr["content"].ToString();
                cl.CreateTime = dr["time"].ToString();
                cl.Sender = dr["Sender"].ToString();
                cl.Sendto = dr["Sendto"].ToString();
                lschat.Add(cl);
            }
            dr.Close();
            chat.PublicChatList = lschat.ToArray();
        }
        #endregion

        #region 私聊
        if (IsPrivateChatList)
        {
            List<Ncuhome.Chat.ChatList> lschat = new List<Ncuhome.Chat.ChatList>();
            SqlDataReader dr = DataAccess.ChatInfo.GetPrivateChat(CurrentPrivateId,ChatNum,UserName);
            while (dr.Read())
            {
                Ncuhome.Chat.ChatList cl = new Ncuhome.Chat.ChatList();
                cl.Chat_Id = Convert.ToInt32(dr["id"].ToString());
                cl.Content = dr["content"].ToString();
                cl.CreateTime = dr["time"].ToString();
                cl.Sender = dr["Sender"].ToString();
                cl.Sendto = dr["Sendto"].ToString();
                lschat.Add(cl);
            }
            dr.Close();
            chat.PrivateChatList = lschat.ToArray();
        }
        #endregion

        return chat;
    }

    [WebMethod]
    public string SendChat(string sender, string sendto, string content, string chatnum, bool isPrivate, string color)
    {
        //这里也最好使用存储过程实现，llj098,20080424
        string sql = "SendChat";
        SqlParameter[] pa = new SqlParameter[7];
        pa[0] = new SqlParameter("@sender", sender);
        pa[1] = new SqlParameter("@sendto", sendto);
        pa[2] = new SqlParameter("@content", "<font style=\"color:" + color + ";\">" + Server.HtmlEncode(content) + "</font>");
        pa[3] = new SqlParameter("@chatnum", chatnum);
        pa[4] = new SqlParameter("@isparivate", isPrivate);
        pa[5] = new SqlParameter("@color", color);
        pa[6] = new SqlParameter("@Content1", content);

        Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteNonQuery(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.StoredProcedure, sql, pa);

        return "你好" + sender + sendto + content;
    }
    
}

