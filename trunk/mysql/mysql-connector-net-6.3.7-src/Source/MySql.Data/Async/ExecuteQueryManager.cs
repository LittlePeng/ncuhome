using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace MySql.Data.MySqlClient
{
    /// <summary>
    /// 管理超时
    /// </summary>
    class ExecuteQueryManager
    {
        private Thread _thread;
        private HashSet<MySqlCommand> _dict;
        private static object _syncRoot=new object();
        
        private static ExecuteQueryManager _instace;
        public static ExecuteQueryManager Instace
        {
            get
            {
                if (_instace == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instace == null)
                            _instace = new ExecuteQueryManager();
                    }
                }
                return _instace;
            }
        }

        public ExecuteQueryManager()
        {
            _dict = new HashSet<MySqlCommand>();

            _thread= new Thread(new ThreadStart(Proc));
            _thread.IsBackground = true;
            _thread.Start();
        }

        public bool Add(MySqlCommand cmd)
        {
            lock (_syncRoot)
            {
                return _dict.Add(cmd);
            }
        }

        public bool Remove(MySqlCommand cmd)
        {
            lock (_syncRoot)
            {
                return _dict.Remove(cmd);
            }
        }

        private void Proc()
        {
            while (true)
            {
                try
                {
                    IEnumerable<MySqlCommand> cmds;
                    lock (_syncRoot)
                    {
                        cmds = _dict.ToList();
                    }
                    //todo 超时使用连接池连接，可能超时发送失败
                    foreach (MySqlCommand cmd in cmds)
                    {
                        if (cmd.BeginTransTime.AddSeconds(cmd.CommandTimeout) < DateTime.Now)
                        {
                            this.Remove(cmd);
                            cmd.TimeoutExpired(cmd);
                        }
                    }
                }
                catch(Exception ex)
                {

                }

                Thread.Sleep(1000);
            }
        }
    }
}
