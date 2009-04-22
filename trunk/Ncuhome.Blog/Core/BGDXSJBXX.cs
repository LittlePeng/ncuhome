using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core.FuncCommonReference;

namespace Ncuhome.Blog.Core
{
    /// <summary>
    /// 高等学生信息,通过WebService 获得一些学生信息数据。
    /// ==我在想，有什么方法可以把这的可恶的东西独立出去? :) ==
    /// llj098,20090422
    /// </summary>
    public  class BGDXSJBXX
    {
        /// <summary>
        /// 根据学号获取 个人基本信息
        /// </summary>
        /// <param name="XH"></param>
        /// <returns></returns>
        public static FuncCommonReference.XSJBXX GetXSJBXXByXH(string xh)
        {
             FuncCommonService xs= new FuncCommonService();
             return xs.getXSJBXXByXh(xh);
        }
        /// <summary>
        ///  根据FIId获取 个人基本信息
        /// </summary>
        /// <param name="Fiid"></param>
        /// <returns></returns>
        public static XSJBXX GetXSJBXXByFIID(int fiid)
        {
            int txzId = (int)BView_CommonFunction.GetTxzIDByFIID(fiid);
            FuncCommonService xs = new FuncCommonService();
            string xh = xs.GetNumberByTxzID(txzId);
            return xs.getXSJBXXByXh(xh);
        }
        
        /// <summary>
        /// 根据通行证的用户名获得数字型的ID,llj098,20090422
        /// </summary>
        /// <param name="txzUID"></param>
        /// <returns></returns>
        public static int GetTxzIdByTxzUID(string txzUID)
        {
            FuncCommonService xs = new FuncCommonService();
            return xs.GetTxzIDByTxz(txzUID);
        }
        
        /// <summary>
        ///  根据通行证ID获取 个人基本信息
        /// </summary>
        /// <param name="TxzID"></param>
        /// <returns></returns>
        public static XSJBXX GetXSJBXXByTxzID(int txzID)
        {
            FuncCommonService xs = new FuncCommonService();
            string xh = xs.GetNumberByTxzID(txzID);
            return xs.getXSJBXXByXh(xh);
        }

        /// <summary>
        /// 根据学号获取班级基本信息
        /// </summary>
        /// <param name="XH"></param>
        /// <returns></returns>
        public static BJJBXX GetBJJBXXByXH(string xh)
        {
            FuncCommonService xs = new FuncCommonService();
            return  xs.getBJJBXXByBh(xh);
        }
        /// <summary>
        /// 根据FIId获取班级基本信息
        /// </summary>
        /// <param name="Fiid"></param>
        /// <returns></returns>
        public static BJJBXX GetBJJBXXByFIID(int fiid)
        {
            int txzID = (int)BView_CommonFunction.GetTxzIDByFIID(fiid);
            FuncCommonService xs = new FuncCommonService();
            string xh = xs.GetNumberByTxzID(txzID);
            return xs.getBJJBXXByBh(xh);
        }
        /// <summary>
        /// 根据通行证号码获取班级基本信息
        /// </summary>
        /// <param name="TxzID"></param>
        /// <returns></returns>
        public static BJJBXX GetBJJBXXByTxzID(int txzID)
        {
            FuncCommonService xs = new FuncCommonService();
            string xh = xs.GetNumberByTxzID(txzID);
            return xs.getBJJBXXByBh(xh);
        }       
    }
}
