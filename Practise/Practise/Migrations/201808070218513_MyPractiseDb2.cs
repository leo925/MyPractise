namespace Practise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyPractiseDb2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReaderDetails", "Field1018", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReaderDetails", "Field1018");
        }
    }
}
