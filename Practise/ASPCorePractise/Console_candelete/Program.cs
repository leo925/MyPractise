using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_candelete
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            var length = 124;
            StringBuilder questions = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                if (i > 0 && i % 3 == 0)
                {
                    questions.Append(Environment.NewLine);
                }
                var A = new Random(DateTime.Now.Millisecond).Next(1, 99);
                Thread.Sleep(2);
                var B = new Random(DateTime.Now.Millisecond).Next(1, 99);
                Thread.Sleep(2);
                var Sign = new Random(DateTime.Now.Millisecond).Next(0, 2) == 0 ? "+" : "-";
                if (Sign == "-")
                {
                    if (B>A)
                    {
                        var c = A;
                        A = B;
                        B = c;

                    }
                }
                questions.Append($"{A.ToString().PadLeft(2,' ')} {Sign.ToString().PadLeft(2, ' ')} {B.ToString().PadLeft(2, ' ')} =            ");
             
            }

            var qddddd = questions.ToString();

            var str = p.FirstName;

            Person p2 = null;
            var str2 = p2?.FirstName ?? "noname";
        }


    }

    public class Person
    {
        public string FirstName { get; set; } = "good";

        public string LastName { get; set; }
    }
}
