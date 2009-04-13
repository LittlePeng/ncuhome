using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core.FuncCommonReference;

namespace Ncuhome.Blog.Core
{
    /// <summary>
    /// 高等学生信息
    /// </summary>
    public  class BGDXSJBXX
    {
        /// <summary>
        /// 根据学号获取 个人基本信息
        /// </summary>
        /// <param name="XH"></param>
        /// <returns></returns>
        public static FuncCommonReference.XSJBXX GetXSJBXXByXH(string XH)
        {
             FuncCommonService xs= new FuncCommonService();
            return   xs.getXSJBXXByXh(XH);
        }
        /// <summary>
        ///  根据FIId获取 个人基本信息
        /// </summary>
        /// <param name="Fiid"></param>
        /// <returns></returns>
        public static XSJBXX GetXSJBXXByFIID(int Fiid)
        {
           int TxzID= (int) BView_CommonFunction.GetTxzIDByFIID(Fiid);
           FuncCommonService xs = new FuncCommonService();
           string XH= xs.GetNumberByTxzID(TxzID);
           return xs.getXSJBXXByXh(XH);
        }
        public static int GetTxzIdByTxzUID(string TxzUID)
        {
            FuncCommonService xs = new FuncCommonService();
            return xs.GetTxzIDByTxz(TxzUID);
        }
        /// <summary>
        ///  根据通行证ID获取 个人基本信息
        /// </summary>
        /// <param name="TxzID"></param>
        /// <returns></returns>
        public static XSJBXX GetXSJBXXByTxzID(int TxzID)
        {
            FuncCommonService xs = new FuncCommonService();
            string XH = xs.GetNumberByTxzID(TxzID);
            return xs.getXSJBXXByXh(XH);
        }



        /// <summary>
        /// 根据学号获取班级基本信息
        /// </summary>
        /// <param name="XH"></param>
        /// <returns></returns>
        public static BJJBXX GetBJJBXXByXH(string XH)
        {
            FuncCommonService xs = new FuncCommonService();
            return  xs.getBJJBXXByBh(XH);
        }
        /// <summary>
        /// 根据FIId获取班级基本信息
        /// </summary>
        /// <param name="Fiid"></param>
        /// <returns></returns>
        public static BJJBXX GetBJJBXXByFIID(int Fiid)
        {
            int TxzID = (int)BView_CommonFunction.GetTxzIDByFIID(Fiid);
            FuncCommonService xs = new FuncCommonService();
            string XH = xs.GetNumberByTxzID(TxzID);
            return xs.getBJJBXXByBh(XH);
        }
        /// <summary>
        /// 根据通行证号码获取班级基本信息
        /// </summary>
        /// <param name="TxzID"></param>
        /// <returns></returns>
        public static BJJBXX GetBJJBXXByTxzID(int TxzID)
        {
            FuncCommonService xs = new FuncCommonService();
            string XH = xs.GetNumberByTxzID(TxzID);
            return xs.getBJJBXXByBh(XH);
        }
       
    }
}
