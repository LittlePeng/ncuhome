using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using nbyd.CheckLog;

public partial class ChatAdmin_OrgChat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Check.CheckAdminSession();
     }
    protected void selectChange(object sender, EventArgs e)
    {
        Response.Write("ok!<br />");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataBind();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {


        Response.ClearContent();

        Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");

        Response.ContentType = "application/excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        GridView1.RenderControl(htw);

        Response.Write(sw.ToString());

        Response.End();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("manage.aspx");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    
}
