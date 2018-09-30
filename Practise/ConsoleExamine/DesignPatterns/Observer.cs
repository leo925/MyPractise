using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    class Observer
    {
    }

    public class GetDataHelper
    {
        public GetDataHelper()
        {
            Coms = new List<ComBase>();
        }
        private List<ComBase> Coms
        {
            get; set;
        }
        public void GetData()
        {
            if ( Coms!=null)
            {
                foreach (var com in Coms)
                {
                    com.Notify();
                }
            }
        }

        public void AddCom(ComBase com)
        {
            Coms.Add(com);
        }

        public void RemoveCom(ComBase com)
        {
            Coms.Remove(com);
        }
    }

    public abstract class ComBase
    {
        public abstract void Notify();
    }

    public class Com1 : ComBase
    {
        public override void Notify()
        {
           //
        }
    }

    public class Com2 : ComBase
    {
        public override void Notify()
        {
           //
        }
    }
}
