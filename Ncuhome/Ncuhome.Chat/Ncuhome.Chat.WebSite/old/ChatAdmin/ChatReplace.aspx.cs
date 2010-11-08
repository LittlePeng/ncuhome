﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using nbyd.CheckLog;

public partial class ChatAdmin_ChatReplace : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Check.CheckAdminSession();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO [Replace] (Replace,ReplaceTo) VALUES (@Replace,@ReplaceTo)";
        cmd.Parameters.AddWithValue("@Replace",TextBox_Replace.Text);
        cmd.Parameters.AddWithValue("@ReplaceTo",TextBox_ReplaceTo.Text);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("manage.aspx");
    }
}