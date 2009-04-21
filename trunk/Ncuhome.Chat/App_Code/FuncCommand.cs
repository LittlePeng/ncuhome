using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


/// <summary>
/// FuncCommand 的摘要说明
/// </summary>
namespace nbyd
{
    public class FuncCommon
    {
        public static void MsgDialog(string msg)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>alert('" + msg +"');</script>");
        }
        public static void GoBack()
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.history.go(-1);</script>");
            HttpContext.Current.Response.End();
        }
        public static void GoToURL(string URL)
        {
             HttpContext.Current.Response.Write("<script language='javascript'>window.location='"+URL+"';</script>");
        }
        public static string FormatDateString(string str)
        {
            if (str.Length == 4)
            {
                return str + "年";
            }
            else
            {
                if (str.Length == 6)
                {
                    return str.Substring(0, 4) + "年" + str.Substring(4) + "月";
                }
                else
                {
                    if (str.Length == 8)
                    {
                        return str.Substring(0, 4) + "年" + str.Substring(4, 2) + "月" + str.Substring(6, 2) + "日";
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }
        /// <summary>
        /// 获得随机文件名
        /// </summary>
        /// <returns>没有后缀名的文件名</returns>
        public static string GetRndName()
        {
            System.Random rnd=new Random();
            DateTime time=DateTime.Now;
            return time.Year.ToString()+time.Month.ToString()+time.Day.ToString()+time.Hour.ToString()+time.Minute.ToString()+time.Second.ToString()+time.Millisecond.ToString()+rnd.Next(0,100).ToString("0000");
        }
        /// <summary>
        /// 获得随机文件名
        /// </summary>
        /// <param name="ext">后缀名</param>
        /// <returns>有后缀名的文件名</returns>
        public static string GetRndName(string ext)
        {
            System.Random rnd = new Random();
            ext = ext.Replace(".", "");
            DateTime time = DateTime.Now;
            return time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + time.Hour.ToString() + time.Minute.ToString() + time.Second.ToString() + time.Millisecond.ToString() + rnd.Next(0, 100).ToString("0000") + "." + ext; ;
        }
        /// <summary>
        /// 获得一定长度的文章题目
        /// </summary>
        /// <param name="s">文章题目</param>
        /// <param name="l">长度</param>
        /// <returns></returns>
        public static string CutString(string s, int l)
        {
            int len = 0;
            for (int i = 0; i <= s.Length - 1; i++)
            {
                if (Math.Abs(Convert.ToInt32(s[i])) > 255)
                {
                    len += 2;
                }
                else
                {
                    len += 1;
                }
            }
            if (len < l)
            {
                return s;
            }
            else
            {
                string r = "";
                len = 0;
                for (int i = 0; i <= s.Length - 1; i++)
                {
                    r += s.Substring(i, 1);
                    if (Math.Abs(Convert.ToInt32(s[i])) > 255)
                    {
                        len += 2;
                    }
                    else
                    {
                        len += 1;
                    }
                    if (len >= l - 3)
                    {
                        r += "...";
                        break;
                    }
                }
                return r;
            }
        }
    }
}