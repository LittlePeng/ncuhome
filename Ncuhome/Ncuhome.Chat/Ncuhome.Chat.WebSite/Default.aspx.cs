using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ncuhome.Chat.IISChatServer;
using System.Web.Query.Dynamic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    static int msgId = 1;
    protected void Button1_Click(object sender, EventArgs e)
    {
        CometThreadPool.HandleMessage(new Ncuhome.Chat.Model.ChatMessageModel() {  Id=msgId, Content="dd"});
        msgId++;
    }
}