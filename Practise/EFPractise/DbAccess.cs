using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFPractise
{
    public class DbAccess
    {
        public void Test()
        {
            //Select();
            LazyLoading();
        }

        public void Select()
        {
            using (var context = new MyPractiseDBEntities())
            {
                var participants = context.Participants.Where(p=>p.Id==2).Include("Registrations.XEvent").ToList();
                int count = participants.Count;

                if (participants.All(p => p.Registrations.All(r => r.EventId > 0)))
                {

                }

                var regs = context.Registrations.ToList();
            }
        }

        public void LazyLoading()
        {
            using (var dbContext = new MyPractiseDBEntities())
            {
                var ps = dbContext.Participants.ToList();

                dbContext.Entry(ps.First()).Collection(p => p.Registrations).Load();

            }
        }

    }
}
