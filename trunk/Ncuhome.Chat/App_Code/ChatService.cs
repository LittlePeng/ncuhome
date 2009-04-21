using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for ChatService
/// </summary>
/// 
[ScriptService]
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ChatService : System.Web.Services.WebService {

    public ChatService () {}

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }


    [WebMethod]
    public string CheckUserStatus(string userName)
    {
        if (!nbyd.DataAccess.DataAccess.chat.IsOpen())
            return "聊天室已经关闭";
        string reason =nbyd.DataAccess.DataAccess.user.GetKickedReason(userName).Trim();
        if (reason != "")
        {
            return "您被管理员请出了聊天室,原因:" + reason;
        }
        nbyd.DataAccess.DataAccess.user.SetOnline(userName);
        return "";
    }

    [WebMethod(CacheDuration=1)]
    public string GetOnlineUserCount()
    {
        return nbyd.DataAccess.DataAccess.user.GetOnlineUserCount();
    }

    [WebMethod(CacheDuration=1)]
    public string GetOnlineGuestCount()
    {
        return nbyd.DataAccess.DataAccess.user.GetOnlineGuestCount();
    }
    [WebMethod]
    public string SendChat(string sender, string sendto, string content, string chatnum, bool isPrivate, string color)
    {
        //这里也最好使用存储过程实现，llj098,20080424
        string sql = "INSERT INTO [ChatInfo] ([Sender],[SendTo],[content],[ChatNum],[IsPrivate],[textcolor],[Content1]) VALUES (@sender,@sendto,@content,@chatnum,@isparivate,@color,@Content1)";
        SqlParameter[] pa = new SqlParameter[7];
        pa[0] = new SqlParameter("@sender", sender);
        pa[1] = new SqlParameter("@sendto", sendto);
        pa[2] = new SqlParameter("@content", "<font style=\"color:"+color+";\">" + content + "</font>");
        pa[3] = new SqlParameter("@chatnum", chatnum);
        pa[4] = new SqlParameter("@isparivate", isPrivate);
        pa[5] = new SqlParameter("@color", color);
        pa[6] = new SqlParameter("@Content1", content);

        Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteNonQuery(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.Text, sql, pa);

        return "你好" + sender + sendto + content;
    }
}

