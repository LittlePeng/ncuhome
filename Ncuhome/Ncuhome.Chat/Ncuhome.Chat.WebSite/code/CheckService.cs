using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///CheckService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class CheckService : System.Web.Services.WebService {

    public CheckService () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string DeleteM(int id)
    {
        SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString();
            SqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "pr_deletechatinfo";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return "ok";
    }

    [WebMethod]
    public string SendM(int id)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString();
        SqlCommand cmd = conn.CreateCommand();
        cmd.Parameters.AddWithValue("@id", id);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "pr_updatechatinfo";
        conn.Open();
        cmd.ExecuteNonQuery();
        return "ok";

    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    

}

