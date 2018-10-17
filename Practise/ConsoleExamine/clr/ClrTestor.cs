using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    public class ClrTestor
    {

        #region reflection
        public class Reflectionee
        {
            public Reflectionee() { }

            public Reflectionee(int i1) : this()
            {
                this.f1 = this.Prop1 = i1;
            }

            public Reflectionee(string i1) : this()
            {

            }

            private Reflectionee(int i1, int i2)
            {
                this.Prop1 = i1;
                this.Prop2 = i2;
            }
            private int f1;
            public int f2;

            private int Prop1 { get; set; }

            public int Prop2 { get; set; }

            private void M1(int i)
            {
                this.Prop1 = i;
            }
            public void M2(int i)
            {
                this.Prop2 = i;
            }
        }
        public void TestN()
        {
            var obj = new Reflectionee();
            Type t = obj.GetType();
            var methods = t.GetMethods(  BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).ToList(); 
            foreach (var m in methods)
            {
                Console.WriteLine(m.Name);
            }
            t.InvokeMember("M1", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,null, obj, new object[] { 66 });
            var members = t.GetMembers( BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance ).ToList();
            foreach (var member in members)
            {

            }

            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var f in fields)
            {
                var v = f.GetValue(obj);
                Console.WriteLine(v);
            }

            var Ps = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var f in Ps)
            {
                var v = f.GetValue(obj);
                Console.WriteLine(v);
            }

          //  var obj2 = Activator.CreateInstance(t, new object[] { 22}) as Reflectionee; //call constructor with in param 

           // var obj3 = Activator.CreateInstance(t, new object[] { "haha" }) as Reflectionee;

            //via private constructor
           // var ctors = t.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic );

            // var obj4 = ctors[0].Invoke(new object[] { 1, 2 });

            var obj5 = Assembly.GetAssembly(t).CreateInstance("ConsoleExamine.ClrTestor+Reflectionee") as Reflectionee;

            var obj6 = t.Assembly.CreateInstance("ConsoleExamine.ClrTestor+Reflectionee") as Reflectionee;
   

        }
        #endregion

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
