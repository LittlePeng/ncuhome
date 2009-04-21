using System;
using System.Web;
using System.IO;
using System.Configuration;
/// <summary>
/// ErrHandler 的摘要说明
/// </summary>
public class ErrHandler
{
	public ErrHandler()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static void saveError(String errorContent)
    {
	try
	{
        	string path = HttpContext.Current.Server.MapPath("Err.txt");
        
        	File.AppendAllText(path, errorContent);
	}
	catch
	{
		string path = ConfigurationManager.AppSettings[""];
		File.AppendAllText(path, errorContent);
	}
    }

}
