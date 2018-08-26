using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractise
{
    public class DbAccess
    {
        private void Ma()
        {
            using (var entities = new EFPractise.MyPractiseDBEntities())
            {
                entities.ReaderDetails.Add(new EFPractise.ReaderDetails());

                entities.SaveChanges();
            }
        }
    }
}
