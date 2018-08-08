namespace Practise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyPractiseDb1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReaderDetails", "FieldForTest", c => c.Int(nullable: false));
            DropColumn("dbo.ReaderDetails", "AddFieldxxx");
            DropColumn("dbo.ReaderDetails", "AddFieldxxxaaaa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReaderDetails", "AddFieldxxxaaaa", c => c.Int(nullable: false));
            AddColumn("dbo.ReaderDetails", "AddFieldxxx", c => c.Int(nullable: false));
            DropColumn("dbo.ReaderDetails", "FieldForTest");
        }
    }
}
