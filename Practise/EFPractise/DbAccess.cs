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
            Select();
        }

        public void Select()
        {
            using (var context = new MyPractiseDBEntities())
            {
                var participants = context.Participants.Include(p=>p.Registrations).ToList();
                int count = participants.Count;


                var regs = context.Registrations.ToList();
            }
        }
    }
}
