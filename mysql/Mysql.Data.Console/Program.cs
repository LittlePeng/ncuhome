using System;

namespace MySql.Data.ConsoleTest
{
    static class Program
    {
        static void Main()
        {
            AsyncMysqlTest test = new AsyncMysqlTest();
            test.Proc();
        }
    }
}
