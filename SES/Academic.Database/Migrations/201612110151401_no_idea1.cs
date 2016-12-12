namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no_idea1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActivityResourceView", "UserClassId", "dbo.Users");
            DropIndex("dbo.ActivityResourceView", new[] { "UserClassId" });
            AddColumn("dbo.ActivityResourceView", "UserId", c => c.Int(nullable: false));
            AddForeignKey("dbo.ActivityResourceView", "UserId", "dbo.Users", "Id");
            CreateIndex("dbo.ActivityResourceView", "UserId");
            DropColumn("dbo.ActivityResourceView", "UserClassId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActivityResourceView", "UserClassId", c => c.Int(nullable: false));
            DropIndex("dbo.ActivityResourceView", new[] { "UserId" });
            DropForeignKey("dbo.ActivityResourceView", "UserId", "dbo.Users");
            DropColumn("dbo.ActivityResourceView", "UserId");
            CreateIndex("dbo.ActivityResourceView", "UserClassId");
            AddForeignKey("dbo.ActivityResourceView", "UserClassId", "dbo.Users", "Id");
        }
    }
}
