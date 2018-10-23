using EFPractise;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleExamine
{
    class Program
    {
        static Mutex m;
        static void Main(string[] args)
        {

            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                bitmap.Save("test.jpg", ImageFormat.Jpeg);
            }

            ClrTestor clrTestor = new ClrTestor();
            clrTestor.TestN();
           


            //  DesignPatternTestor testor = new DesignPatternTestor();
            //testor.TestDispose();
            //GC.Collect();
            Console.Read();


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

    public abstract class AClass
    {
        public void Good()
        {
            string str = "good";
        }
    }

    public interface IA
    {
        void M1();
    }
    public abstract class AA : IA
    {
        public abstract void M1();
    }

    public struct SA
    {
        public int rating { get; set; }

        public void M1()
        {
            this.rating = 1;
        }

    }
}

