<%@ Application Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码
    }


    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码
        
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码
       Exception ex =Server.GetLastError();
        string Err =DateTime.Now.ToString()+"\nBase Exception"+ex.GetBaseException().ToString()+"\nEx:"+ex.ToString()+"\nIP:"+Request.UserHostAddress+"\n:Page:"+Request.Url.ToString()+"\n\n\n\n";
        ErrHandler.saveError(Err);
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码
        Session["Session_Name"] = Session.SessionID + "/" + Request.UserHostAddress;
        this.Log("\r\nSession   Start:   " + Session["Session_Name"] + "/" + System.DateTime.Now.ToLongTimeString());   
    }
    
    protected void Log(string content)
    {
        //byte[] log = System.Text.Encoding.UTF8.GetBytes(content);
        //FileStream stream = File.Open(@"E:\\新版本的东东\\HomeChat\\log.txt", System.IO.FileMode.OpenOrCreate);
        //stream.Seek(0, System.IO.SeekOrigin.End);
        //stream.Write(log, 0, log.Length);
        //stream.Close();
    }   


    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为 InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 或 SQLServer，则不会引发该事件。
        this.Log("\r\nSession   End:   " + Session["Session_Name"] + "/" + System.DateTime.Now.ToLongTimeString());
        //System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
        //System.Data.SqlClient.SqlCommand cmd = conn.CreateCommand();
        //cmd.CommandText = "UPDATE [user] SET IsOnline=0 WHERE UserName=@name";
        //cmd.Parameters.AddWithValue("@name",Session[Convert.ToInt32(Session.SessionID)]);
        //conn.Open();
        //cmd.ExecuteNonQuery();
        //conn.Close();
    }
       
</script>
