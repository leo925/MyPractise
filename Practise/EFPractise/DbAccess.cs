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
            Select();
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


                
                var reader3 = context.ReaderModels.Find(1);
                reader3.ReaderName = "good reade666";



                var reader2 = context.ReaderModels.Find(2);
                reader2.ReaderName = "good reade2888";
                context.SaveChanges();
          
            }
        }
    }
}
