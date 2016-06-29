namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no_idea__ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Headiing = c.String(),
                        Description = c.String(),
                        CreatedById = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        ViewerLimited = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.NoticeNotification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoticeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Viewed = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notice", t => t.NoticeId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.NoticeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.NoticeTo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoticeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notice", t => t.NoticeId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.NoticeId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.NoticeTo", new[] { "UserId" });
            DropIndex("dbo.NoticeTo", new[] { "NoticeId" });
            DropIndex("dbo.NoticeNotification", new[] { "UserId" });
            DropIndex("dbo.NoticeNotification", new[] { "NoticeId" });
            DropIndex("dbo.Notice", new[] { "CreatedById" });
            DropForeignKey("dbo.NoticeTo", "UserId", "dbo.Users");
            DropForeignKey("dbo.NoticeTo", "NoticeId", "dbo.Notice");
            DropForeignKey("dbo.NoticeNotification", "UserId", "dbo.Users");
            DropForeignKey("dbo.NoticeNotification", "NoticeId", "dbo.Notice");
            DropForeignKey("dbo.Notice", "CreatedById", "dbo.Users");
            DropTable("dbo.NoticeTo");
            DropTable("dbo.NoticeNotification");
            DropTable("dbo.Notice");
        }
    }
}
