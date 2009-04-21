using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;


/// <summary>
/// DBHelper 的摘要说明
/// </summary>

namespace nbyd.DBHelper
{
    public class DBHelper
    {
        public DBHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 读出数据库中的某个表的某个字段
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="FieldName">字段名</param>
        /// <param name="Condition">条件</param>
        /// <returns></returns>
        public static string ExecuteReader(string TableName,string FieldName,string Condition)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "SELECT " + FieldName + " FROM " + TableName;
            if(Condition!="")
            {
                cmd.CommandText = cmd.CommandText + " WHERE " + Condition;
            }
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string temp = "";
            if (dr.HasRows)
            {
                temp = dr[0].ToString();
            }
            dr.Close();
            conn.Close();
            return temp;
        }

    }
}
