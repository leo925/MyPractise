using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    class ThreadTestor
    {
        private object obj = new object();
        public delegate void MyDel();




        //test delegate poll and waiteone

        public void TestAsyncResult()
        {
            MyDel del = new MyDel(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("my delegated method completed!!!");
                var isback = Thread.CurrentThread.IsBackground;
             });

            var ir =  del.BeginInvoke((obj) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("ahah, this is the call back!");
                var isback = Thread.CurrentThread.IsBackground;
            }, "good");

            //while (ir.IsCompleted == false)////this will block the ui 
            //{
            //    {//this will block the ui 
            //        Thread.Sleep(500);
            //        Console.WriteLine("watinging!!!");
            //        var isback = Thread.CurrentThread.IsBackground;
            //    }
            //}

            while (ir.AsyncWaitHandle.WaitOne(4000) == false)//this method also block the calling thread(in this case , the main thread)
            {
                Console.WriteLine("watinging!!!");
            }
        }


        public void BasicSyncLockTest()
        {
            Monitor.TryEnter(obj, 2000);

            Monitor.Exit(obj);

            MyDel del = new MyDel(() => { });
           var result=  del.BeginInvoke((o) => { }, null);

            Mutex m = new Mutex();
            
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
