namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ccc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegularSubjectClass", "RunningClassId", "dbo.RunningClass");
            DropForeignKey("dbo.UserClass", "RegularSubjectClassId", "dbo.RegularSubjectClass");
            DropForeignKey("dbo.UserClass", "UserId", "dbo.Users");
            DropIndex("dbo.RegularSubjectClass", new[] { "RunningClassId" });
            DropIndex("dbo.UserClass", new[] { "RegularSubjectClassId" });
            DropIndex("dbo.UserClass", new[] { "UserId" });
            DropTable("dbo.RegularSubjectClass");
            DropTable("dbo.UserClass");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegularSubjectClassId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        JoinedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        LeftDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegularSubjectClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RunningClassId = c.Int(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserClass", "UserId");
            CreateIndex("dbo.UserClass", "RegularSubjectClassId");
            CreateIndex("dbo.RegularSubjectClass", "RunningClassId");
            AddForeignKey("dbo.UserClass", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.UserClass", "RegularSubjectClassId", "dbo.RegularSubjectClass", "Id");
            AddForeignKey("dbo.RegularSubjectClass", "RunningClassId", "dbo.RunningClass", "Id");
        }
    }
}
