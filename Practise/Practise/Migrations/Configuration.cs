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
            context.Readers.AddOrUpdate(c =>c.Name,new Models.ReaderModel()
            {
                Name="seed reader1", IP="1.1.1.1", Port=80, ReaderType="lite"
            }
          );
        }
    }
}
