using EFPractise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadTestor t = new ConsoleExamine.ThreadTestor();
            t.TestThreadingUsa();
            Console.Read();
        }


        public static void Test()
        {
            DbAccess dbAccess = new DbAccess();
            dbAccess.Test();
        }
    }
}

