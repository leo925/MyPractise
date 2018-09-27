using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    public class LogHelper
    {
        private LogHelper()
        {
        }
        readonly static object obj = new object();
        static LogHelper()
        {
            if (Instance == null)
            {
                lock (obj)
                {
                    if (Instance == null)
                    {

                        Instance = new LogHelper();
                    }
                }
            }
        }

        public static LogHelper Instance
        {
            get; set;
        }

        public void Write()
        {

        }
    }
}
