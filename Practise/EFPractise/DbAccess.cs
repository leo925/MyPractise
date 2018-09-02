using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractise
{
    public class DbAccess
    {
        public void Test()
        {
           /// App_Start.EntityFrameworkProfilerBootstrapper.PreStart();

            Select();


            //using (var entities = new EFPractise.MyPractiseDBEntities())
            //{
            //    entities.ReaderDetails.Add(new EFPractise.ReaderDetails());

            //    entities.SSelectMethodaveChanges();
            //}
        }

        public void Select()
        {
            using (var context = new MyPractiseDBEntities())
            {
               // context.Configuration.ValidateOnSaveEnabled = false;

                var allReaders = context.ReaderModels.Take(30).ToList();
                foreach (var reader in allReaders)
                {
                    Console.WriteLine(reader.ReaderName);

                }


                
                var reader3 = context.ReaderModels.Find(1004);
                reader3.ReaderName = "good reade666";



                var reader2 = context.ReaderModels.Find(1005);
                reader2.ReaderName = "good reade2888";
                context.SaveChanges();
          
            }
        }
    }
}
