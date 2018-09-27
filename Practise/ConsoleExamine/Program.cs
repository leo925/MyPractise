using EFPractise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    class Program
    {
        static Mutex m;
        static void Main(string[] args)
        {


            DesignPatternTestor testor = new DesignPatternTestor();
            testor.TestAdapter();



        }

        static void TestEvent()
        {

            ManualResetEventSlim manual = new ManualResetEventSlim(false);
            var waithandle = manual.WaitHandle;

            Task t = new Task((obj) =>
            {
                Console.WriteLine("start to work");
                Thread.Sleep(2000);
                var m = obj as ManualResetEventSlim;
                m.Set();
                m.Reset();
            }, manual);
            t.Start();
            while (waithandle.WaitOne(100) == false)
            {
                Console.WriteLine("waint for event");
                manual.Reset();
            }
            Console.WriteLine("complete waiting");

        }

        private static void TestMutex()
        {
            bool isNew;
            m = new Mutex(true, "leo", out isNew);
            if (!isNew)
            {
                try
                {
                    while (!m.WaitOne(2000))
                    {
                        Console.WriteLine("I am waitning");
                    }
                    Console.WriteLine("haha, I got the lock");
                }
                catch (Exception ex)
                {

                    var str = ex.Message;
                }
             
            }
        }

        public static void Test()
        {
            DbAccess dbAccess = new DbAccess();
            dbAccess.Test();
        }
    }
}

