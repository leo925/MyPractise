using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleExamine
{


    public class A
    {void Test()
        { }
        public  int fib(int i)
        {
            if (i == 1 || i == 2)
            {
                return 1;
            }
            else
            {
                return i + fib(i);
            }
        }
    }



    class ThreadTestor
    {
        private object obj = new object();
        public delegate void MyDel();




        //test delegate poll and waiteone

        public void BasicSyncLockTest()
        {
            Monitor.TryEnter(obj, 2000);

            Monitor.Exit(obj);

            MyDel del = new MyDel(() => { });
           var result=  del.BeginInvoke((o) => { }, null);

            Mutex m = new Mutex();


            Task t = Task.Run(() => { });
            t.ContinueWith(r => {
                Console.WriteLine("good");
            });
            
        }




        //test basic thread
        public void TestThreadingUsa()
        {
            object p = "asdf";
            Thread t1 = new Thread(new ParameterizedThreadStart( sp => {

                Console.WriteLine(Thread.CurrentThread.IsBackground);//false
                Thread.Sleep(5000);
                Console.WriteLine("thread finished!!");

            }));

            t1.Start("111");

            var task = new Task(() => {
                Console.WriteLine(Thread.CurrentThread.IsBackground);//true
                Thread.Sleep(5000);
                Console.WriteLine("task finished!!");
            });
            task.Start();

        }
    }



    
}
