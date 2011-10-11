using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace MySql.Data.ConsoleTest
{
    class AsyncMysqlTest
    {
        private const string _connectinString = "Data Source=localhost;Port=3306;Initial Catalog=test;Persist Security Info=True;User ID=root;Password=123456;Maximum Pool Size=1000";

        public void Proc()
        {
           
            ShowThreadPoolInfo();
            //CommonTest();
            AsyncTest();
        }

        private void ShowThreadPoolInfo()
        {
            ThreadPool.SetMinThreads(200, 200);
            ThreadPool.SetMaxThreads(200, 200);

            Thread th = new Thread(new ThreadStart(()=>
            {
                while (true)
                {
                    int work, iocp;
                    ThreadPool.GetAvailableThreads(out work, out iocp);
                    Console.WriteLine("running threads Work:{0},Iocp:{1}",200- work,200- iocp);
                    Thread.Sleep(1000);
                }
            }));
            th.Start();
        }

        private void AsyncTest()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    MySqlConnection con = new MySqlConnection(_connectinString);
                    MySqlCommand cmd = new MySqlCommand("select sleep(5);", con);
                    con.Open();
                    cmd.BeginExecuteReader(EndAsyncTest, cmd);
                    watch.Stop();
                    //  Console.WriteLine("Begin:{0}ms", watch.ElapsedMilliseconds);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void CommonTest()
        {
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    MySqlConnection con = new MySqlConnection(_connectinString);
                    MySqlCommand cmd = new MySqlCommand("select sleep(3);", con);
                    con.Open();
                    using (IDataReader reader = cmd.ExecuteReader())
                    {

                    }
                    con.Close();

                });
            }
        }

        private void EndAsyncTest(IAsyncResult result)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                MySqlCommand cmd = result.AsyncState as MySqlCommand;
                IDataReader reader = cmd.EndExecuteReader(result);
                do
                {
                    while (reader.Read())
                    {

                    }
                } while (reader.NextResult());
                reader.Close();
                cmd.Connection.Close();
                watch.Stop();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           // Console.WriteLine("End:{0}ms", watch.ElapsedMilliseconds);
        }
    }
}
