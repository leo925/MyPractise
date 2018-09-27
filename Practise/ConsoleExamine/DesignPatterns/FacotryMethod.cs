using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    public abstract class logger
    {
        public abstract void log();
    }

    public class XmlLogger : logger
    {
        public override void log()
        {
            Console.WriteLine("log in xml");
        }
    }

    public class TextLogger : logger
    {
        public override void log()
        {
            Console.WriteLine("log in text");
        }
    }

    public abstract class LogFactory
    {
        public abstract logger CreateLogger();
    }

    public class XmlLogFactory : LogFactory
    {
        public override logger CreateLogger()
        {
            return new XmlLogger();
        }
    }

}
