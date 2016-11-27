namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rand21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SessionAdmins", "TitleId", "dbo.AdminTitle");
            DropForeignKey("dbo.SessionAdmins", "SessionId", "dbo.Session");
            DropIndex("dbo.SessionAdmins", new[] { "TitleId" });
            DropIndex("dbo.SessionAdmins", new[] { "SessionId" });
            DropTable("dbo.SessionAdmins");
            DropTable("dbo.UserImage");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bytes = c.Binary(),
                        Extension = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SessionAdmins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        TitleId = c.Int(nullable: false),
                        Task = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.SessionAdmins", "SessionId");
            CreateIndex("dbo.SessionAdmins", "TitleId");
            AddForeignKey("dbo.SessionAdmins", "SessionId", "dbo.Session", "Id");
            AddForeignKey("dbo.SessionAdmins", "TitleId", "dbo.AdminTitle", "Id");
        }
    }
}
