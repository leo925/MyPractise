using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    public class ClrTestor
    {
        public void TestConversion()
        {
            Age a = new Age();
            a.MyAge = 10;

            var age = (int)a;

            Age b = age;
        }

        int aa;

        public void TestDynamicVar()
        {
            dynamic d1 = 4;
            d1 = "abc";


            var a = aa + 4;

        }

        public void TestParams()
        {
            Add(new int[] { 1, 3, 4 });

            Add(1, 2, 3, 6);
        }

        public int Add(params int[] ps)
        {
            int amount = 0;
            for (int i = 0; i < ps.Length - 1; i++)
            {
                amount += ps[i];
            }
            return amount;

        }



        public void TestIndexer()
        {
            ObjectWithIndexer obj = new ObjectWithIndexer();
            obj[4] = 9;
            var i5 = obj[4];

        }

        public void TestEnumConversion()
        {
            var v = Enum.Parse(typeof(ColorTypes), "Red2");
        }

        public void TestDelegate()
        {
            AddInts addInts = new AddInts(Add2Ints);
           var rResult= addInts.BeginInvoke(2, 3, r =>
            {
                string str = r.ToString();
            }, null);

            addInts.EndInvoke(rResult);

            Nullable<int> inta = null;
            int? intb = null;


            var methods= addInts.GetInvocationList();
          
             
        }

        int Add2Ints(int a, int b)
        {
            Thread.Sleep(7000);
            return a + b;
        }





    }


    public class ObjectWithIndexer
    {
        public event AddInts AddTwoInts;
        private int[] myInts = new int[] {1,2,3,4,5,6 };

       public int this[int i]
        {
            get
            {
                return myInts[i];

            }
            set
            {
                myInts[i] = value;

            }
        }

    }

    public enum ColorTypes
    {
        Red,
        Black

    }

    public delegate int AddInts(int a, int b);

     



}
