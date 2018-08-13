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
                ReaderId = 1,
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

        }
    }
}
