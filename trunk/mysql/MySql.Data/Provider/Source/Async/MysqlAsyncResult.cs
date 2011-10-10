using System;
using System.Collections.Generic;
using System.Text;

namespace MySql.Data.MySqlClient
{
    class MysqlAsyncResult : IAsyncResult
    {
        public object AsyncState { get; set; }

        /// <summary>
        /// 暂不支持，做了也没意义
        /// </summary>
        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get { throw new NotImplementedException(); }
        }

        public bool CompletedSynchronously
        {
            get { return true; }
        }

        public bool IsCompleted { get; set; }
    }
}
