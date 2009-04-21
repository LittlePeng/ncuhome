using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChatAdmin_OnlineUserHelper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteNonQuery("update [user] set [isonline] = 0 where  datediff(second ,actiontime,getdate())>90 and isonline=1 ", Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString);
        }
        catch (Exception)
        {
            
        }
        
        
    }
}
