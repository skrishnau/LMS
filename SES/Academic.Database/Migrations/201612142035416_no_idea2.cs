namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no_idea2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActivityGrading", "UserId", "dbo.Users");
            DropIndex("dbo.ActivityGrading", new[] { "UserId" });
            AddColumn("dbo.ActivityGrading", "UserClassId", c => c.Int(nullable: false));
            AddForeignKey("dbo.ActivityGrading", "UserClassId", "dbo.UserClass", "Id");
            CreateIndex("dbo.ActivityGrading", "UserClassId");
            DropColumn("dbo.ActivityGrading", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActivityGrading", "UserId", c => c.Int(nullable: false));
            DropIndex("dbo.ActivityGrading", new[] { "UserClassId" });
            DropForeignKey("dbo.ActivityGrading", "UserClassId", "dbo.UserClass");
            DropColumn("dbo.ActivityGrading", "UserClassId");
            CreateIndex("dbo.ActivityGrading", "UserId");
            AddForeignKey("dbo.ActivityGrading", "UserId", "dbo.Users", "Id");
        }
    }
}
