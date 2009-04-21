using System;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web;
using System.Data.SqlClient;
using nbyd.DataAccess;

/// <summary>
/// Summary description for WSError
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WSError : System.Web.Services.WebService
{

    public WSError()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public string ExHandle()
    {
        Exception e = Server.GetLastError();
        string Err = "";//DateTime.Now.ToString()+"\nBase Exception" + e.GetBaseException().ToString() ;// + "\nEx:" + e.ToString() + "\nIP:" + HttpContext.Current.Request.UserHostAddress + "\n:Page:" + HttpContext.Current.Request.Url.ToString() + "\n\n\n\n";
        ErrHandler.saveError(Err);
        return "ok";
    }



}

