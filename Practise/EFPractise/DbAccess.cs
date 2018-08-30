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
                var allReaders = context.ReaderModels.Take(20).ToList();
                foreach (var reader in allReaders)
                {
                    Console.WriteLine(reader.ReaderName);
                }
            }
        }
    }
}
