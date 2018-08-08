namespace Practise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyPractiseDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReaderDetails", "AddFieldxxxaaaa", c => c.Int(nullable: false));

            AddColumn("dbo.ReaderDetails", "AddFieldxxxaaaa2222222", c => c.Int(nullable: false));

            AddColumn("dbo.ReaderDetails", "AddFieldxxxaaaa44444", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReaderDetails", "AddFieldxxxaaaa");
        }
    }
}
