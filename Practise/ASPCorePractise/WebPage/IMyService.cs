using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPage
{
    public interface IMyService
    {
        string Show();
    }

    public class MyService : IMyService
    {
        public string Show()
        {
            return "haha";
        }
    }
}
