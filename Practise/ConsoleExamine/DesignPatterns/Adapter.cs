using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    public class OldWorker
    {
        public void Work()
        {
            //work
        }
    }

    public class CompositeNewWorker//Adapter
    {
        private readonly OldWorker worker = new OldWorker();
        public void DoWork(string logstr)
        {
            //log with logstr

            worker.Work();
        }
    }


    public interface INewWorker
    {
        void DoWork(string logStr);
    }

    public class InheritNewWork : OldWorker,INewWorker
    {
        public void DoWork(string logStr)
        {
            //log with input string 
            base.Work();
        }
    }
}
