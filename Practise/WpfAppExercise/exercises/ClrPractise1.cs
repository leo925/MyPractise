using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExercise.exercises
{
    public class ClrPractise1
    {
        public delegate int MyConvert(int val);

        public void DoDeletegateChain_Exception()
        {
            MyConvert myConvert = Callback_Exception;
            myConvert += Callback_Exception;
            myConvert += Callback2;
            try
            {

                var result = myConvert(1);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        int Callback_Exception(int val)
        {
            throw new Exception("error");
            return val + 1;
        }
        int Callback2(int va2)
        {
            return va2 + 2;
        }

        int Callback3(int val)
        {
            return val + 3;
        }

        public void DoDelete_GetInvocationList()
        {
            MyConvert myConvert = Callback3;
            var array = myConvert.GetInvocationList();
            myConvert += Callback2;
            array = myConvert.GetInvocationList();
        }


        // attribute
        public class MyAttribute : Attribute
        {
            public MyAttribute(int field)
            {
                Field = field;
            }

            public int Field { get; }
        }

        [My(10)]
        public class Person
        {

        }

        public void DoAttribute_GetCustom()
        {
            Person p = new Person();
            var atts=  p.GetType().GetCustomAttributes(typeof(MyAttribute),false);
            foreach (var attr in atts)
            {

            }

        }

        //attribute


        public void DoFirstChanceException()
        {
            AppDomain.CurrentDomain.FirstChanceException += (s, e) =>
            {
                Console.Write("haha");
            };

            try
            {
                try
                {
                    throw new Exception("good");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex2)
            {

                throw;
            }
            

           
        }
         
    }
}
