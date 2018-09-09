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
            var pc = Environment.ProcessorCount;
            Test();
            Console.Read();
        }


        public static void Test()
        {
            DbAccess dbAccess = new DbAccess();
            dbAccess.Test();
        }
    }
}

