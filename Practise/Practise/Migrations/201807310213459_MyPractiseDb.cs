namespace Practise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyPractiseDb : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.ReaderModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    IP = c.String(),
                    Port = c.Int(nullable: false),
                    ConnectionStatus = c.Int(nullable: false),
                    ReaderType = c.String(),
                    TestSeedField = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ReaderDetails",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Owner = c.Int(nullable: false),
                    Des = c.String(),
                    ReaderId = c.Int(nullable: false),
                    AddField = c.Int(nullable: false),
                    AddField222 = c.Int(nullable: false),
                    AddField4444=c.Int(nullable:true),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReaderModels", t => t.ReaderId, true);

        }
        
        public override void Down()
        {
            DropTable("dbo.ReaderModels");
            DropTable("dbo.ReaderDetails");
        }
    }
}
