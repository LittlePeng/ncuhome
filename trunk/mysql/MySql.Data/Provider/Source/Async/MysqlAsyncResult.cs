using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MySql.Data.MySqlClient
{
    class MysqlAsyncResult : IAsyncResult
    {
        public object AsyncState { get; set; }

        public EventWaitHandle _asyncWaitHandle;
        public WaitHandle AsyncWaitHandle
        {
            get
            {
                if (_asyncWaitHandle == null)
                    _asyncWaitHandle = new ManualResetEvent(false);
                return _asyncWaitHandle;
            }
        }

        public bool CompletedSynchronously
        {
            get { return true; }
        }

        public bool IsCompleted { get; set; }

        public MySqlDataReader DataReader { get; set; }
    }
}
