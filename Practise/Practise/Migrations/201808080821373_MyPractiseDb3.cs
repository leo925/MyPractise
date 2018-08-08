namespace Practise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyPractiseDb3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ReaderDetails", "AddField");
            DropColumn("dbo.ReaderDetails", "FieldForTest");
            DropColumn("dbo.ReaderDetails", "FieldForTest222222222");
            DropColumn("dbo.ReaderDetails", "Field1018");
            DropColumn("dbo.ReaderModels", "TestSeedField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReaderModels", "TestSeedField", c => c.Int(nullable: false));
            AddColumn("dbo.ReaderDetails", "Field1018", c => c.String());
            AddColumn("dbo.ReaderDetails", "FieldForTest222222222", c => c.Int(nullable: false));
            AddColumn("dbo.ReaderDetails", "FieldForTest", c => c.Int(nullable: false));
            AddColumn("dbo.ReaderDetails", "AddField", c => c.Int(nullable: false));
        }
    }
}
