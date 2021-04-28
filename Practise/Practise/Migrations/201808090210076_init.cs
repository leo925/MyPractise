namespace Practise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {         
            CreateTable(
                "dbo.ReaderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Owner = c.Int(nullable: false),
                        Des = c.String(),
                        ReaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReaderReviewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Content = c.String(),
                        ReaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReaderModels", t => t.ReaderId, cascadeDelete: true)
                .Index(t => t.ReaderId);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReaderReviewModels", "ReaderId", "dbo.ReaderModels");
            DropIndex("dbo.ReaderReviewModels", new[] { "ReaderId" });
            DropTable("dbo.ReaderModels");
            DropTable("dbo.ReaderReviewModels");
            DropTable("dbo.ReaderDetails");
        }
    }
}
