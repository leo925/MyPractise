namespace Practise.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Practise.Db.MyPractiseDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Practise.Db.MyPractiseDb context)
        {
            context.Readers.AddOrUpdate(c => c.Name, new Models.ReaderModel()
            {
                Name = "seed reader1",
                IP = "1.1.1.1",
                Port = 80,
                ReaderType = "lite"
            }
                     );

            context.ReaderReviews.AddOrUpdate(new Models.ReaderReviewModel()
            {
                ReaderId =3,
                Content = "it's a good reader",
                Rating = 10
            });

           var toDelete=  context.Readers.Where(r => r.Name == "reader");
            context.Readers.RemoveRange(toDelete);
            for (int i = 0; i < 1000; i++)
            {
                context.Readers.AddOrUpdate(c => c.Name, new Models.ReaderModel()
                {
                    Name = "reader"+i.ToString(),
                    IP = "1.1.1.1",
                    Port = 80,
                    ReaderType = "lite"
                }
                    );
            }
            //participant
            context.Participants.AddOrUpdate(r => r.Id, new Models.Participant()
            {
                Id = 1,
                Age = 22,
                FirstName = "Jim",
                LastName = "wang"
            });
            context.Participants.AddOrUpdate(r => r.Id, new Models.Participant()
            {
                Id = 2,
                Age = 22,
                FirstName = "Tom",
                LastName = "Jiang"
            });
            //race
            context.Races.AddOrUpdate(r => r.Id, new Models.XEvent() {
                 Id=1, EventName="isf marathon"
            });
            //registration
            context.Registrations.AddOrUpdate(r => r.Id, new Models.Registration() {
                  EventId=1, ParticipantId=1, Id=1
            });

            context.Registrations.AddOrUpdate(r => r.Id, new Models.Registration()
            {
                EventId = 1,
                ParticipantId =2,
                Id = 2
            });

        }
    }
}

/*
 
  select * from dbo.Participants p left join dbo.Registrations r
  on p.Id=r.ParticipantId 
  left join dbo.XEvents e on e.Id=r.EventId
     */
