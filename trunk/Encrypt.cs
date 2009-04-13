using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.IO;

namespace Ncuhome.Blog.Core
{
    public class CDES
    {
        public static string EncryptFIID(string str)
        {
            Ncuhome.Blog.Core.ActiveServices.ActiveServices a = new Ncuhome.Blog.Core.ActiveServices.ActiveServices();
            return a.GetEncryptFIID(str);
        }
    }
    ///   <summary>   
    ///   CDESEncrypt   的摘要说明。使用标准64位DES加密   
    ///   </summary>   
    public class CDES1
    {
        private byte[] FIV;
        private byte[] FKEY;
        public CDES1()
        {
            //   TODO:   在此处添加构造函数逻辑   
            this.DefaultInit();
        }

        ///   <summary>   
        ///   默认键值和初始向量   
        ///   </summary>   
        private void DefaultInit()
        {
            byte[] IV = { 155, 103, 246, 8, 36, 99, 234, 36 };
            byte[] key = { 142, 16, 93, 156, 78, 4, 218, 132 };
            FIV = IV;
            FKEY = key;
        }

        ///   <summary>   
        ///   采用标准   64位   DES   算法加密   
        ///   </summary>   
        ///   <param   name="strText">要加密的字符串</param>   
        ///   <returns>返回加密后的字符串</returns>   
        public  string Encrypt1(string strText)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(FKEY, FIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(strText);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
        }


        ///   <summary>   
        ///   标准64位DES解密   
        ///   </summary>   
        ///   <param   name="strText">要解密的字符串</param>   
        ///   <returns>返回解密后的字符串</returns>   
        public  string Decrypt1(string strText)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream(inputByteArray);
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(FKEY, FIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

    }

    ///   <summary>   
    ///   CDESEncrypt   的摘要说明。使用标准64位DES加密   
    ///   </summary>   
    public class CDES2
    {
        private byte[] FIV;
        private byte[] FKEY;
        public CDES2()
        {
            //   TODO:   在此处添加构造函数逻辑   
            this.DefaultInit();
        }

        ///   <summary>   
        ///   默认键值和初始向量   
        ///   </summary>   
        private void DefaultInit()
        {
            byte[] IV = { 157, 103, 255, 9, 36, 26, 28, 54 };
            byte[] key = { 45, 38, 156, 39, 148, 33, 58, 28 };
            FIV = IV;
            FKEY = key;
        }

        ///   <summary>   
        ///   采用标准   64位   DES   算法加密   
        ///   </summary>   
        ///   <param   name="strText">要加密的字符串</param>   
        ///   <returns>返回加密后的字符串</returns>   
        public  string Encrypt2(string strText)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(FKEY, FIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(strText);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
        }


        ///   <summary>   
        ///   标准64位DES解密   
        ///   </summary>   
        ///   <param   name="strText">要解密的字符串</param>   
        ///   <returns>返回解密后的字符串</returns>   
        public  string Decrypt2(string strText)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream(inputByteArray);
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(FKEY, FIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

    }
}   
 



