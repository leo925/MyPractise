using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    class TypeConversion
    {
    }

    public class Age
    {
        public int MyAge { get; set; }

        public static implicit operator Age(int i)
        {
            return new Age() { MyAge = i };

        }

        public static explicit operator Int32(Age a)
        {

            return a.MyAge;
        }
    }
}
